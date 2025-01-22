using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SelectedCarController : MonoBehaviour, IRestartable
{
    [SerializeField] private List<CarController> carControllers;
    [SerializeField] private CarController selectedCarController;
    private int carIndex;
    private bool soloCarController;
    [SerializeField] private CameraFlying cameraFlying;

    private void Start()
    {
        if (carControllers.Count == 1) soloCarController = true; // break logic cause only one carController on scene
        carIndex = 0;
        GlobalEventManager.onRestart.AddListener(Restart);
        carControllers = new List<CarController>(FindObjectsOfType<CarController>());
        SelectCarByIndex(carIndex);
        cameraFlying.SetNewTarget(selectedCarController.transform);
    }

    public void SelectNext()
    {
        if (soloCarController) return;

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
