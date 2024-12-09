using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AbstractDungeonGenerator), true)]
public class RandomDungenGeneratorEditor : Editor
{
    private AbstractDungeonGenerator _generator;

    private void Awake()
    {
        _generator = target as AbstractDungeonGenerator;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Create Dungeon"))
        {
            _generator.GenerateDungeon();
        }
        else if(GUILayout.Button("Clear Dungeon"))
        {
            _generator.ClearDungeon();
        }
    }
}