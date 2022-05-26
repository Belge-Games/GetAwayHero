using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractableObject
{
    public void OnInteract(PlayerController playerController);
}
