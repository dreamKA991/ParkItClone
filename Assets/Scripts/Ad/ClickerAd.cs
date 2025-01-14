using UnityEngine;

public class ClickerAd : MonoBehaviour
{
    private InterstitialReclam interstitialReclam;
    private int times = 1;
    private int period = 2;
    private void Start()
    {
        interstitialReclam = new InterstitialReclam();
    }

    public void Click()
    {
        if(times < period) times++;
        else
        {
            interstitialReclam.Init();
            interstitialReclam.Show();
            times = 0;
        }
    }
}
