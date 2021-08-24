using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FadeTween : MonoBehaviour
{
    public Tween Tween { get; private set; }

    [SerializeField, Range(0f, 1f)]
    private float _maxTransparency = 1f;
    [SerializeField, Range(0f, 1f)]
    private float _minTransparency = 0f;
    [SerializeField]
    private float _duration;

    private Image _image;

    private void Awake() => _image = GetComponent<Image>();

    public async Task FadeIn() => await Fade(_maxTransparency);
    public async Task FadeOut() => await Fade(_minTransparency);

    private async Task Fade(float target)
    {
        Tween?.Kill(complete: true);
        await _image.DOFade(target, _duration).AsyncWaitForCompletion();
    }

    private void OnDisable() => Tween?.Kill();
}
