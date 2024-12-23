using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SelectedCarController : MonoBehaviour, IRestartable
{
    [SerializeField] private List<CarController> carControllers;
    [SerializeField] private CarController selectedCarController;
    private int carIndex = 0;
    [SerializeField] private CameraFlying cameraFlying;

    private void Start()
    {
        carControllers = new List<CarController>(FindObjectsOfType<CarController>());
        selectedCarController = carControllers[carIndex];
        cameraFlying.SetNewTarget(selectedCarController.transform);
        if (carControllers.Count == 1) carIndex = -1;
    }

    public void SelectNext()
    {
        if (carIndex == -1) return;

        carIndex = (carIndex + 1) % carControllers.Count;

        SelectCarByIndex(carIndex);
    }
    public CarController GetSelectedCarController() { return selectedCarController; }
    private void SelectCarByIndex(int index)
    {
        if (index >= 0 && index < carControllers.Count)
        {
            selectedCarController.enabled = false;
            if (selectedCarController.forkliftController != null)
                selectedCarController.forkliftController.enabled = false;

            selectedCarController = carControllers[index];
            selectedCarController.enabled = true;
            CheckUILiftableButtons(selectedCarController);

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
    private void CheckUILiftableButtons(CarController selectedCarController) => UIManager.instance.CheckLiftableButtons(selectedCarController);

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
    private void StopAllCarControllers()
    {
        foreach (var carController in carControllers)
        {
            carController.Restart();
        }
    }
    public void Restart() {
        Start();
        StopAllCarControllers();
    }
}
