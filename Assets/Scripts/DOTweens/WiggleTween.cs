using UnityEngine;
using DG.Tweening;

public class WiggleTween : MonoBehaviour
{
    public Tween Tween { get; private set; }

    [SerializeField]
    private Vector3 _diraction;
    [SerializeField]
    private float _strength = 1f;
    [SerializeField]
    private int amountOfWiggles = 4;
    [SerializeField]
    private float _duration = 1f;

    public void Wiggle()
    {
        Tween?.Kill(complete: true);
        Tween = transform.DOLocalMove(_strength * _diraction.normalized, _duration).SetEase(MyWiggleFunk);
    }

    private float MyWiggleFunk(float time, float duration, float overshootOrAmplitude, float period) // no documentation(or it lies), working wrong from 2015
    {
        var t = time/duration;
        return Mathf.Sin(2 * Mathf.PI * amountOfWiggles * t) * t;
    }

    private void OnDisable() => Tween?.Kill();
}
