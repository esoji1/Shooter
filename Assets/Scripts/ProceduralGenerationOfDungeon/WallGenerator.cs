using System;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPosition, TilemapView tilemapView)
    {
        HashSet<Vector2Int> basicWallPositions = FindWallsInDirections(floorPosition, Direction2D.CardionalDirectionsList);

        foreach (Vector2Int position in basicWallPositions)
        {
            tilemapView.SingleBasicWall(position);
        }
    }

    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPosition, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();

        foreach (Vector2Int position in floorPosition)
        {
            foreach (Vector2Int direction in directionList)
            {
                Vector2Int neighbourPosition = position + direction;

                if (floorPosition.Contains(neighbourPosition) == false)
                    wallPositions.Add(neighbourPosition);
            }
        }

        return wallPositions;
    }
}