using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondController : MonoBehaviour, ICollectableObject
{
    [SerializeField] private int amount;

    public void OnCollect(PlayerController playerController)
    {
        playerController.GetPlayerLevelController().AddExperience(this.amount);
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
