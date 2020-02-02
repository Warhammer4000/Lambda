using System.Collections;
using System.Collections.Generic;
using BrainJam2020;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerUI : MonoBehaviour
{
    public static WinnerUI Instance;
    [SerializeField]private string SceneName = "Demo";
    void Awake()
    {
        Instance = this;
    }

    [SerializeField]private GameObject WinnerPanel;
    [SerializeField]private TextMeshProUGUI WinnerName;
    public void ShowWinner(Player player)
    {
        WinnerPanel.SetActive(true);
        WinnerName.text = player.PlayerType.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneName);
    }


}
