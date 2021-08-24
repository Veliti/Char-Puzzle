using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private ClickableCell _cellPrefab;
    [SerializeField]
    private Card _winningCardPrefab;
    [SerializeField]
    private Card _losingCardPrefab;

    private List<CardData> _usedCorrectCards = new List<CardData>();

    public GameObject[] GenerateCards(LevelData levelData, Level level)
    {
        var cards = new List<GameObject>(levelData.CardsOnLevel);
        (var cardDataArray, int winningIndex) = GetRandomCardData(levelData);
        for (int i = 0; i < cardDataArray.Count; i++)
        {
            if(i != winningIndex)
            {
                var card = Instantiate<Card>(_losingCardPrefab).Init(cardDataArray[i], level);
                var cell = Instantiate<ClickableCell>(_cellPrefab);
                card.transform.parent = cell.transform;
                cell.OnClicked += card.Interact;
                cards.Add(cell.gameObject);
            }
            else
            {
                var card = Instantiate<Card>(_winningCardPrefab).Init(cardDataArray[i], level);
                var cell = Instantiate<ClickableCell>(_cellPrefab);
                card.transform.parent = cell.transform;
                cell.OnClicked += card.Interact;
                cards.Add(cell.gameObject);
            }
        }
        return cards.ToArray();
    }

    private (List<CardData> array, int winningCardIndex) GetRandomCardData(LevelData levelData)
    {
        var cardData = new List<CardData>();
        var availableCardData = new List<CardData>(levelData.CardBundle.CardBundle);

        var winningCards = availableCardData.Except(_usedCorrectCards); // :(
        var winningCard = availableCardData[Random.Range(0, winningCards.Count())];
        availableCardData.Remove(winningCard);

        for (int i = 0; i < levelData.CardsOnLevel - 1; i++)
        {
            var index = Random.Range(0, availableCardData.Count);
            cardData.Add(availableCardData[index]);
            availableCardData.RemoveAt(index);
        }

        int winningCardIndex = Random.Range(0, cardData.Count + 1);
        cardData.Insert(winningCardIndex, winningCard);

        return (cardData, winningCardIndex) ;
    }

}