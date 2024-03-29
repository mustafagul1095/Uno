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
    [SerializeField] private PlayedCards playedCard;

    private int _playerNumber = 2;
    private bool _gameStarted = false;
    private int _turn = 1;

    private bool _gameDirection = false;
    private bool _passTurnPlayed = false;
    private bool _plusFourPlayed = false;
    private bool _plusTwoPlayed = false;
    
    public void StartGame()
    {
        if (_gameStarted) {return;}
        
        for (int i = 0; i < _playerNumber; i++)
        {
            if (i == 0)
            {
                Player _player1 = Instantiate(playerPrefab, new Vector3(0, 0, -0.4f), Quaternion.identity,transform);
                _player1.SetPlayerActive(true);
                players.Add(_player1);
            }
            if (i == 1)
            {
                Player _player2 = Instantiate(playerPrefab, new Vector3(0.4f, 0, 0), Quaternion.identity,transform);
                _player2.transform.rotation = Quaternion.Euler(0,-90f,0);
                players.Add(_player2);
            }
            if (i == 2)
            {
                Player _player3 = Instantiate(playerPrefab, new Vector3(0, 0, 0.4f), Quaternion.identity,transform);
                _player3.transform.rotation = Quaternion.Euler(0,180f,0);
                players.Add(_player3);
            }
            if (i == 3)
            {
                Player _player4 = Instantiate(playerPrefab, new Vector3(-0.4f, 0, 0), Quaternion.identity,transform);
                _player4.transform.rotation = Quaternion.Euler(0,90f,0);
                players.Add(_player4);
            }
        }
        
        DealCards();
        _gameStarted = true;
        gameStartUI.enabled = false;
        ActivatePlayer();
    }

    public void Played()
    {
        PassTurn();
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

    public void ActivatePlayer()
    {
        if (_turn > 0)
        {
            var currentPlayer = players[_turn-1];
            currentPlayer.SetPlayerActive(true);
            
            if (_plusFourPlayed)
            {
                currentPlayer.SetCantPlayCard(true);
                currentPlayer.DisplayWhenPlusFourPlayed();
                if (playedCard.GetCardsToDrawForPass() > 1)
                {
                    playedCard.SetCardsToDrawForPass(playedCard.GetCardsToDrawForPass()+4);
                }
                else
                {
                    playedCard.SetCardsToDrawForPass(4);
                }
                
                _plusFourPlayed = false;
            }
            else if (_plusTwoPlayed)
            {
                currentPlayer.SetCantPlayCard(true);
                currentPlayer.DisplayWhenPlusTwoPlayed();
                if (playedCard.GetCardsToDrawForPass() > 1)
                {
                    playedCard.SetCardsToDrawForPass(playedCard.GetCardsToDrawForPass()+2);
                }
                else
                {
                    playedCard.SetCardsToDrawForPass(2);
                }

                _plusTwoPlayed = false;
            }
            else
            {
                currentPlayer.DisplayHand();
                currentPlayer.ActivateCards();
            }
        }
    }

    public void PassTurn()
    {
        IncrementTurn();

        if (_passTurnPlayed)
        {
            IncrementTurn();
            _passTurnPlayed = false;
        }
        StartCoroutine(DelayAction(0.1f));
    }

    private void IncrementTurn()
    {
        if (!_gameDirection)
        {
            if (_turn > 0 && _turn < _playerNumber)
            {
                _turn++;
            }
            else if (_turn == _playerNumber)
            {
                _turn = 1;
            }
        }
        else
        {
            if (_turn > 1 && _turn <= _playerNumber)
            {
                _turn--;
            }
            else if (_turn == 1)
            {
                _turn = _playerNumber;
            }
        }
    }

    IEnumerator DelayAction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
 
        ActivatePlayer();
    }

    private void OnReverse()
    {
        _gameDirection = !_gameDirection;
    }

    private void OnPassTurnPlayed()
    {
        _passTurnPlayed = true;
    }

    private void OnPlusFourPlayed()
    {
        _plusFourPlayed = true;
    }

    private void OnPlusTwoPlayed()
    {
        _plusTwoPlayed = true;
    }
}
