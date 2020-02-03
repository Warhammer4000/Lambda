using System;
using System.Collections;
using System.Collections.Generic;
using BrainJam2020;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private string CardTag = "Card";

    private Player currentPlayer;
    private bool StandOff;
    private int StandOffCounter=1;

    [SerializeField] private Button Player1StandOff;
    [SerializeField] private Button Player2StandOff;

    [SerializeField] private GameObject Player1Turn;
    [SerializeField] private GameObject Player2Turn;

    [SerializeField] private GameObject TurnLeftP1;
    [SerializeField] private GameObject TurnLeftP2;
    [SerializeField] private TextMeshProUGUI CountP1;
    [SerializeField] private TextMeshProUGUI CountP2;

    void Update()
    {
        if(StandOffCounter>3)return;
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
                
                
                
               
                
                CardController cardController = hit.transform.GetComponent<CardController>();
                if(cardController.cardFlipped)return;
                if (!StandOff)
                {
                    PlayerTurn();
                }
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
            ToggleTurn();
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
        if(!StandOff)
        ToggleTurn();
   
    }


    void ToggleTurn()
    {
        Player1Turn.SetActive(Player2StandOff.interactable);
        Player2Turn.SetActive(Player1StandOff.interactable);
    }

    public void StandOffStart()
    {
        if (StandOff)
        {
            DecideWinner();
            return;
        }
        StandOff = true;
        PlayerTurn();
        
        
        if (currentPlayer.PlayerType == Player.PlayerEnum.Player1)
        {
            TurnLeftP1.gameObject.SetActive(true);
        }
        else
        {
            TurnLeftP2.gameObject.SetActive(true);
        }
    }

    private void StandOffMove()
    {
        
        CountP1.text = (3-StandOffCounter).ToString();
        CountP2.text = (3 - StandOffCounter).ToString();
        StandOffCounter++;
        if (StandOffCounter > 3)
        {
            DecideWinner();
        }
    }

    private void DecideWinner()
    {
        int p1 = GameManager.Instance.FirstPlayer.Score.Value;
        int p2 = GameManager.Instance.SecondPlayer.Score.Value;

        Player1Turn.SetActive(false);
        Player2Turn.SetActive(false);
        TurnLeftP1.SetActive(false);
        TurnLeftP2.SetActive(false);

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
