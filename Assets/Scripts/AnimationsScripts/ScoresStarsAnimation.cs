using UnityEngine;
using DG.Tweening;

public class ScoresStarsAnimation : MonoBehaviour
{
    [SerializeField] private Transform leftStar, middleStar, rightStar;

    public void DoAnimationStars(int grading)
    {
        if (grading >= 1) AnimateStar(leftStar, 0f);
        if (grading >= 2) AnimateStar(middleStar, 0.5f);
        if (grading >= 3) AnimateStar(rightStar, 1f);   
    }

    private void AnimateStar(Transform star, float delay)
    {
        Sequence starSequence = DOTween.Sequence();
        starSequence.AppendInterval(delay);
        starSequence.Append(star.DOScale(40f, 0.3f).SetEase(Ease.OutBack));

        starSequence.Join(star.DOMoveY(750f, 0.3f).SetEase(Ease.OutQuad));
        starSequence.Append(star.DOScale(20f, 0.7f).SetEase(Ease.InBack));
    }
}
