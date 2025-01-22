using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGrading : MonoBehaviour
{
    public void LevelGradeSave(int grade)
    {
        string levelname = SceneManager.GetActiveScene().name;
        int previousGrade = PlayerPrefs.GetInt(levelname, 0);
        if (grade > previousGrade) PlayerPrefs.SetInt(levelname, grade);
        PlayerPrefs.Save();
    }
    public int GetLevelGrade(string nameLevel) { return PlayerPrefs.GetInt(nameLevel, 0); }
}
