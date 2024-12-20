using UnityEngine;

public class BlockTrigger : MonoBehaviour
{
    public bool isBlocked = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground" || other.tag == "Player") return;
        else isBlocked = true;
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        isBlocked = false;
    }
}
