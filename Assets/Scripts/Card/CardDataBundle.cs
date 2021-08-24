using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CardBundle")]
public class CardDataBundle : ScriptableObject
{
    public CardData[] CardBundle => _cardBundle;

    [SerializeField]
    private CardData[] _cardBundle;
}
