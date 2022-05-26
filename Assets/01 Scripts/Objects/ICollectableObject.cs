using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectableObject
{
    public void OnCollect(PlayerController playerController);
    public void SetAmount(int amount);
}
