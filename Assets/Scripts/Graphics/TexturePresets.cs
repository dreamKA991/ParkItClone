using UnityEngine;
using UnityEngine.UI;

public class TexturePresets : MonoBehaviour
{
    [SerializeField] private Dropdown dropDown;
    [SerializeField] private FPSLimit fpsLimit;
    [SerializeField] private GameObject ListOutsideObjects;
    private void Start()
    {
        int texturePreset = PlayerPrefs.GetInt("texturePreset", 0);
        ApplyGraphicsSettings(texturePreset);

        dropDown.onValueChanged.RemoveListener(OnDropdownValueChanged); 
        dropDown.value = texturePreset; 
        dropDown.onValueChanged.AddListener(OnDropdownValueChanged); 
    }

    private void OnDropdownValueChanged(int index)
    {
        ApplyGraphicsSettings(index);

        PlayerPrefs.SetInt("texturePreset", index);
        PlayerPrefs.Save();
    }

    private void ApplyGraphicsSettings(int preset)
    {
        switch (preset)
        {
            case 0:
                QualitySettings.lodBias = 1;
                QualitySettings.maximumLODLevel = 0;
                ListOutsideObjects.active = true;
                Debug.Log("High Graphics Settings Applied");
                break;
            case 1:
                QualitySettings.lodBias = 1;
                QualitySettings.maximumLODLevel = 1;
                ListOutsideObjects.active = true;
                Debug.Log("Medium Graphics Settings Applied");
                break;
            case 2:
                QualitySettings.lodBias = 0;
                ListOutsideObjects.active = false;
                Debug.Log("Low Graphics Settings Applied");
                break;
            default:
                Debug.LogWarning("Unknown Graphics Preset!");
                break;
        }
        fpsLimit.SetFPSByDefault();
    }
}
