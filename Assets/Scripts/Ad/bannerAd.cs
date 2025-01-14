using GoogleMobileAds.Api;
using System.Collections;
using UnityEngine;

public class bannerAd : MonoBehaviour
{
    private BannerView bannerView;
#if UNITY_ANDROID
    private const string bannerUnitId = "ca-app-pub-3940256099942544/6300978111"; // TEST ID NOW, CHANGE IT SYKA
#else
    private const string bannerUnitId = "";
#endif

    private void OnEnable()
    {
        bannerView = new BannerView(bannerUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
        StartCoroutine(ShowBanner());
    }

    IEnumerator ShowBanner()
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
