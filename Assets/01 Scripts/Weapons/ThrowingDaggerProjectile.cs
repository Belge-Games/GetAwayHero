using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingDaggerProjectile : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float daggerSpeed = 5f;
    [SerializeField] private int daggerDamage = 20;
    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += direction * daggerSpeed * Time.deltaTime;
    }

    public void SetDirection(float x, float y)
    {
        direction = new Vector3(x, y);

        if(x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.y = scale.y * -1;
            transform.localScale = scale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        IEnemy enemy = collider.GetComponent<IEnemy>();
        if(enemy != null)
        {
            enemy.DecreaseHealth(daggerDamage);
            Destroy(this.gameObject);
        }
    }
}
