using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class AroManager : MonoBehaviour
{
    // Conexion con el gamemanager
    private GameManager gameManager;

    // Lista de aros
    public GameObject[] listaAros;
    //public GameObject[] listaArosAtravesados;

    private bool creado = false;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        EstablecerAros();
        creado = true;
    }

    public void EstablecerAros()
    {
        // Reinicia la lista para poder reasignar el color al primer aro de la lista
        if (creado) { listaAros = new GameObject[0]; }

        // Rellena la lista aros
        listaAros = GameObject.FindGameObjectsWithTag("Aro");

        // Cambia a color verde el primer aro de la lista y a color negro el resto
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
