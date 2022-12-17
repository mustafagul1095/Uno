using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Card> playerHand;
    [SerializeField] private DeckInstantiater deckInstantiater;
    [SerializeField] private PlayedCards playedCard;
    [SerializeField] private Canvas playerPassTurnCanvas;
    [SerializeField] private Canvas changeColorCanvas;

    private bool _playerActive = false;
    private bool cantPlayCard = false;
    private Camera _camera;

    private void Awake()
    {
        deckInstantiater = FindObjectOfType<DeckInstantiater>();
        playedCard = FindObjectOfType<PlayedCards>();
    }

    private void Start()
    {
        _camera = Camera.main;
        deckInstantiater.EnableDeckClick();
    }

    private void Update()
    {
        DetectSelectionWithRaycast();
    }

    public void Pass()
    {
        SendMessageUpwards("Played",SendMessageOptions.DontRequireReceiver);
        playerPassTurnCanvas.enabled = false;
        changeColorCanvas.enabled = false;
        cantPlayCard = false;
    }
    private void Played()
    {
        SetPlayerActive(false);
        PlaceHand();
        HideHand();
        deckInstantiater.EnableDeckClick();
    }
    private void DetectSelectionWithRaycast()
    {
        if (Input.GetMouseButtonUp(0) && _playerActive)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (Math.Abs(hit.collider.gameObject.transform.position.x - deckInstantiater.transform.position.x) < 0.00001 &&
                    Math.Abs(hit.collider.gameObject.transform.position.z - deckInstantiater.transform.position.z) < 0.00001 )
                {
                    DrawCardFromDeck();
                    if (playedCard.GetCardsToDrawForPass() < 1)
                    {
                        playerPassTurnCanvas.enabled = true;
                        if (!cantPlayCard)
                        {
                            DisplayHand();
                            ActivateCards();
                        }
                        else
                        {
                            DeactivateCards();
                        }
                    }
                    else
                    {
                        deckInstantiater.EnableDeckClick();
                        DeactivateCards();
                    }
                }
                else
                {
                    playedCard.SetLastPlayedCardColor(hit.collider.gameObject.GetComponent<Card>().GetCardColor());
                    playedCard.SetLastPlayedCardValue(hit.collider.gameObject.GetComponent<Card>().GetCardValue());
                    playedCard.InstantiatePlayedCard();
                    playerHand.Remove(hit.collider.gameObject.GetComponent<Card>());
                    Destroy(hit.collider.gameObject);
                    PlaceHand();
                    if (playedCard.GetCardValue() == CardValue.Reverse)
                    {
                        ReverseCardPlayed();
                        Pass();
                    }
                    else if (playedCard.GetCardColor() == CardColor.None)
                    {
                        if (playedCard.GetCardValue() == CardValue.ChangeColor)
                        {
                            ChangeColorPlayed();
                        }

                        if (playedCard.GetCardValue() == CardValue.PlusFour)
                        {
                            PlusFourPlayed();
                        }
                    }
                    else if (playedCard.GetCardValue() == CardValue.Pass)
                    {
                        PassTurnPlayed();
                        Pass();
                    }
                    else
                    {
                        Pass();
                    }

                }
            }
        }
    }
    public void SetPlayerActive(bool isPlayerActive)
    {
        _playerActive = isPlayerActive;
    }

    public bool GetPlayerActive()
    {
        return _playerActive;
    }

    public void SetPlayerHand(List<Card> _playerHand)
    {
        playerHand = _playerHand;
    }

    public List<Card> GetPlayerHand()
    {
        return playerHand;
    }
    
    public bool GetCantPlayCard()
    {
        return cantPlayCard;
    }

    public void SetCantPlayCard(bool cantPlay)
    {
        cantPlayCard = cantPlay;
    }
    
    public void DrawCardFromDeck()
    {
        Card drawnCard = deckInstantiater.DrawCard();
        Card drawnCard1 = Instantiate(drawnCard, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)), transform);
        playerHand.Add(drawnCard1);
        PlaceHand();
        if (!_playerActive)
        {
            HideHand();
        }
        playedCard.SetCardsToDrawForPass(playedCard.GetCardsToDrawForPass()-1);
    }

    public void PlaceHand()
    {
        if(playerHand.Count == 0){return;}

        for (int i = 0; i < playerHand.Count; i++)
        {
            playerHand[i].SetLocalPosition(new Vector3((i-playerHand.Count/2)*0.05f, i*0.0001f, 0));
        }
    }

    public void DisplayHand()
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            playerHand[i].ShowCard();
        }
    }

    public void DisplayWhenPlusFourPlayed()
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            playerHand[i].ShowCard();
            if (playerHand[i].GetCardValue() == CardValue.PlusFour)
            {
                playerHand[i].GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                playerHand[i].GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
    
    public void HideHand()
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            playerHand[i].HideCard();
            playerHand[i].GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void DeactivateCards()
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            playerHand[i].GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void ActivateCards()
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            if (CheckPlayable(playerHand[i]))
            {
                playerHand[i].GetComponent<BoxCollider>().enabled = true;
                playerHand[i].SetLocalPosition(playerHand[i].transform.localPosition + new Vector3(0,0,0.01f));
            }
            else
            {
                playerHand[i].GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    private bool CheckPlayable(Card card)
    {
        if (card.GetCardColor() == CardColor.None)
        {
            return true;
        }
        else
        {
            return (card.GetCardColor() == playedCard.GetCardColor() || card.GetCardValue() == playedCard.GetCardValue());
        }
    }

    private void ReverseCardPlayed()
    {
        SendMessageUpwards("OnReverse", SendMessageOptions.DontRequireReceiver);
    }

    private void PassTurnPlayed()
    {
        SendMessageUpwards("OnPassTurnPlayed", SendMessageOptions.DontRequireReceiver);
    }

    private void PlusFourPlayed()
    {
        ChangeColorPlayed();
        SendMessageUpwards("OnPlusFourPlayed", SendMessageOptions.DontRequireReceiver);
    }

    private void ChangeColorPlayed()
    {
        changeColorCanvas.enabled = true;
        playerPassTurnCanvas.enabled = false;
    }

    public void YellowSelected()
    {
        playedCard.SetLastPlayedCardColor(CardColor.Yellow);
        Pass();
    }
    public void GreenSelected()
    {
        playedCard.SetLastPlayedCardColor(CardColor.Green);
        Pass();
    }
    public void RedSelected()
    {
        playedCard.SetLastPlayedCardColor(CardColor.Red);
        Pass();
    }
    public void BlueSelected()
    {
        playedCard.SetLastPlayedCardColor(CardColor.Blue);
        Pass();
    }
}
