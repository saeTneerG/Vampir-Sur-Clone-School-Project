using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScrolling : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Vector2Int currentTilePosition = new Vector2Int(0,0);
    [SerializeField] Vector2Int playerTilePosition;
    Vector2Int onTileGridPlayerPosition;
    [SerializeField] float tileSize = 20f;
    GameObject[,] terrianTiles;

    [SerializeField] int terrianTilesHorizontalCount;
    [SerializeField] int terrianTilesVerticalCount;

    [SerializeField] int fieldOfVisionHeight = 3;
    [SerializeField] int fieldOfVisionWidht = 3;

    private void Awake(){
        terrianTiles = new GameObject[terrianTilesHorizontalCount, terrianTilesVerticalCount];
    }

    private void Start(){
        UpdateTileOnScreen();
    }

    private void Update(){
        playerTilePosition.x = (int)(playerTransform.position.x / tileSize);
        playerTilePosition.y = (int)(playerTransform.position.y / tileSize);

        playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0;
        playerTilePosition.y -= playerTransform.position.y < 0 ? 1 : 0;

        if(currentTilePosition != playerTilePosition){
            currentTilePosition = playerTilePosition;

            onTileGridPlayerPosition.x = CalculatePositionAxis(onTileGridPlayerPosition.x, true);
            onTileGridPlayerPosition.y = CalculatePositionAxis(onTileGridPlayerPosition.y, false);

            UpdateTileOnScreen();
        }
    }

    private void UpdateTileOnScreen(){
        for(int pov_x = -(fieldOfVisionWidht/2); pov_x <= fieldOfVisionWidht/2; pov_x++){
            for(int pov_y = -(fieldOfVisionHeight/2); pov_y <= fieldOfVisionHeight/2; pov_y++){
                int tileToUpdate_x = CalculatePositionAxis(playerTilePosition.x + pov_x, true);
                int tileToUpdate_y = CalculatePositionAxis(playerTilePosition.y + pov_y, false);

                GameObject tile = terrianTiles[tileToUpdate_x, tileToUpdate_y];
                tile.transform.position = CalculateTilePosition(playerTilePosition.x + pov_x, playerTilePosition.y + pov_y);
            }
        }
    }

    private Vector3 CalculateTilePosition(int x, int y){
        return new Vector3(x * tileSize, y * tileSize, 0f);
    }

    private int CalculatePositionAxis(float currentValue, bool horizontal){
        if(horizontal){
            if(currentValue >= 0){
                currentValue = currentValue % terrianTilesHorizontalCount;
            }
            else{
                currentValue += 1;
                currentValue = terrianTilesHorizontalCount - 1 + currentValue % terrianTilesHorizontalCount;
            }
        }
        else{
            if(currentValue >= 0){
                currentValue = currentValue % terrianTilesVerticalCount;
            }
            else{
                currentValue += 1;
                currentValue = terrianTilesVerticalCount - 1 + currentValue % terrianTilesVerticalCount;
            }
        }

        return (int)currentValue;
    }

    public void Add(GameObject tileGameObjects, Vector2Int tilePosition){
        terrianTiles[tilePosition.x, tilePosition.y] = tileGameObjects;
    }
}
