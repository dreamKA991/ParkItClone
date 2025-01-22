using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private Scene currentScene;
    [SerializeField] BannerAd bannerAd;
    public void LoadScene(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
        GlobalEventManager.onRestart?.Invoke();
    }

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        
        if (currentScene.name == "LevelMenu") { bannerAd.OnMenuLoaded(); bannerAd.ShowBanner(); }
    }

    public void LoadNextLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string levelName = currentScene.name;

        if (levelName.StartsWith("level"))
        {
            // Extract the level number from the name
            string levelNumberString = levelName.Substring(5); // Remove "level"
            if (int.TryParse(levelNumberString, out int currentLevelNumber))
            {
                int nextLevelNumber = currentLevelNumber + 1;
                string nextLevelName = "level" + nextLevelNumber;

                // Check if the next level exists
                if (Application.CanStreamedLevelBeLoaded(nextLevelName))
                    SceneManager.LoadScene(nextLevelName);
                else
                    Debug.LogWarning("Next level not found: " + nextLevelName);
            }
            else
                Debug.LogError("Failed to extract level number from name: " + levelName);
        }
        else
            Debug.LogError("Scene name does not start with 'level': " + levelName);
    }
}

