using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class DeckInstantiater : MonoBehaviour
{
    [SerializeField] private List<CardProperties> cardPrefabs;
    
    private List<CardProperties> _mixedCardDeck;

    private void Start()
    {
        MixDeck(cardPrefabs);
        SpawnDeck();
    }

    private void MixDeck(List<CardProperties> sortedDeck)
    {
        Random rand = new Random();
        _mixedCardDeck = sortedDeck.OrderBy(_ => rand.Next()).ToList();
    }

    private void SpawnDeck()
    {
        for (int i = 0; i<52; i++)
        {
            Instantiate(_mixedCardDeck[i], transform.position+ Vector3.up * i * 0.0003f, Quaternion.Euler(new Vector3(-90, 0, 0)));
        }
        
    }
}
