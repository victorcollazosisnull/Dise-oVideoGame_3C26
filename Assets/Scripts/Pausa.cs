using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pausa : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject panelPausa;
    public GameObject botonPausa;
    public GameObject botonDesPausa;

    private void Start()
    {
        panelPausa.SetActive(false);
        botonPausa.SetActive(true);
        botonDesPausa.SetActive(false);
    }

    public void Pausando()
    {
        Time.timeScale = 0f;
        panelPausa.SetActive(true);
        botonPausa.SetActive(false);
        botonDesPausa.SetActive(true);
        isPaused = true;
    } 
    public void Resume()
    {
        Time.timeScale = 1f;
        panelPausa.SetActive(false);
        botonPausa.SetActive(true);
        botonDesPausa.SetActive(false);
        isPaused = false;
    }
    public bool IsPaused()
    {
        return isPaused;
    }
}
