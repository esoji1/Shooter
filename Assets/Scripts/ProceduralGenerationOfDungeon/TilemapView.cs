using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapView : MonoBehaviour
{
    [SerializeField] private Tilemap _floorTilemap;
    [SerializeField] private Tilemap _wallTilemap;
    [SerializeField] private TileBase _floorTile;
    [SerializeField] private TileBase _wallTop;

    public void PaintFloorTiles(IEnumerable<Vector2Int> flootPositions)
    {
        PaintTiles(flootPositions, _floorTilemap, _floorTile);
    }

    public void Clear()
    {
        _floorTilemap.ClearAllTiles();
        _wallTilemap.ClearAllTiles();
    }

    internal void SingleBasicWall(Vector2Int position)
    {
        PaintSingleTile(_wallTilemap, _wallTop, position);
    }

    private void PaintTiles(IEnumerable<Vector2Int> porisitons, Tilemap tilemap, TileBase tile)
    {
        foreach (Vector2Int position in porisitons)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        Vector3Int tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }
}