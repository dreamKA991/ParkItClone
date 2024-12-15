using UnityEngine;

public class SwipeCamera : MonoBehaviour
{
    public void SetPosition()
    {
        transform.position = Input.mousePosition;
        Debug.Log("Script SwipeCamera, method SetPosition()");
    }
}
