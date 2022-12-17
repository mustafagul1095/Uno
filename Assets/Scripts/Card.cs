using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardValue{One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Reverse, Pass, ChangeColor, PlusTwo, PlusFour }
public enum CardColor{Red, Green, Blue, Yellow, None}
public enum CardColorValue{RedOne, RedTwo, RedThree, RedFour, RedFive, RedSix, RedSeven, RedEight, RedNine, RedReverse, RedPass, RedPlusTwo, 
    GreenOne, GreenTwo, GreenThree, GreenFour, GreenFive, GreenSix, GreenSeven, GreenEight, GreenNine, GreenReverse, GreenPass, GreenPlusTwo,
    BlueOne, BlueTwo, BlueThree, BlueFour, BlueFive, BlueSix, BlueSeven, BlueEight, BlueNine, BlueReverse, BluePass, BluePlusTwo,
    YellowOne, YellowTwo, YellowThree, YellowFour, YellowFive, YellowSix, YellowSeven, YellowEight, YellowNine, YellowReverse, YellowPass, YellowPlusTwo,
    ChangeColor, PlusFour,None};

public class Card : MonoBehaviour
{
    
    [SerializeField] private CardValue cardValue;
    [SerializeField] private CardColor cardColor;
    
    public CardColorValue CardColorValue
    {
        get
        {
            return GetCardColorValue(cardValue, cardColor);
        }
    }

    public static CardColorValue GetCardColorValue(CardValue cardValue, CardColor cardColor)
    {
        if (cardColor == CardColor.Red)
        {
            if (cardValue == CardValue.One)
            {
                return CardColorValue.RedOne;
            }
            if (cardValue == CardValue.Two)
            {
                return CardColorValue.RedTwo;
            }
            if (cardValue == CardValue.Three)
            {
                return CardColorValue.RedThree;
            }
            if (cardValue == CardValue.Four)
            {
                return CardColorValue.RedFour;
            }
            if (cardValue == CardValue.Five)
            {
                return CardColorValue.RedFive;
            }
            if (cardValue == CardValue.Six)
            {
                return CardColorValue.RedSix;
            }
            if (cardValue == CardValue.Seven)
            {
                return CardColorValue.RedSeven;
            }
            if (cardValue == CardValue.Eight)
            {
                return CardColorValue.RedEight;
            }
            if (cardValue == CardValue.Nine)
            {
                return CardColorValue.RedNine;
            }
            if (cardValue == CardValue.Reverse)
            {
                return CardColorValue.RedReverse;
            }
            if (cardValue == CardValue.Pass)
            {
                return CardColorValue.RedPass;
            }
            if (cardValue == CardValue.PlusTwo)
            {
                return CardColorValue.RedPlusTwo;
            }
        }
        else if (cardColor == CardColor.Green)
        {
            if (cardValue == CardValue.One)
            {
                return CardColorValue.GreenOne;
            }
            if (cardValue == CardValue.Two)
            {
                return CardColorValue.GreenTwo;
            }
            if (cardValue == CardValue.Three)
            {
                return CardColorValue.GreenThree;
            }
            if (cardValue == CardValue.Four)
            {
                return CardColorValue.GreenFour;
            }
            if (cardValue == CardValue.Five)
            {
                return CardColorValue.GreenFive;
            }
            if (cardValue == CardValue.Six)
            {
                return CardColorValue.GreenSix;
            }
            if (cardValue == CardValue.Seven)
            {
                return CardColorValue.GreenSeven;
            }
            if (cardValue == CardValue.Eight)
            {
                return CardColorValue.GreenEight;
            }
            if (cardValue == CardValue.Nine)
            {
                return CardColorValue.GreenNine;
            }
            if (cardValue == CardValue.Reverse)
            {
                return CardColorValue.GreenReverse;
            }
            if (cardValue == CardValue.Pass)
            {
                return CardColorValue.GreenPass;
            }
            if (cardValue == CardValue.PlusTwo)
            {
                return CardColorValue.GreenPlusTwo;
            }
        }
        else if (cardColor == CardColor.Blue)
        {
            if (cardValue == CardValue.One)
            {
                return CardColorValue.BlueOne;
            }
            if (cardValue == CardValue.Two)
            {
                return CardColorValue.BlueTwo;
            }
            if (cardValue == CardValue.Three)
            {
                return CardColorValue.BlueThree;
            }
            if (cardValue == CardValue.Four)
            {
                return CardColorValue.BlueFour;
            }
            if (cardValue == CardValue.Five)
            {
                return CardColorValue.BlueFive;
            }
            if (cardValue == CardValue.Six)
            {
                return CardColorValue.BlueSix;
            }
            if (cardValue == CardValue.Seven)
            {
                return CardColorValue.BlueSeven;
            }
            if (cardValue == CardValue.Eight)
            {
                return CardColorValue.BlueEight;
            }
            if (cardValue == CardValue.Nine)
            {
                return CardColorValue.BlueNine;
            }
            if (cardValue == CardValue.Reverse)
            {
                return CardColorValue.BlueReverse;
            }
            if (cardValue == CardValue.Pass)
            {
                return CardColorValue.BluePass;
            }
            if (cardValue == CardValue.PlusTwo)
            {
                return CardColorValue.BluePlusTwo;
            }
        }
        else if (cardColor == CardColor.Yellow)
        {
            if (cardValue == CardValue.One)
            {
                return CardColorValue.YellowOne;
            }
            if (cardValue == CardValue.Two)
            {
                return CardColorValue.YellowTwo;
            }
            if (cardValue == CardValue.Three)
            {
                return CardColorValue.YellowThree;
            }
            if (cardValue == CardValue.Four)
            {
                return CardColorValue.YellowFour;
            }
            if (cardValue == CardValue.Five)
            {
                return CardColorValue.YellowFive;
            }
            if (cardValue == CardValue.Six)
            {
                return CardColorValue.YellowSix;
            }
            if (cardValue == CardValue.Seven)
            {
                return CardColorValue.YellowSeven;
            }
            if (cardValue == CardValue.Eight)
            {
                return CardColorValue.YellowEight;
            }
            if (cardValue == CardValue.Nine)
            {
                return CardColorValue.YellowNine;
            }
            if (cardValue == CardValue.Reverse)
            {
                return CardColorValue.YellowReverse;
            }
            if (cardValue == CardValue.Pass)
            {
                return CardColorValue.YellowPass;
            }
            if (cardValue == CardValue.PlusTwo)
            {
                return CardColorValue.YellowPlusTwo;
            }
        }
        else if (cardColor == CardColor.None)
        {
            if (cardValue == CardValue.ChangeColor)
            {
                return CardColorValue.ChangeColor;
            }
            if (cardValue == CardValue.PlusFour)
            {
                return CardColorValue.PlusFour;
            }
        }
        return CardColorValue.None;
        
    }
    
    
    public CardValue GetCardValue()
    {
        return cardValue;
    }
    public CardColor GetCardColor()
    {
        return cardColor;
    }
    
    public void SetCardValue(CardValue _cardValue)
    {
        cardValue = _cardValue;
    }

    public void SetCardColor(CardColor _cardColor)
    {
        cardColor = _cardColor;
    }
    
    public void SetLocalPosition(Vector3 position)
    {
        transform.localPosition = position;
    }

    public void ShowCard()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(90,180,180));
    }

    public void HideCard()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(-90,0,180));
    }
    
}
