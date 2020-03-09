using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BrainJam2020;
using UnityEngine;
using Grid = BrainJam2020.Grid;

public class CardGridManager : MonoBehaviour
{
    [SerializeField]private float x_Start;
    [SerializeField] private float y_start;

    [SerializeField] private int columnLength;
    [SerializeField] private int rowLength;

    [SerializeField] private float x_space;
    [SerializeField] private float y_space;

    public GameObject CardPrefab;

    public void CreateGrid(Grid grid)
    {
        var cards = grid.GetCards();
        //todo rework
        int x=1, y=1;
        for (int i = 0; i < columnLength*rowLength; i++)
        {
            var pos = new Vector3(x_Start + (x_space * (i % columnLength)),0, y_start + (-y_space * (i / columnLength)));
            var cardObject=Instantiate(CardPrefab, pos, Quaternion.identity);
            CoOrdinate current=new CoOrdinate(x,y);
            cardObject.GetComponent<CardController>().RegisterCard(cards[current]);
            if (y == columnLength)
            {
                x++;
                y = 0;
            }
            y++;
        }
    }
}
