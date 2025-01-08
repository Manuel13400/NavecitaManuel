using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class AroCollider : MonoBehaviour
{
    private GameManager gameManager;
    private AroManager aroManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        aroManager = FindObjectOfType<AroManager>();
    }

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
