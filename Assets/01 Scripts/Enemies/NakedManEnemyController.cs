using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class NakedManEnemyController : MonoBehaviour, IEnemy
{
    [SerializeField] private int enemyHealth = 10;
    [SerializeField] private float enemySpeed = 4f;
    [SerializeField] private int enemyDamage = 10;
    [SerializeField] private int enemyExpReward = 100;
    
    private Rigidbody2D rBody;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        GameObject player = GameController.GetClosestPlayer(transform.position);
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rBody.velocity = direction * enemySpeed;
    }

    public void Attack(PlayerController playerController)
    {
        playerController.GetPlayerHealthController().DecreaseHealth(enemyDamage);
    }

    public void DecreaseHealth(int damage)
    {
        this.enemyHealth -= damage;
        if(enemyHealth <= 0)
        {
            Destroy(this.gameObject);   
        }
    }

    private void OnDestroy()
    {
        if(!this.gameObject.scene.isLoaded) return;

        PlayerController playerController = GameController.GetClosestPlayer(transform.position).GetComponent<PlayerController>();
        playerController.GetPlayerLevelController().AddExperience(enemyExpReward);
    } 
}
