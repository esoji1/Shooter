using System;
using System.IO;
using UnityEngine;

public class LevelLoadingData
{
    private const string EasyDifficultyConfig = "EasyDifficultyConfig";
    private const string MediumDifficultyConfig = "MediumDifficultyConfig";
    private const string ComplexComplexityConfig = "ComplexComplexityConfig";

    private const string ConfigsPath = "LevelSettings";

    private DifficultyConfig _difficultyConfig;

    public LevelLoadingData(int level)
    {
        Level = level;
        SelectConfiguration(Level);
    }

    public int Level { get; }
    public DifficultyConfig DifficultyConfig => _difficultyConfig;

    private void SelectConfiguration(int level)
    {
        switch(level)
        {
            case 1:
                _difficultyConfig = Resources.Load<DifficultyConfig>(Path.Combine(ConfigsPath, EasyDifficultyConfig));
                break;

            case 2:
                _difficultyConfig = Resources.Load<DifficultyConfig>(Path.Combine(ConfigsPath, MediumDifficultyConfig));
                break;

            case 3:
                _difficultyConfig = Resources.Load<DifficultyConfig>(Path.Combine(ConfigsPath, ComplexComplexityConfig));
                break;

            default:
                throw new ArgumentException(nameof(level));
        }
    }
}
