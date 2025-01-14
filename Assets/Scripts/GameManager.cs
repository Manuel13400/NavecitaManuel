using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


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
    public int arosAtravesados = 0;

    // Monedas
    int totalMonedas;
    GameObject monedasCanvas;
    TextMeshProUGUI monedasTexto;
    public int monedasRecogidas = 0;

    // Puntuacion
    int puntuacionFinal;
    GameObject puntuacionCanvas;
    TextMeshProUGUI puntuacionTexto;

    /* ELEMENTOS DE JUEGO */
    public GameObject coinPrefab;
    public GameObject[] listaSpawnsUno;
    public GameObject[] listaSpawnsDos;

    public GameObject victoryScreen;
    public GameObject defeatScreen;


    void Start()
    {
        HideEndScreens();
        SpawnearMonedasUno();
        SpawnearMonedasDos();
        IniciarInterfaz();
    }

    void Update()
    {
        ActualizarCanvasTemporizador();
        ActualizarContadorMonedas();
        ActualizarContadorAros();

        if (arosAtravesados == 10) { VictoryScreenShow(); }
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
        totalMonedas = GameObject.FindGameObjectsWithTag("SpawnedCoin").Length;

        monedasCanvas = GameObject.Find("MonedasTotales");
        monedasTexto = monedasCanvas.GetComponent<TextMeshProUGUI>();

        monedasTexto.text = "  " + monedasRecogidas + " / " + totalMonedas;
    }

    void SpawnearMonedasUno()
    {
        // Genera las monedas entre los primeros cinco aros
        // Primero busca las posiciones marcadas para los aros en cuestion
        listaSpawnsUno = GameObject.FindGameObjectsWithTag("MonedasPrimerTipo");
        List<int> posicionesOcuparUno = new List<int>();

        // Genera una lista de cifras aleatoria para saber que huecos de la lista previa ocupar
        for (int i = 0; i < 15; i++)
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

        // Rellena las posiciones que la lista anterior haya generado aleatoriamente
        for (int i = 0; i < 25; i++)
        {
            if (posicionesOcuparUno.Contains(i))
            {
                Instantiate(coinPrefab, listaSpawnsUno[i].transform.position, Quaternion.identity);
            }
        }
    }

    void SpawnearMonedasDos()
    {
        // Genera las monedas entre los siguientes tres aros
        // Primero busca las posiciones marcadas para los aros en cuestion
        listaSpawnsDos = GameObject.FindGameObjectsWithTag("MonedasSegundoTipo");
        List<int> posicionesOcuparDos = new List<int>();

        // Genera una lista de cifras aleatoria para saber que huecos de la lista previa ocupar
        for (int i = 0; i < 5; i++)
        {
            bool continua = false;

            while (!continua)
            {
                int randomPosition = Random.Range(0, listaSpawnsDos.Length);
                if (!posicionesOcuparDos.Contains(randomPosition))
                {
                    posicionesOcuparDos.Add(randomPosition);
                    continua = true;
                }
            }
        }

        // Rellena las posiciones que la lista anterior haya generado aleatoriamente
        for (int i = 0; i < 15; i++)
        {
            if (posicionesOcuparDos.Contains(i))
            {
                Instantiate(coinPrefab, listaSpawnsDos[i].transform.position, Quaternion.identity);
            }
        }
    }

    void ActualizarCanvasTemporizador()
    {
        // Temporizador
        totalSegundos = totalSegundos - Time.deltaTime;

        if (totalSegundos < 0)
        {
            totalSegundos = 0;
            DefeatScreenShow();
        }

        float minutos = Mathf.FloorToInt(totalSegundos / 60);
        float segundos = Mathf.FloorToInt(totalSegundos % 60);

        temporizadorTexto.text = string.Format("   {0:00}:{1:00}", minutos, segundos);
    }

    void ActualizarContadorMonedas()
    {
        monedasTexto.text = "  " + monedasRecogidas + " / " + totalMonedas;
    }

    void ActualizarContadorAros()
    {
        arosTexto.text = "  " + arosAtravesados + " / " + totalAros;
    }

    // Funcion para ocultar las pantallas finales
    void HideEndScreens()
    {
        victoryScreen = GameObject.Find("VictoryScreen");
        defeatScreen = GameObject.Find("DefeatScreen");
        victoryScreen.SetActive(false);
        defeatScreen.SetActive(false);
    }

    // Funcion para mostrar la pantalla de victoria
    void VictoryScreenShow()
    {
        victoryScreen.SetActive(true);
        puntuacionCanvas = GameObject.Find("PuntuacionFinalVic");
        puntuacionTexto = puntuacionCanvas.GetComponent<TextMeshProUGUI>();
        puntuacionFinal = (int)totalSegundos + (monedasRecogidas * 2);
        puntuacionTexto.text = "Tu puntuacion final es: " + puntuacionFinal;

        Time.timeScale = 0;
    }

    // Funcion para mostrar la pantalla de derrota
    void DefeatScreenShow()
    {
        defeatScreen.SetActive(true);
        puntuacionCanvas = GameObject.Find("PuntuacionFinalDer");
        puntuacionTexto = puntuacionCanvas.GetComponent<TextMeshProUGUI>();
        puntuacionFinal = (int)totalSegundos + (monedasRecogidas * 2);
        puntuacionTexto.text = "Tu puntuacion final es: " + puntuacionFinal;

        Time.timeScale = 0;
    }
}
