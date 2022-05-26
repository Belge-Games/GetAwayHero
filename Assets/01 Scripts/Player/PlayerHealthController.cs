using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private PlayerStatusBar playerStatusBar;
    [SerializeField] private int playerMaxHealth = 1000;
    private int playerCurrentHealth;

    private void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        SetHealthState();
    }

    public void DecreaseHealth(int damage)
    {
        if(playerCurrentHealth <= 0) return;

        this.playerCurrentHealth -= damage;
        if(playerCurrentHealth <= 0)
        {
            Debug.Log("Game Over");
        }
        SetHealthState();
    }

    public void IncreaseHealth(int heal)
    {
        if(playerCurrentHealth <= 0) return;

        this.playerCurrentHealth += heal;
        if(playerCurrentHealth >= playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
        SetHealthState();
    }

    private void SetHealthState()
    {
        if(playerStatusBar != null)
        {
            playerStatusBar.SetState(playerCurrentHealth, playerMaxHealth);
        }
    }
}
