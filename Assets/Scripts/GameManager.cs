using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private MusicManager musicManager;
    public static GameManager instance;
    public int playerScore = 0;
    public TextMeshProUGUI scoreText;
    private int totalCoins = 0;
    private float survivalTime;
    private bool isGameActive;

    private void Awake()
    {
        musicManager = MusicManager.Instance;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        FindScoreText();
        isGameActive = true;
        StartCoroutine(Timer());
    }
    private void Update()
    {
        survivalTime += Time.deltaTime;
    }
    private IEnumerator Timer()
    {
        while (isGameActive)
        {
            survivalTime += Time.deltaTime;
            yield return null;
        }
    }

    public float GetSurvivalTime()
    {
        return survivalTime;
    }

    public void StopGame()
    {
        isGameActive = false;
    }

    private void OnEnable()
    {
        FindScoreText();
    }

    private void FindScoreText()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        if (scoreText == null)
        {
            Debug.LogError("scoreText no encontrado en la escena.");
        }
        else
        {
            UpdateScoreText();
        }
    }

    public void AddPoints(int points)
    {
        playerScore += points;
        totalCoins += points;
        UpdateScoreText();
        Debug.Log("agarrando monedas");
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "POINTS: " + playerScore.ToString();
        }
    }

    public int GetCurrentCoins()
    {
        return totalCoins;
    }

    public void ResetCoins()
    {
        totalCoins = 0;
    }

    public void RestartGame()
    {
        playerScore = 0;
        totalCoins = 0;
        ResetCoins();
        UpdateScoreText();
        survivalTime = 0;
        isGameActive = true;
        StartCoroutine(Timer());

        if (musicManager != null)
        {
            musicManager.PlayGameplayMusic();
        }
        else
        {
            Debug.LogError("musicManager no está inicializado en RestartGame()");
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}