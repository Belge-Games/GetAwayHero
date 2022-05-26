using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    [HideInInspector] public float horizontal;
    [HideInInspector] public float vertical;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        animator.SetFloat(Constants.Animation.HORIZONTAL, horizontal);
        animator.SetFloat(Constants.Animation.VERTICAL, vertical);
        animator.SetBool(Constants.Animation.IDLE_HORIZONTAL, horizontal == 0);
        animator.SetBool(Constants.Animation.IDLE_VERTICAL, vertical == 0);
    }
}
