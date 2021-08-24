using UnityEngine;

[RequireComponent(typeof(WiggleTween))]
public class LosingCard : Card
{
    private WiggleTween _wiggle;

    private void Awake() => _wiggle = GetComponent<WiggleTween>();

    public override void Interact()
    {
        if(_isInteractable)
            _wiggle.Wiggle();
    }

#if UNITY_EDITOR
    public void OnButton() => _wiggle.Wiggle();
#endif
}
