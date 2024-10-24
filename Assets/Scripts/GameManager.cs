using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int playerScore = 0;
    public TextMeshProUGUI scoreText;
    private int totalCoins = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    public void AddPoints(int points)
    {
        playerScore += points;
        scoreText.text = "PUNTOS: " + playerScore.ToString();
    }
    public int GetCurrentCoins()
    {
        return totalCoins;
    }

    public void ResetCoins()
    {
        totalCoins = 0;
    }
}