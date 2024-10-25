using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieMovement : MonoBehaviour
{
    public float fallSpeed = 3f;       // Velocidad de caída
    public float rotationSpeed = 100f; // Velocidad de rotación

    private void Update()
    {
        // Movimiento hacia abajo
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // Rotación continua en el eje Z
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("muerte"))
        {
            Destroy(gameObject);
        }
    }
}
