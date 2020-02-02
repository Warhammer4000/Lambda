using System.Collections;
using System.Collections.Generic;
using BrainJam2020;
using TMPro;
using UnityEngine;

public class SoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI[] Lambdas;

    private Player Player;


    public void InitializePlayer(Player player)
    {
        Player = player;
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        Player.OnScoreChange += UpdateScore;
        Player.OnLambdaChange += UpdateLambda;
    }

    private void UpdateScore(int score)
    {
        ScoreText.text = score.ToString();
        
    }

    private void UpdateLambda(int count)
    {
        if (count == 3)
        {
            WinnerUI.Instance.ShowWinner(Player);
        }
        for (int i = 0; i < count; i++)
        {
            Lambdas[i].color=new Color(1,1,1,1);
        }
        
    }
}
