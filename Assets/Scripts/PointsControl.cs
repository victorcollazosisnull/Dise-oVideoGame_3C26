using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsControl : MonoBehaviour
{
    public int pointValue = 1; 
    public float speed = 5f;

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            GameManager.instance.AddPoints(pointValue); 
            Destroy(gameObject); 
        }
        else if (collision.CompareTag("muerte"))
        {
            Destroy(gameObject);
        }
    }
}
