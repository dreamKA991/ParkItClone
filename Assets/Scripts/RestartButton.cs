using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] restartableComponents;

    public void RestartAllScene()
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
