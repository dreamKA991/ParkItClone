using UnityEngine;
[SelectionBase]
public class LoseByContact : MonoBehaviour {
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.layer == collision.gameObject.layer) return; // if forklift car == car to park layers
        GlobalEventManager.onCharacterTouchedGameObject.Invoke(collision.gameObject);
    }
}
