using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardValue{One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Reverse, Pass, ChangeColor, PlusTwo, PlusFour }
public enum CardColor{Red, Green, Blue, Yellow, None}
public class CardProperties : MonoBehaviour
{
    [SerializeField] public CardValue cardValue;
    [SerializeField] public CardColor cardColor;

    public CardValue GetCardValue()
    {
        return cardValue;
    }
    public CardColor GetCardColor()
    {
        return cardColor;
    }
}
