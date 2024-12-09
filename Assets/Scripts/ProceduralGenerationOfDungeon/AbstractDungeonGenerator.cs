using UnityEngine;

public abstract class AbstractDungeonGenerator : MonoBehaviour
{
    [SerializeField] protected TilemapView TilemapView = null;
    [SerializeField] protected Vector2Int StartPosition = Vector2Int.zero;

    public void GenerateDungeon()
    {
        TilemapView.Clear();

        RunProceduralGeneration();
    }

    public void ClearDungeon()
    {
        TilemapView.Clear();
    }

    protected abstract void RunProceduralGeneration();
}