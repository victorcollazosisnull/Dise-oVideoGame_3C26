using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    private MusicManager musicManager;
    private SFXController sFXController;
<<<<<<< HEAD
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI totalScoreText;
    private void Awake()
    {
        sFXController = FindObjectOfType<SFXController>();
        musicManager = MusicManager.Instance;
=======
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI coinsText;
    private void Awake()
    {
        sFXController = FindObjectOfType<SFXController>();
        musicManager = FindAnyObjectByType<MusicManager>();
>>>>>>> fde198a38e86cf3e7b0bbaa9dd79e820967916fa
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
<<<<<<< HEAD
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.PlayGameplayMusic();
        }
        else
        {
            Debug.LogError("MusicManager no está inicializado.");
        }
        SceneManager.LoadScene("SampleScene");
=======
        MusicManager.Instance.PlayGameplayMusic();
        SceneManager.LoadScene("SampleScene"); 
>>>>>>> fde198a38e86cf3e7b0bbaa9dd79e820967916fa
    }
    public void QuitGame()
    {
        sFXController.PlayClickSound();
<<<<<<< HEAD
        Application.Quit();
=======
        Application.Quit(); 
>>>>>>> fde198a38e86cf3e7b0bbaa9dd79e820967916fa
    }
    public void GoToMenu()
    {
        sFXController.PlayClickSound();
        musicManager.PlayMenuMusic();
        SceneManager.LoadScene("Menu");
    }
<<<<<<< HEAD
}
=======
    public void Retry()
    {
        sFXController.PlayClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     
        musicManager.PlayGameplayMusic();
        SceneManager.LoadScene("SampleScene");
    }
}
>>>>>>> fde198a38e86cf3e7b0bbaa9dd79e820967916fa
