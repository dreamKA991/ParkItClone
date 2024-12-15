using DG.Tweening;
using UnityEngine;

public class PlaneLightAdvice : MonoBehaviour
{
    private Material material;
    private float duration = 0.7f;
    private float endValue = 0.3f;
    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.DOFade(endValue, duration).SetLoops(-1,LoopType.Yoyo);
    }
}
