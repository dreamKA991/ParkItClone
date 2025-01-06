using UnityEngine;

public class SpawnMainCar : MonoBehaviour
{
    [SerializeField] private SpawnManagerScriptableObject carData;
    [SerializeField] private Transform carSpawnPosition;
    [SerializeField] private CameraFlying cameraFlying;
    [SerializeField] private SelectedCarController carController;
    private GameObject currentCar;
    void Awake()
    {
        int index = PlayerPrefs.GetInt("SelectedCar", 0);
        Debug.Log("SpawnMainCar Car index: " + index);
        currentCar = Instantiate(carData.numberOfPrefabsToCreate[index], carSpawnPosition.position, Quaternion.identity);
        currentCar.layer = 6; // CAR
        currentCar.tag = "Player";
        cameraFlying.SetNewTarget(currentCar.transform);
    }
    private void Start() =>
        carController.SelectCarByName(currentCar.name);
}
