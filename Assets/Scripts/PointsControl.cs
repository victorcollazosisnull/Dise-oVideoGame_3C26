using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsControl : MonoBehaviour
{
    private SFXController sFXController;
    public int pointValue = 1; 
    public float speed = 5f;
    private void Awake()
    {
        sFXController = FindObjectOfType<SFXController>();
        if (sFXController == null)
        {
            Debug.LogError("SFXController no encontrado en la escena.");
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (sFXController != null)
            {
                sFXController.PlayGetCoin();
<<<<<<< HEAD
                GameManager.instance.AddPoints(pointValue);
=======
>>>>>>> fde198a38e86cf3e7b0bbaa9dd79e820967916fa
            }
            else
            {
                Debug.LogError("SFXController no est� inicializado.");
            }
            Destroy(gameObject);
        }
        else if (collision.CompareTag("muerte"))
        {
            Destroy(gameObject);
        }
    }
}
