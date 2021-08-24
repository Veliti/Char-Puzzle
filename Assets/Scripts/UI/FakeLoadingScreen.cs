using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(FadeTween))]
public class FakeLoadingScreen : MonoBehaviour
{
    private FadeTween _fadeTween;

    private void Awake() => _fadeTween = GetComponent<FadeTween>();

    public void FadeIn(List<Task> tasks) => tasks.Add(_fadeTween.FadeIn());
    public void FadeOut(List<Task> tasks) => tasks.Add(_fadeTween.FadeOut());
}
