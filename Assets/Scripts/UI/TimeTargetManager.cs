using UnityEngine;
using UnityEngine.UI;

public class TimeTargetManager : MonoBehaviour
{
    [SerializeField] private int firstPlaceTime, secondPlaceTime, thirdPlaceTime;
    [SerializeField] private Text[] firstPlacesText = new Text[TEXTSAMOUNT], secondPlacesText = new Text[TEXTSAMOUNT], thirdPlacesText = new Text[TEXTSAMOUNT];
    private const int TEXTSAMOUNT = 2;

    public void UpdateTimeTargets()
    {
        Debug.Log("UpdateTimeTargets()");
        for (int i = 0; i < TEXTSAMOUNT; i++)
        {
            firstPlacesText[i].text = GetTimeTextFromInt(firstPlaceTime);
            secondPlacesText[i].text = GetTimeTextFromInt(secondPlaceTime);
            thirdPlacesText[i].text = GetTimeTextFromInt(thirdPlaceTime);
        }
    }

    private string GetTimeTextFromInt(int _timeSeconds)
    {
        int minutes = _timeSeconds / 60;
        int seconds = _timeSeconds % 60;

        return $"{minutes}:{seconds:D2}";
    }
    public int GetGrade(int time) {
        if (time <= firstPlaceTime) return 3;
        if(time <= secondPlaceTime) return 2;
        if (time <= thirdPlaceTime) return 1;
        else return 0;
    }
}
