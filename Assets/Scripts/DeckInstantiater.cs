using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class DeckInstantiater : MonoBehaviour
{
    [SerializeField] private float cardThickness = 0.0003f;
    [SerializeField] private List<Card> cardPrefabs;
    [SerializeField] private List<Card> cardPrefabsForDict;

    [SerializeField] private List<Card> _sortedDeck;
    [SerializeField] private List<Card> _mixedCardDeck;
    [SerializeField] private List<Card> _spawnedCardDeck;

    public Dictionary<CardColorValue, GameObject> prefabByCardColorValue;


    private void Awake()
    {
        InitializeDictionary();
        CreateSortedDeck();
        MixDeck(_sortedDeck);
        SpawnDeck();
    }

    private void InitializeDictionary()
    {
        prefabByCardColorValue = new Dictionary<CardColorValue, GameObject>(50);
        foreach (var cardPrefab in cardPrefabsForDict)
        {
            prefabByCardColorValue.Add(cardPrefab.CardColorValue,cardPrefab.gameObject);
        }
    }
    private void CreateSortedDeck()
    {
        _sortedDeck = new List<Card>();
        for (int i = 0; i < 2; i++)
        {
            foreach (var card in cardPrefabs)
            {
                _sortedDeck.Add(card);
            } 
        }
    }
    private void MixDeck(List<Card> sortedDeck)
    {
        Random rand = new Random();
        _mixedCardDeck = sortedDeck.OrderBy(_ => rand.Next()).ToList();
    }

    private void SpawnDeck()
    {
        _spawnedCardDeck = new List<Card>();
        for (int i = 0; i<_sortedDeck.Count; i++)
        {
            _spawnedCardDeck.Add(Instantiate(_mixedCardDeck[i], transform.position+ Vector3.up * i * cardThickness, Quaternion.Euler(new Vector3(-90, 0, 0)),transform));
        }
    }

    public Card DrawCard()
    {
        Card card = _spawnedCardDeck[_spawnedCardDeck.Count-1];
        Destroy(_spawnedCardDeck[_spawnedCardDeck.Count-1].gameObject);
        _spawnedCardDeck.Remove(_spawnedCardDeck[_spawnedCardDeck.Count-1]);
        return card;
    }

    public void EnableDeckClick()
    {
        _spawnedCardDeck[_spawnedCardDeck.Count - 1].gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
