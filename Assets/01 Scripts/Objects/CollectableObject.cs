using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerController playerController = collider.gameObject.GetComponent<PlayerController>();
        if(playerController != null)
        {
            GetComponent<ICollectableObject>().OnCollect(playerController);
            DestroyCollectable();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if(playerController != null)
        {
            GetComponent<ICollectableObject>().OnCollect(playerController);
            DestroyCollectable();
        }
    }

    private void DestroyCollectable()
    {
        Destroy(this.gameObject);
    }
}
