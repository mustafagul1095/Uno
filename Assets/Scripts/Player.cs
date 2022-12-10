using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Card> playerHand;
    [SerializeField] private DeckInstantiater deckInstantiater;
    [SerializeField] private PlayedCards playedCard;

    private bool _playerActive = false;
    private Camera _camera;

    private void Awake()
    {
        deckInstantiater = FindObjectOfType<DeckInstantiater>();
        playedCard = FindObjectOfType<PlayedCards>();
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (_playerActive)
        {
            DetectSelectionWithRaycast();
        }
    }

    private void DetectSelectionWithRaycast()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                playedCard.SetLastPlayedCardColor(hit.collider.gameObject.GetComponent<Card>().GetCardColor());
                playedCard.SetLastPlayedCardValue(hit.collider.gameObject.GetComponent<Card>().GetCardValue());
                playedCard.InstantiatePlayedCard();
                Destroy(hit.collider.gameObject);
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
    
    public void DrawCardFromDeck()
    {
        Card drawnCard = deckInstantiater.DrawCard();
        Card drawnCard1 = Instantiate(drawnCard, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)), transform);
        playerHand.Add(drawnCard1);
        PlaceHand();
    }

    private void PlaceHand()
    {
        if(playerHand.Count == 0){return;}

        for (int i = 0; i < playerHand.Count; i++)
        {
            playerHand[i].HideCard();
            playerHand[i].SetPosition(new Vector3((i-playerHand.Count/2)*0.05f, i*0.0001f, 0));
        }
    }

    public void DisplayHand()
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            playerHand[i].ShowCard();
        }
        ActivateCards();
    }
    
    public void HideHand()
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            playerHand[i].HideCard();
            playerHand[i].GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void ActivateCards()
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            playerHand[i].GetComponent<BoxCollider>().enabled = true;
        }
    }
}
