using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* INTERFAZ */
    // Temporizador
    GameObject temporizadorCanvas;
    TextMeshProUGUI temporizadorTexto;
    float totalSegundos;

    // Aros
    int totalAros;
    GameObject arosCanvas;
    TextMeshProUGUI arosTexto;
    int arosAtravesados = 0;

    // Monedas
    int totalMonedas;
    GameObject monedasCanvas;
    TextMeshProUGUI monedasTexto;
    int monedasRecogidas = 0;

    // Turbo

    /* ELEMENTOS DE JUEGO */
    // Monedas de los primeros cinco aros
    public GameObject[] listaSpawnsUno;


    void Start()
    {
        IniciarInterfaz();
        SpawnearMonedas();
    }

    void Update()
    {
        ActualizarCanvasTemporizador();
    }

    void IniciarInterfaz()
    {
        // Temporizador
        totalSegundos = 45;

        temporizadorCanvas = GameObject.Find("CuentaAtras");
        temporizadorTexto = temporizadorCanvas.GetComponent<TextMeshProUGUI>();

        temporizadorTexto.text = "  " + totalSegundos;

        // Aros
        totalAros = GameObject.FindGameObjectsWithTag("Aro").Length;

        arosCanvas = GameObject.Find("ArosTotales");
        arosTexto = arosCanvas.GetComponent<TextMeshProUGUI>();

        arosTexto.text = "  " + arosAtravesados + " / " + totalAros;

        // Monedas
        totalMonedas = GameObject.FindGameObjectsWithTag("MonedasPrimerTipo").Length;
        totalMonedas += GameObject.FindGameObjectsWithTag("MonedasSegundoTipo").Length;
        totalMonedas += GameObject.FindGameObjectsWithTag("MonedasTercerTipo").Length;

        monedasCanvas = GameObject.Find("MonedasTotales");
        monedasTexto = monedasCanvas.GetComponent<TextMeshProUGUI>();

        monedasTexto.text = "  " + monedasRecogidas + " / " + totalMonedas;

        // Turbo
    }

    void SpawnearMonedas()
    {
        listaSpawnsUno = GameObject.FindGameObjectsWithTag("MonedasPrimerTipo");
        List<int> posicionesOcuparUno = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            bool continua = false;

            while (!continua)
            {
                int randomPosition = Random.Range(0, listaSpawnsUno.Length);
                if (!posicionesOcuparUno.Contains(randomPosition))
                {
                    posicionesOcuparUno.Add(randomPosition);
                    continua = true;
                }
            }
        }




}

    void ActualizarCanvasTemporizador()
    {
        // Temporizador
        totalSegundos = totalSegundos - Time.deltaTime;

        if (totalSegundos < 0)
        {
            // Cambiar a pantalla derrota
            totalSegundos = 0;
        }

        float minutos = Mathf.FloorToInt(totalSegundos / 60);
        float segundos = Mathf.FloorToInt(totalSegundos % 60);

        temporizadorTexto.text = string.Format("   {0:00}:{1:00}", minutos, segundos);
    }
}
