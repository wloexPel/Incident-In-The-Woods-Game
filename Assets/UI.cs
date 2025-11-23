using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject tryAgainButton;
    [SerializeField] private GameObject EndGame;

    GameManager gm;
    private void Start()
    {
        gm = GameManager.Instance;
    }

    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();
        if (gm.isGameOver)
        {
            EndGame.SetActive(true);
        }
        else { EndGame.SetActive(false); }
    }

    public void OpenEndScreen()
    { 
        tryAgainButton.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
