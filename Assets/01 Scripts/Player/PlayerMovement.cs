using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimation playerAnimation;
    private Rigidbody2D rBody;
    private Vector3 movementVector;
    private float lastHorizontalVector = 1f;
    [SerializeField] private float playerSpeed = 3f;

    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        rBody = GetComponent<Rigidbody2D>();
        movementVector = new Vector3(); 
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if(movementVector.x != 0) 
        {
            lastHorizontalVector = movementVector.x;
        }

        playerAnimation.horizontal = movementVector.x;
        playerAnimation.vertical = movementVector.y;

        rBody.velocity = movementVector * playerSpeed;
    }

    public Vector3 GetMovementVector()
    {
        return this.movementVector;
    }

    public float GetLastHorizontalVector()
    {
        return this.lastHorizontalVector;
    }
}
