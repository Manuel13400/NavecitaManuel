using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
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
        float offsetY = Mathf.Sin(Time.time * 2f) * 0.5f;
        transform.position = new Vector3(posicionInicial.x, posicionInicial.y + offsetY, posicionInicial.z);
        
        float distancia = Vector3.Distance(transform.position, naveTransform.position);
        if (distancia < 25)
        {
            animator.speed = 10;
        }
        else
        {
            animator.speed = 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nave"))
        {
            gameManager.monedasRecogidas++;
            Destroy(gameObject);
        }
    }
}
