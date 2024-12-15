using UnityEngine;
public class LoseByContact : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) =>
        GlobalEventManager.onCharacterTouchedGameObject.Invoke(collision.gameObject);
}
