using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSelectionMenu : MonoBehaviour
{
    [SerializeField] private SpawnManagerScriptableObject carData; // ScriptableObject � ������� � ��������
    [SerializeField] private Transform carDisplayPosition; // �������, ��� ����� ������������ �������
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button okButton;

    private GameObject currentCar; // ������� �������
    private int currentIndex = 0;

    private void Start()
    {
        if (carData.numberOfPrefabsToCreate.Count == 0)
        {
            Debug.LogError("No car prefabs assigned in the ScriptableObject!");
            return;
        }

        ShowCar(currentIndex);

        // ���������� ������
        leftButton.onClick.AddListener(SelectPreviousCar);
        rightButton.onClick.AddListener(SelectNextCar);
        okButton.onClick.AddListener(ConfirmSelection);
    }

    private void ShowCar(int index)
    {
        // ������� ���������� �������
        if (currentCar != null)
            Destroy(currentCar);

        // ������� ����� �������
        currentCar = Instantiate(carData.numberOfPrefabsToCreate[index], carDisplayPosition.position, Quaternion.identity);
        currentCar.transform.SetParent(carDisplayPosition); // ����������� � �������
    }

    private void SelectPreviousCar()
    {
        currentIndex--;
        if (currentIndex < 0) currentIndex = carData.numberOfPrefabsToCreate.Count - 1;

        ShowCar(currentIndex);
    }

    private void SelectNextCar()
    {
        currentIndex++;
        if (currentIndex >= carData.numberOfPrefabsToCreate.Count) currentIndex = 0;

        ShowCar(currentIndex);
    }

    private void ConfirmSelection()
    {
        Debug.Log($"Car {carData.numberOfPrefabsToCreate[currentIndex].name} selected!");
        PlayerPrefs.SetInt("SelectedCar", currentIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Menu");
    }
}
