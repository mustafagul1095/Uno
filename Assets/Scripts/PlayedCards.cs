using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayedCards : MonoBehaviour
{
    
    [SerializeField] private DeckInstantiater _deckInstantiater;

    private CardColor _cardColor;
    private CardValue _cardValue;
    
    
    public void SetLastPlayedCardValue(CardValue cardValue)
    {
        _cardValue =cardValue; 
    }
    
    public void SetLastPlayedCardColor(CardColor cardColor)
    {
        _cardColor = cardColor;
    }

    public void InstantiatePlayedCard()
    {
        Instantiate(_deckInstantiater.prefabByCardColorValue[Card.GetCardColorValue(_cardValue, _cardColor)], Vector3.zero, Quaternion.Euler(new Vector3(90,180,180)),transform);
    }
}
