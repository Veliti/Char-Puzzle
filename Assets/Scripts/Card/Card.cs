using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class Card : MonoBehaviour
{
    protected Level _level;
    protected CardData _cardData;
    protected bool _isInteractable = true;

    public Card Init(CardData cardData, Level level)
    {
        _cardData = cardData;
        _level = level;
        VisualizeCard();
        return this;
    }
    public abstract void Interact();

    private void VisualizeCard()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _cardData.Sprite;
    }
    protected void SetInteractable(bool value) => _isInteractable = value;
}
