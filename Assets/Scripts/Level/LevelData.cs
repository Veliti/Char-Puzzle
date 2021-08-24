using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public CardDataBundle CardBundle => _cardBundle;
    public int CardsOnLevel => _cardsOnLevel;

    [SerializeField]
    private CardDataBundle _cardBundle;
    [SerializeField]
    private int _cardsOnLevel;

}
