using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerController playerController = collider.gameObject.GetComponent<PlayerController>();
        if(playerController != null)
        {
            GetComponent<IInteractableObject>().OnInteract(playerController);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if(playerController != null)
        {
            GetComponent<IInteractableObject>().OnInteract(playerController);
        }
    }
}
