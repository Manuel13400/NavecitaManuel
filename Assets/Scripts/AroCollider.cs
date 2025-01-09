using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class AroCollider : MonoBehaviour
{
    // Conexion con el gamemanager y el aromanager
    private GameManager gameManager;
    private AroManager aroManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        aroManager = FindObjectOfType<AroManager>();
    }

    // Este script cambia el tag del aro que este atravesando la nave a AroCompletado
    // Cambia el aro en cuestion a color rojo y aumenta la cantidad de aros atravesados
    // Ademas, vuelve a ejecutar la funcion EstablecerAros
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nave"))
        {
            Renderer colRenderer = gameObject.GetComponent<Renderer>();
            if (colRenderer.material.color == Color.green)
            {
                gameObject.tag = "AroCompletado";

                Renderer renderer = gameObject.GetComponent<Renderer>();
                renderer.material.color = Color.red;

                gameManager.arosAtravesados++;
                aroManager.EstablecerAros();
            }
        }
    }
}
