using UnityEngine;
using DG.Tweening;

public class BounceTween : MonoBehaviour
{
    public Tween Tween { get; private set; }

    [SerializeField]
    private float _overshoot = 1.2f;
    [SerializeField]
    private float _bounceback = .96f;
    [SerializeField]
    private float _duration = 1f;

    public void Bounce() //Ease.Elastic ?
    {
        Tween?.Kill(complete: true);
            
        var _subDuration = _duration / 4f;
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(0, 0));
        sequence.Append(transform.DOScale(_overshoot, _subDuration));
        sequence.Append(transform.DOScale(_bounceback, _subDuration));
        sequence.Append(transform.DOScale(1f, _subDuration));
        Tween = sequence;
    }

    private void OnDisable() => Tween?.Kill();
}
