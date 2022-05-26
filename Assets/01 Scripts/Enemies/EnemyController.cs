using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        PlayerController playerController = collider.gameObject.GetComponent<PlayerController>();
        if(playerController != null)
        {
            GetComponent<IEnemy>().Attack(playerController);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if(playerController != null)
        {
            GetComponent<IEnemy>().Attack(playerController);
        }
    }
}
