using UnityEngine;
using UnityEngine.UI;

public class TimeFinished : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void UpdateTimeTextOnFinish(int seconds)
    {
        int timeInSeconds = Mathf.Max(0, seconds);
        int _minutes = timeInSeconds / 60;
        int _seconds = timeInSeconds % 60;
        _text.text = $"Your time: {_minutes}:{_seconds:D2}";
    }
}
