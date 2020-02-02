using System;
using System.Collections;
using System.Collections.Generic;
using BrainJam2020;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private string CardTag = "Card";

    private Player currentPlayer;
    private bool StandOff;
    private int StandOffCounter;

    [SerializeField] private Button Player1StandOff;
    [SerializeField] private Button Player2StandOff;


    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (EventSystem.current.IsPointerOverGameObject(-1))
        {
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, 100.0f))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.tag == CardTag)
            {
                if (!StandOff)
                {
                    PlayerTurn();
                }
                
                
               
                
                CardController cardController = hit.transform.GetComponent<CardController>();
                GameManager.Instance.MakeMove(currentPlayer,cardController.GetCoOrdinate);
                cardController.FlipCard();

                if (StandOff)
                    StandOffMove();

            }
        }
    }

    private void PlayerTurn()
    {
        if (currentPlayer == null)
        {
            currentPlayer = GameManager.Instance.FirstPlayer;
            Player1StandOff.interactable = true;
            return;
        }
        switch (currentPlayer.PlayerType)
        {
            case Player.PlayerEnum.Player1:
                currentPlayer = GameManager.Instance.SecondPlayer;
                break;
            case Player.PlayerEnum.Player2:
                currentPlayer = GameManager.Instance.FirstPlayer;
                break;
          
        }
        ToggleStandOffButtons();
      
    }

    private void ToggleStandOffButtons()
    {
        Player1StandOff.interactable = !Player1StandOff.interactable;
        Player2StandOff.interactable = !Player2StandOff.interactable;
    }

    public void StandOffStart()
    {
        if (StandOff)
        {
            DecideWinner();
            return;
        }
        PlayerTurn();
        StandOff = true;
    }

    private void StandOffMove()
    {
        StandOffCounter++;
        if (StandOffCounter > 2)
        {
            DecideWinner();
        }
    }

    private void DecideWinner()
    {
        int p1 = GameManager.Instance.FirstPlayer.Score.Value;
        int p2 = GameManager.Instance.SecondPlayer.Score.Value;
        if ( p1>p2 && p1<=GameManager.Instance.MarginalScore )
        {
            WinnerUI.Instance.ShowWinner(GameManager.Instance.FirstPlayer);
        }
        else
        {
            WinnerUI.Instance.ShowWinner(GameManager.Instance.SecondPlayer);
        }
    }

}
