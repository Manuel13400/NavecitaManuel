using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{

    public float speed = 0.25f;
    public float maxSpeed = 0;
    public float minSpeed = 0;

    public float temporizadorAcelerar = 10;

    public Renderer motorDerecho;
    public Renderer motorIzquierdo;

    private Color colorOriginal;

    private bool acelerando = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Awake()
    {
        colorOriginal = motorDerecho.material.color;
        maxSpeed = speed * 1.5f;
        minSpeed = speed;
    }

    void FixedUpdate()
    {
        // Movimiento constante de la nave para que no se quede levitando quieta
        transform.Translate(Vector3.forward * 0.05f);
        applyRotation();
        applyMovement();

    }

    private void applyMovement()
    {
        if (acelerando)
        {
            speed = 0.75f;
        } else
        {
            speed = 0.25f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed);
        } else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * speed);
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed);
        } else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            acelerando = true;
        } else
        {
            acelerando = false;
        }
    }

    private void applyRotation()
    {

        float sumarX = 0;
        float sumarY = 0;
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            sumarY = 1;
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            sumarY = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            sumarX = 1;
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            sumarX = -1;
        }

        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x + sumarY,
            transform.eulerAngles.y + sumarX,
            transform.eulerAngles.z);
    }

}
