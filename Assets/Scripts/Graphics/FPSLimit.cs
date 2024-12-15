using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSLimit : MonoBehaviour
{
    [SerializeField] private Dropdown dropDown;
    private int fpsLimit;

    private void Start()
    {
        fpsLimit = PlayerPrefs.GetInt("FPSLimit", 60);
        SetFPSLimit(fpsLimit);
        Debug.Log("Start: fpsLimit " + fpsLimit);
        List<Dropdown.OptionData> dropDownOptions = dropDown.options;
        foreach (var option in dropDownOptions)
        {
            if (option.text == fpsLimit.ToString())
            {
                dropDown.value = dropDownOptions.IndexOf(option);
                break;
            }
        }
    }

    public void SwitchFPSLimit(int FrameRate)
    {
        switch (FrameRate)
        {
            case 0: SetFPSLimit(50); break;
            case 1: SetFPSLimit(30); break;
            case 2: SetFPSLimit(24); break;
            case 3: SetFPSLimit(fpsLimit); break;
        }
    }

    private void SetFPSLimit(int FrameRate)
    {
        Debug.Log("SetFPSLimit: FrameRate " + FrameRate);
        Application.targetFrameRate = FrameRate;
        PlayerPrefs.SetInt("FPSLimit", FrameRate);
        fpsLimit = FrameRate;
        PlayerPrefs.Save(); 
    }
    public void SetFPSByDefault() => SwitchFPSLimit(3);
}
