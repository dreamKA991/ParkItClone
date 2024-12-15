using System;
using UnityEngine;
using UnityEngine.UI;

public class DrawDistance : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private Slider slider;

    private void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found.");
            return;
        }

        if (slider == null)
        {
            Debug.LogError("Slider is not assigned in the inspector.");
            return;
        }

        int drawDistance = PlayerPrefs.GetInt("DrawDistance", 100);
        SetDrawDistance(drawDistance);

        slider.onValueChanged.AddListener(OnValueChanged);
    }

    private void SetDrawDistance(int drawDistance)
    {
        if (mainCamera != null)
        {
            mainCamera.farClipPlane = drawDistance;
        }

        if (slider != null)
        {
            slider.value = drawDistance;
        }

        PlayerPrefs.SetInt("DrawDistance", drawDistance);
        PlayerPrefs.Save();
    }

    private void OnValueChanged(float value) => SetDrawDistance(Convert.ToInt32(value));
}
