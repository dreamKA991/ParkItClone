using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject buttons1, buttons2;
    [SerializeField] private LevelGrading levelGrading;

    public void PlayButtonClicked()
    {
        buttons1.SetActive(false);
        buttons2.SetActive(true);
    }

    public void BackButtonClicked()
    {
        buttons1.SetActive(true);
        buttons2.SetActive(false);
    }
    
    public void QuitButtonClicked()
    {
        Application.Quit();
    }
    
}
