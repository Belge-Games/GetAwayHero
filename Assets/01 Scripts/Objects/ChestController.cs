using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController: MonoBehaviour, IInteractableObject
{
    [SerializeField] private float delayForDestroy = 2f;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void OnInteract(PlayerController playerController)
    {
        Animate();
    }

    private void Animate()
    {
        animator.SetBool(Constants.Animation.COLLECTABLE_ANIMATE, true);
        StartCoroutine(DestroyWithDelay());
    }

    IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds((int) delayForDestroy);
        Destroy(this.gameObject);
    }
}
