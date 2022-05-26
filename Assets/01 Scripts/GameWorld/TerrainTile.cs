using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTile : MonoBehaviour
{
    [SerializeField] private Vector2Int tilePosition;

    private void Start()
    {
        GetComponentInParent<GameWorldController>().Add(gameObject, tilePosition);
    }

}
