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
    private int waitTime = 4;
    public void ShowWinner(Player player)
    {
        StartCoroutine(EndGameRutine(player));
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneName);
    }

    IEnumerator EndGameRutine(Player player)
    {
        yield return new WaitForSeconds(waitTime);
        WinnerPanel.SetActive(true);
        WinnerName.text = player.PlayerType.ToString();
    }


}
