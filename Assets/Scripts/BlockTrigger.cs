using UnityEngine;

public class BlockTrigger : MonoBehaviour
{
    public bool isBlocked = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground") return;
        else isBlocked = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isBlocked = false;
    }
}
