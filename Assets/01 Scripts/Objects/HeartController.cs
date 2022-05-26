using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour, ICollectableObject
{
    [SerializeField] private int amount;

    public void OnCollect(PlayerController playerController)
    {
        playerController.GetPlayerHealthController().IncreaseHealth(this.amount);
    }

    public void SetAmount(int value)
    {
        this.amount = value;
    }

    public int GetAmount()
    {
        return this.amount;
    }
}
