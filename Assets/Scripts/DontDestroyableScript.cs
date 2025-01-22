using UnityEngine;
public class DontDestroyableScript : MonoBehaviour
{
    private void Awake() => DontDestroyOnLoad(this.gameObject);
}
