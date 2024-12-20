using UnityEngine;

public class PlatformChecker : MonoBehaviour
{
    [SerializeField] private bool _useTouchControls;

    public void FindAllCarControllersAndToggleInputButtons()
    {
        CarController[] carControllers = Object.FindObjectsOfType<CarController>();

        foreach (CarController controller in carControllers)
        {
            controller.ToggleInputControls();
        }
    }
}
