using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public void Attack(PlayerController playerController);
    public void DecreaseHealth(int damage);
    }
