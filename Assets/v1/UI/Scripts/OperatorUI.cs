using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OperatorUI : MonoBehaviour
{
    public static OperatorUI Instance;
    void Awake()
    {
        Instance = this;
    }


    [SerializeField]private TextMeshProUGUI[] operators;

    public void UpdateUI(Dictionary<string,int> data)
    {
        operators[0].text = data[StringResources.Plus].ToString();
        operators[1].text = data[StringResources.Minus].ToString();
        operators[2].text = data[StringResources.Multiply].ToString();
        operators[3].text = data[StringResources.Divide].ToString();
    }
}
