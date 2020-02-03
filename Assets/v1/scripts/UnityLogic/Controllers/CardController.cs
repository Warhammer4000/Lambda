using System.Collections;
using System.Collections.Generic;
using BrainJam2020;
using TMPro;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private Card Card;

    [SerializeField] private TextMeshPro Number;
    [SerializeField] private TextMeshPro Operator;
    [SerializeField] private Animator CardAnimator;

    public bool cardFlipped;
    public void RegisterCard(Card card)
    {
        Card = card;
        Number.text = Card.Point.ToString();
        Operator.text = card.Operator;
    }

    public void FlipCard()
    {
        cardFlipped = true;
        CardAnimator.SetTrigger("FlipCard");
    }

    public CoOrdinate GetCoOrdinate => Card.CoOrdinate;

}
