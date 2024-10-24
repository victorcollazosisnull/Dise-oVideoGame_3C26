using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI coinsText; 

    public void ShowResults()
    {
        scoreText.text = "TIEMPO: ";
        coinsText.text = "MONEDAS: "; 
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene"); 
    }
    public void QuitGame()
    {
        Application.Quit(); 
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
