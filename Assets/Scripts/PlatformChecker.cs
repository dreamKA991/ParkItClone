using UnityEngine;

public class PlatformChecker : MonoBehaviour
{
    [SerializeField] public bool isMobile { get; private set; }
    private void Start()
    {
        bool isMobile = IsMobilePlatform();
    }

    public bool IsMobilePlatform()
    {
        return Application.isMobilePlatform;
    }
}
