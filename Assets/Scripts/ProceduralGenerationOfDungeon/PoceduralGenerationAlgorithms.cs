using Mono.Cecil;
using System.Collections.Generic;
using UnityEngine;

public static class PoceduralGenerationAlgorithms
{
    public static HashSet<Vector2Int> SimpleRandomWalke(Vector2Int startPosition, int walkLenght)
    {
        HashSet<Vector2Int> pasth = new HashSet<Vector2Int>();

        pasth.Add(startPosition);

        Vector2Int previousPosition = startPosition;

        for (int i = 0; i < walkLenght; i++)
        {
            Vector2Int newPosition = previousPosition + Direction2D.GetRandomCardinalDirection();
            pasth.Add(newPosition);
            previousPosition = newPosition;
        }

        return pasth;
    }
}

public static class Direction2D
{
    public static List<Vector2Int> CardionalDirectionsList = new List<Vector2Int>()
    {
        new Vector2Int(0, 1),
        new Vector2Int(1, 0),
        new Vector2Int(0, -1),
        new Vector2Int(-1, 0)
    };

    public static Vector2Int GetRandomCardinalDirection()
        => CardionalDirectionsList[Random.Range(0, CardionalDirectionsList.Count)];
}