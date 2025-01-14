using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStarsLevelsLoad : MonoBehaviour
{
    [SerializeField] List<Level> Levels = new List<Level>();
    [SerializeField] private LevelGrading levelGrading;
    [SerializeField] private Sprite filledStar, emptyStar;

    private void Start()
    {
        SetGrade("level1", Levels[0]);
        SetGrade("level2", Levels[1]);
        SetGrade("level3", Levels[2]);
        SetGrade("level4", Levels[3]);
        SetGrade("level5", Levels[4]);
    }
    private void SetGrade(string levelName, Level level)
    {
        int grade = levelGrading.GetLevelGrade(levelName);
        if (grade >= 1) level.stars[0].sprite = filledStar;
        if (grade >= 2) level.stars[1].sprite = filledStar;
        if (grade == 3) level.stars[2].sprite = filledStar;
    }
}
[Serializable]
struct Level
{
    [SerializeField] public List<Image> stars;
}

