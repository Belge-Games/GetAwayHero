using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinController : MonoBehaviour
{
    [SerializeField] private PlayerStatusBar playerStatusBar;
    private int playerCoin = 0;

    private void Start()
    {
        SetCoinState();
    }

    public void DecreaseCoin(int amount)
    {
        this.playerCoin -= amount;
        SetCoinState();
    }

    public void IncreaseCoin(int amount)
    {
        this.playerCoin += amount;
        SetCoinState();
    }

    private void SetCoinState()
    {
        if(playerStatusBar != null)
        {
            playerStatusBar.SetText(playerCoin.ToString());
        }
    }
}
