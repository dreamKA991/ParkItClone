using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSelectionMenu : MonoBehaviour
{
    [SerializeField] private SpawnManagerScriptableObject carData; // ScriptableObject с данными о машинках
    [SerializeField] private Transform carDisplayPosition; // Позиция, где будет отображаться машинка
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button okButton;

    private GameObject currentCar; // Текущая машинка
    private int currentIndex = 0;

    private void Start()
    {
        if (carData.numberOfPrefabsToCreate.Count == 0)
        {
            Debug.LogError("No car prefabs assigned in the ScriptableObject!");
            return;
        }

        ShowCar(currentIndex);

        // Подключаем кнопки
        leftButton.onClick.AddListener(SelectPreviousCar);
        rightButton.onClick.AddListener(SelectNextCar);
        okButton.onClick.AddListener(ConfirmSelection);
    }

    private void ShowCar(int index)
    {
        // Удаляем предыдущую машинку
        if (currentCar != null)
            Destroy(currentCar);

        // Создаем новую машинку
        currentCar = Instantiate(carData.numberOfPrefabsToCreate[index], carDisplayPosition.position, Quaternion.identity);
        currentCar.transform.SetParent(carDisplayPosition); // Прикрепляем к позиции
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
