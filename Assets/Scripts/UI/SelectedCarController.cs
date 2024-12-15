using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SelectedCarController : MonoBehaviour
{
    [SerializeField] private List<CarController> carControllers;
    [SerializeField] private CarController selectedCarController;
    private int carIndex = 0;
    [SerializeField] private CameraFlying cameraFlying;

    private void Start()
    {
        carControllers = new List<CarController>(FindObjectsOfType<CarController>());
        selectedCarController = carControllers[carIndex];
        if (carControllers.Count == 1) carIndex = -1; // если CarController единственный ничего не меняется
    }

    public void SelectNext()
    {
        if (carIndex == -1) return;

        carIndex = (carIndex + 1) % carControllers.Count;

        SelectCarByIndex(carIndex);
    }

    private void SelectCarByIndex(int index)
    {
        if (index >= 0 && index < carControllers.Count)
        {
            selectedCarController.enabled = false;
            if (selectedCarController.forkliftController != null)
                selectedCarController.forkliftController.enabled = false;

            selectedCarController = carControllers[index];
            selectedCarController.enabled = true;

            if (selectedCarController.forkliftController != null)
                selectedCarController.forkliftController.enabled = true;

            cameraFlying.SetNewTarget(selectedCarController.transform);
            Debug.Log($"Selected car: {selectedCarController.name}");
        }
        else
        {
            Debug.LogError("Invalid index selected!");
        }
    }

    public void SelectCarByName(string _name)
    {
        var car = carControllers.FirstOrDefault(x => x.gameObject.name == _name);
        if (car != null)
        {
            int index = carControllers.IndexOf(car);
            SelectCarByIndex(index);
        }
        else
        {
            Debug.LogError($"Car with name {_name} not found!");
        }
    }
}
