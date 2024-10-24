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
    public TextMeshProUGUI coinsText;
    private void Awake()
    {
        sFXController = FindObjectOfType<SFXController>();
        musicManager = FindAnyObjectByType<MusicManager>();
    }
    public void ShowResults()
    {
        scoreText.text = "TIEMPO: ";
        coinsText.text = "MONEDAS: "; 
    }
    public void PlayGame()
    {
        sFXController.PlayClickSound();
        MusicManager.Instance.PlayGameplayMusic();
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
        musicManager.PlayMenuMusic();
        SceneManager.LoadScene("Menu");
    }
    public void Retry()
    {
        sFXController.PlayClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     
        musicManager.PlayGameplayMusic();
        SceneManager.LoadScene("SampleScene");
    }
}
