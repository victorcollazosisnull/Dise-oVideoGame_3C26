using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverFondo : MonoBehaviour
{
    public float velocidad = 2f;
    private float altura;

    private void Start()
    {
        altura = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void Update()
    {
        transform.position += Vector3.down * velocidad * Time.deltaTime;

        if (transform.position.y <= -altura)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + altura * 2, transform.position.z);
        }
    }
}