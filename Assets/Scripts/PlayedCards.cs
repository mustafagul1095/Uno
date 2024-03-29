using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayedCards : MonoBehaviour
{
    [SerializeField] private DeckInstantiater _deckInstantiater;

    private CardColor _cardColor;
    private CardValue _cardValue;
    private int _cardsToDrawForPass = 1;
    private bool _played = false;
    
    public int GetCardsToDrawForPass()
    {
        return _cardsToDrawForPass;
    }

    public void SetCardsToDrawForPass(int cardsToDraw)
    {
        _cardsToDrawForPass = cardsToDraw;
    }
    
    public void SetLastPlayedCardValue(CardValue cardValue)
    {
        _cardValue = cardValue; 
    }
    
    public void SetLastPlayedCardColor(CardColor cardColor)
    {
        _cardColor = cardColor;
    }

    public CardColor GetCardColor()
    {
        return _cardColor;
    }
    
    public CardValue GetCardValue()
    {
        return _cardValue;
    }

    public bool GetPlayed()
    {
        return _played;
    }

    public void SetPlayed(bool isPlayed)
    {
        _played = isPlayed;
    }
    public void InstantiatePlayedCard()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);
        Instantiate(_deckInstantiater.prefabByCardColorValue[Card.GetCardColorValue(_cardValue, _cardColor)], Vector3.zero, Quaternion.Euler(new Vector3(90,180,180)),transform);
    }
}
