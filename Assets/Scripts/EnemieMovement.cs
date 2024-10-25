using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieMovement : MonoBehaviour
{
    public float fallSpeed = 3f;       // Velocidad de ca�da
    public float rotationSpeed = 100f; // Velocidad de rotaci�n

    private void Update()
    {
        // Movimiento hacia abajo
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // Rotaci�n continua en el eje Z
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
