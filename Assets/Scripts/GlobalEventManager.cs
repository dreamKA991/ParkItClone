using UnityEngine;
using UnityEngine.Events;
public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent onCharacterParkedCorrectly = new UnityEvent();
    public static UnityEvent onCharacterLose = new UnityEvent();
    public static UnityEvent<GameObject> onCharacterTouchedGameObject = new UnityEvent<GameObject>();
    public static UnityEvent onRestart = new UnityEvent();
}
