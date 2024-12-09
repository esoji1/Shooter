using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGenerator
{
    [SerializeField] private SimpleRandomWalkSO _randomWalkParameters;
    [SerializeField] private Button _generate;

    private void OnEnable()
    {
        _generate.onClick.AddListener(RunProceduralGeneration);
    }

    private void OnDisable()
    {
        _generate.onClick.RemoveListener(RunProceduralGeneration);
    }

    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk();

        TilemapView.Clear();
        TilemapView.PaintFloorTiles(floorPositions);

        WallGenerator.CreateWalls(floorPositions, TilemapView);
    }

    protected HashSet<Vector2Int> RunRandomWalk()
    {
        Vector2Int currentPositon = StartPosition;
        HashSet<Vector2Int> floorPositons = new HashSet<Vector2Int>();

        for (int i = 0; i < _randomWalkParameters.Iterations; i++)
        {
            HashSet<Vector2Int> path = PoceduralGenerationAlgorithms
                .SimpleRandomWalke(currentPositon, _randomWalkParameters.WalkLength);
            floorPositons.UnionWith(path);

            if (_randomWalkParameters.StartRandomlyEachIteration)
                currentPositon = floorPositons.ElementAt(Random.Range(0, floorPositons.Count));
        }

        return floorPositons;
    }
}