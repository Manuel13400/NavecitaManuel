using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class AroManager : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject[] listaAros;
    public GameObject[] listaArosAtravesados;

    private bool creado = false;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        EstablecerAros();
        creado = true;
    }

    public void EstablecerAros()
    {
        if (creado) { listaAros = new GameObject[0]; }

        listaAros = GameObject.FindGameObjectsWithTag("Aro");

        for (int i = 0; i < listaAros.Length; i++)
        {
            Renderer renderer = listaAros[i].GetComponent<Renderer>();
            if (i == 0)
            {
                renderer.material.color = Color.green;
            }
            else
            {
                renderer.material.color = Color.black;
            }
        }
    }
}
