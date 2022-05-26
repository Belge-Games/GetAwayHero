using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorldController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector2Int currentTilePosition;
    [SerializeField] private Vector2Int playerTilePosition;
    private Vector2Int onTileGridPlayerPosition;
    [SerializeField] private float tileSize = 20f;
    private GameObject[,] terrainTiles;
    [SerializeField] private int terrainTileHorizontalCount;
    [SerializeField] private int terrainTileVerticalCount;
    [SerializeField] private int fieldOfVisionHeight = 3;
    [SerializeField] private int fieldOfVisionWidth = 3;

    private void Awake()
    {
        terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];
    }

    private void Update()
    {
        playerTilePosition.x = (int)(playerTransform.position.x / tileSize);
        playerTilePosition.y = (int)(playerTransform.position.y / tileSize);

        playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0;
        playerTilePosition.y -= playerTransform.position.y < 0 ? 1 : 0;

        if (currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;

            onTileGridPlayerPosition.x = CalculatePositionOnAxis(onTileGridPlayerPosition.x, true);
            onTileGridPlayerPosition.y = CalculatePositionOnAxis(onTileGridPlayerPosition.y, false);

            UpdateTileOnScreen();
        }
    }

    private void UpdateTileOnScreen()
    {
        for (int pov_x = -(fieldOfVisionWidth/2); pov_x <= fieldOfVisionWidth/2; pov_x++)
        {
            for (int pov_y = -(fieldOfVisionHeight/2); pov_y <= fieldOfVisionHeight/2; pov_y++)
            {
                int tileToUpdate_x = CalculatePositionOnAxis(playerTilePosition.x + pov_x, true);
                int tileToUpdate_y = CalculatePositionOnAxis(playerTilePosition.y + pov_y, false);

                GameObject tile = terrainTiles[tileToUpdate_x, tileToUpdate_y];
                tile.transform.position = CalculateTilePosition(playerTilePosition.x + pov_x, playerTilePosition.y + pov_y);
            }
        }
    }

    private Vector3 CalculateTilePosition(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize, 0f);
    }

    private int CalculatePositionOnAxis(float currentValue, bool horizontal)
    {
        if (horizontal)
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileHorizontalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileHorizontalCount - 1 + currentValue % terrainTileHorizontalCount;
            }
        }
        else
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileVerticalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileVerticalCount - 1 + currentValue % terrainTileVerticalCount;
            }
        }


        return (int)currentValue;
    }

    public void Add(GameObject tileGameObject, Vector2Int tilePosition)
    {
        terrainTiles[tilePosition.x, tilePosition.y] = tileGameObject;
    }
}
