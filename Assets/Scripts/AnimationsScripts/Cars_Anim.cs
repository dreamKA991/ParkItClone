using DG.Tweening;
using UnityEngine;

public class Cars_Anim : MonoBehaviour {
    [SerializeField] private float destinatonX;
    [SerializeField] private float delay;
    void Start() => transform.DOMoveX(destinatonX, 10f).SetLoops(-1, LoopType.Restart).SetDelay(delay); }
