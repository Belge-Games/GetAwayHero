using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingDaggerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject daggerPrefab;
    [SerializeField] private float delayToAttack = 2f;
    private float timerToAttack;

    private void Start() 
    {
        timerToAttack = delayToAttack;
    }

    private void Update()
    {
        timerToAttack -= Time.deltaTime;
        if(timerToAttack <= 0f)
        {
            EnableSprite();
        }
    }

    private void EnableSprite()
    {
        timerToAttack = delayToAttack;

        GameObject dagger = Instantiate(daggerPrefab);
        dagger.transform.position = transform.position;

        PlayerMovement playerMovement = GameController.GetPlayer().GetComponent<PlayerController>().GetPlayerMovement();
        dagger.GetComponent<ThrowingDaggerProjectile>().SetDirection(playerMovement.GetLastHorizontalVector(), 0f);
    }
}
