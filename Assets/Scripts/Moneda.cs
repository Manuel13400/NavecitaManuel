using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    // Conexion con el gamemanager y el animator
    private GameManager gameManager;
    private Transform naveTransform;
    private Animator animator;

    private Vector3 posicionInicial;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        naveTransform = GameObject.FindGameObjectWithTag("Nave").transform;
        animator = GetComponent<Animator>();
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Mueve de arriba a abajo la moneda
        float offsetY = Mathf.Sin(Time.time * 2f) * 0.5f;
        transform.position = new Vector3(posicionInicial.x, posicionInicial.y + offsetY, posicionInicial.z);
        
        // Calcula la distancia entre la nave y la moneda y acelera el animator de la rotacion cuando se acerca
        float distancia = Vector3.Distance(transform.position, naveTransform.position);
        if (distancia < 25) { animator.speed = 10; }
        else { animator.speed = 1; }
    }

    // Al tocar la moneda con la nave, la cantidad de monedas recogidas aumenta y destruye la moneda
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nave"))
        {
            gameManager.monedasRecogidas++;
            Destroy(gameObject);
        }
    }
}
