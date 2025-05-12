using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    private MusicManager musicManager;
    private SFXController sFXController;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI totalScoreText;
    public TextMeshProUGUI coinsText; // Si vas a usarlo más adelante

    private void Awake()
    {
        sFXController = FindObjectOfType<SFXController>();
        musicManager = MusicManager.Instance != null ? MusicManager.Instance : FindAnyObjectByType<MusicManager>();
    }

    public void ShowResults()
    {
        float survivalTime = GameManager.instance.GetSurvivalTime();
        int coinsCollected = GameManager.instance.GetCurrentCoins();

        int totalScore = coinsCollected + (int)survivalTime;

        scoreText.text = "POINTS: " + coinsCollected.ToString();
        timeText.text = "TIME: " + Mathf.FloorToInt(survivalTime).ToString() + "s";
        totalScoreText.text = "RESULT: " + totalScore.ToString();
    }

    public void PlayGame()
    {
        sFXController.PlayClickSound();

        if (musicManager != null)
        {
            musicManager.PlayGameplayMusic();
        }
        else
        {
            Debug.LogError("MusicManager no está inicializado.");
        }

        SceneManager.LoadScene("SampleScene");
    }

    public void Retry()
    {
        sFXController.PlayClickSound();

        if (musicManager != null)
        {
            musicManager.PlayGameplayMusic();
        }

        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        sFXController.PlayClickSound();
        Application.Quit();
    }

    public void GoToMenu()
    {
        sFXController.PlayClickSound();

        if (musicManager != null)
        {
            musicManager.PlayMenuMusic();
        }

        SceneManager.LoadScene("Menu");
    }
}