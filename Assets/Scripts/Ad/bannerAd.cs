using GoogleMobileAds.Api;
using System.Collections;
using UnityEngine;

public class BannerAd : MonoBehaviour
{
    [SerializeField] AdPosition adPosition = AdPosition.Top;
    private BannerView bannerView;
#if UNITY_ANDROID
    private const string bannerUnitId =  "ca-app-pub-3940256099942544/9214589741"; // TEST BANNER AD ID
#else
    private const string bannerUnitId = "";
#endif
    private void Start()
    {
        if(adPosition == AdPosition.Top) bannerView = new BannerView(bannerUnitId, AdSize.Banner, adPosition);
        else bannerView = new BannerView(bannerUnitId, AdSize.SmartBanner, adPosition);

        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }
    public void OnMenuLoaded()
    {
        bannerView = new BannerView(bannerUnitId, AdSize.SmartBanner, adPosition);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
        StartCoroutine(ShowBanner());
    }

    public IEnumerator ShowBanner()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        bannerView.Show();
    }

    public void HideBanner()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
            bannerView = null;
        }
    }

    private void OnDisable() => HideBanner();
}
