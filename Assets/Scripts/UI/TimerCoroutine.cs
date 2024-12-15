using UnityEngine;
using System.Collections;

public class TimerCoroutine : MonoBehaviour
{
    [SerializeField] private TimerManager timerManager;

    void Start() { 
        StartCoroutine(TimerRoutine());
        if(timerManager == null) timerManager.GetComponent<TimerManager>();
    }

    IEnumerator TimerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            timerManager.AddSecond();
        }
    }
}
