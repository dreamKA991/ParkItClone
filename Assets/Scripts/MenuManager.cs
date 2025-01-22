using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject buttons1, buttons2, buttons3;
    [SerializeField] private LevelGrading levelGrading;

    public void PlayButtonClicked()
    {
        buttons1.SetActive(false);
        buttons2.SetActive(true);
        buttons3.SetActive(false);
    }

    public void BackButtonClicked()
    {
        buttons1.SetActive(true);
        buttons2.SetActive(false);
        buttons3.SetActive(false);
    }
    
    public void QuitButtonClicked()
    {
        Application.Quit();
    }
    public void LicensesButtonClicked()
    {
        buttons1.SetActive(false);
        buttons2.SetActive(false);
        buttons3.SetActive(true);
    }
}
