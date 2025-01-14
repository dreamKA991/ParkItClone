using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] restartableComponents;
    //private void Start() => GlobalEventManager.onRestart.AddListener(RestartAllScene);
    public void RestartAllScene()
    {
        GlobalEventManager.onRestart?.Invoke();
        RestartObjects();
    }

    private void RestartObjects()
    {
        foreach (var component in restartableComponents)
        {
            if (component is IRestartable restartable)
            {
                restartable.Restart();
            }
        }
    }
}
