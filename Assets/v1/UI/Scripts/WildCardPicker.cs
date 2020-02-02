using System.Collections;
using System.Collections.Generic;
using BrainJam2020;
using TMPro;
using UnityEngine;

public class WildCardPicker : MonoBehaviour
{
    public static WildCardPicker Instance;

    public GameObject Panel;

    [SerializeField] private TextMeshProUGUI CardValue;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private Player Player;
    private Card Card;

    public void ApplyOperator(string op)
    {
        Card.ResetOperator(op);
        Player.ReceiveCard(Card);
        Panel.SetActive(false);
    }

    public void RegisterPlayerAndCard(Player player,Card card)
    {
        Player = player;
        Card = card;
        Panel.SetActive(true);
        CardValue.text = card.Point.ToString();
    }

}
