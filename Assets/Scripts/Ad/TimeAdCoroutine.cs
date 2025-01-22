using System.Collections;
using UnityEngine;

public class TimeAdCoroutine : MonoBehaviour
{
    [SerializeField] private float interval = 120f; 
    private InterstitialReclam interstitialReclam;

    private void Start()
    {
        interstitialReclam = new InterstitialReclam();
        interstitialReclam.Init();
        StartCoroutine(ExecuteRepeatedly());
    }

    private IEnumerator ExecuteRepeatedly()
    {
        yield return new WaitForSeconds(interval);

        while (true)
        {
            interstitialReclam.Show(); 
            yield return new WaitForSeconds(interval);
        }
    }
}
