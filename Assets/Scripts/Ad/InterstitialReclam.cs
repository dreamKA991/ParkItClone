using GoogleMobileAds.Api;
public class InterstitialReclam
{
    private InterstitialAd interstitial;
    private const string adUnitId = "ca-app-pub-3940256099942544/1033173712"; // TEST ID NOW, CHANGE IT SYKA
    public void Init()
    {
        interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }
    public void Show()
    {
        if(interstitial.IsLoaded()) interstitial.Show();
    }
}
