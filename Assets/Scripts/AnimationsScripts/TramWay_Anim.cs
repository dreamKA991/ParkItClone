using DG.Tweening;
using UnityEngine;

public class TramWay_Anim : MonoBehaviour {
    void Start() => transform.DOMoveZ(90f,10f).SetLoops(-1, LoopType.Yoyo).SetDelay(5f); }
