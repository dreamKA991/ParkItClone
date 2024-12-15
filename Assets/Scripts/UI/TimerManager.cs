using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TimerCoroutine))]
public class TimerManager : MonoBehaviour
{
    private int seconds, minutes;
    [SerializeField] Text timerText;
    private void Start()
    {
        if (timerText == null) timerText.GetComponent<Text>();
    }

    public void AddSecond() {
        if (seconds + 1 == 60)
        {
            seconds = 0;
            minutes++;
        }
        else seconds++;
        UpdateText();
    }
    private void UpdateText()
    {
        timerText.text = $"{minutes}:{seconds:D2}";
    }
    public int GetTimeInSeconds() {
        return (minutes * 60) + seconds;
    }
}
