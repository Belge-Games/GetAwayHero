using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    [SerializeField] private float delayToAttack = 3f;
    [SerializeField] private float delayToDisable = 0.4f;
    [SerializeField] private int weaponDamage = 10;
    private float timerToAttack;
    private float timerToDisable;
    [SerializeField] private GameObject[] gameObjects;
    private bool disabled = true;
    [SerializeField] private Vector2 attackSize = new Vector2(4f, 2f);

    private void Start() 
    {
        timerToAttack = delayToAttack;
        timerToDisable = 0f;
    }

    private void Update()
    {
        timerToAttack -= Time.deltaTime;
        timerToDisable -= Time.deltaTime;

        if(timerToAttack <= 0f && disabled) 
        {
            EnableSprites();
        } 

        else if(timerToDisable <= 0f && !disabled)
        {
            DisableSprites();
        }

        else if(!disabled)
        {
            Attack();
        }
    }

    private void Attack()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            GameObject currentObject = gameObjects[i];
            Collider2D[] colliders = Physics2D.OverlapBoxAll(currentObject.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }
    }

    private void DisableSprites()
    {
        disabled = true;
        for (int i = 0; i < gameObjects.Length; i++)
        {
            GameObject currentObject = gameObjects[i];
            currentObject.SetActive(false);
        }
    }

    private void EnableSprites()
    {
        disabled = false;

        timerToDisable = delayToDisable;
        timerToAttack = delayToAttack;

        for (int i = 0; i < gameObjects.Length; i++)
        {
            GameObject currentObject = gameObjects[i];
            currentObject.SetActive(true);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            Collider2D collider = colliders[i];
            if(collider.CompareTag(Constants.Tags.ENEMY))
            {
                IEnemy enemy = collider.gameObject.GetComponent<IEnemy>();
                if(enemy != null)
                {
                    enemy.DecreaseHealth(weaponDamage);
                }
            } 
            else if(collider.CompareTag(Constants.Tags.DESTRUCTABLE))
            {
                IDestructableObject destructableObject = collider.gameObject.GetComponent<IDestructableObject>();
                if(destructableObject != null)
                {
                    destructableObject.DecreaseHealth(weaponDamage);
                }
            }
        }
    }
}
