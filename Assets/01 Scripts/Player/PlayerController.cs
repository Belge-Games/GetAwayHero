using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerAnimation playerAnimation;
    private PlayerMovement playerMovement;
    private PlayerHealthController playerHealthController;
    private PlayerLevelController playerLevelController;
    private PlayerCoinController playerCoinController;

    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerMovement = GetComponent<PlayerMovement>();
        playerHealthController = GetComponent<PlayerHealthController>();
        playerLevelController = GetComponent<PlayerLevelController>();
        playerCoinController = GetComponent<PlayerCoinController>();
    }

    public PlayerAnimation GetPlayerAnimation()
    {
        return this.playerAnimation;
    }

    public PlayerMovement GetPlayerMovement()
    {
        return this.playerMovement;
    }

    public PlayerCoinController GetPlayerCoinController()
    {
        return this.playerCoinController;
    }

    public PlayerHealthController GetPlayerHealthController()
    {
        return this.playerHealthController;
    }

    public PlayerLevelController GetPlayerLevelController()
    {
        return this.playerLevelController;
    }
}
