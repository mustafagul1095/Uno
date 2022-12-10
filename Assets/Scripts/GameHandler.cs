using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Player playerPrefab;
    [SerializeField] private List<Player> players;
    [SerializeField] private TMP_Dropdown playerNumDropDown;
    [SerializeField] private Canvas gameStartUI;

    private int _playerNumber = 2;
    private bool _gameStarted = false;
    private int _turn = 0;


    public void StartGame()
    {
        if (_gameStarted) {return;}
        
        for (int i = 0; i < _playerNumber; i++)
        {
            if (i == 0)
            {
                Player _player1 = Instantiate(playerPrefab, new Vector3(0, 0, -0.4f), Quaternion.identity);
                players.Add(_player1);
            }
            if (i == 1)
            {
                Player _player2 = Instantiate(playerPrefab, new Vector3(0.4f, 0, 0), Quaternion.identity);
                _player2.transform.rotation = Quaternion.Euler(0,-90f,0);
                players.Add(_player2);
            }
            if (i == 2)
            {
                Player _player3 = Instantiate(playerPrefab, new Vector3(0, 0, 0.4f), Quaternion.identity);
                _player3.transform.rotation = Quaternion.Euler(0,180f,0);
                players.Add(_player3);
            }
            if (i == 3)
            {
                Player _player4 = Instantiate(playerPrefab, new Vector3(-0.4f, 0, 0), Quaternion.identity);
                _player4.transform.rotation = Quaternion.Euler(0,90f,0);
                players.Add(_player4);
            }
        }
        
        DealCards();
        _gameStarted = true;
        gameStartUI.enabled = false;
        _turn = 1;
        HandleTurn();
    }

    public void SetPlayerNumber()
    {
        _playerNumber = playerNumDropDown.value+2;
    }
    
    private void DealCards()
    {
        for (int i = 0; i < 7; i++)
        {
            foreach (var player in players)
            {
                player.DrawCardFromDeck();
            }
        }
    }

    public void HandleTurn()
    {
        if (_turn > 0)
        {
            for (int i = 0; i < _playerNumber; i++)
            {
                players[i].SetPlayerActive(false);
                players[i].HideHand();
            }
            players[_turn-1].SetPlayerActive(true);
            players[_turn-1].DisplayHand();
        }
    }

    public void PassTurn()
    {
        if (_turn > 0 && _turn < _playerNumber)
        {
            _turn++;
        }

        if (_turn == _playerNumber)
        {
            _turn = 1;
        }
    }
    
}
