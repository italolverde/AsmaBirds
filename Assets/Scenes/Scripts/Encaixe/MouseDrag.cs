using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    Vector3 posInicial;
    Vector3 posDestino;
    Vector3 vetorDirecao;
    [SerializeField] Rigidbody2D _rigidbody;
    private bool arrastando;
    static public bool conectado;
    private float distancia;
    private float movespeed;
    [SerializeField] private GameObject azul;
    [SerializeField] private GameObject vermelho;
    [SerializeField] private GameObject vermelho_azul;
    [SerializeField] private Transform conector;
    private float distanciaMinimaConector = 1;
    private bool connect_1 = false;
    private void Start()
    {
        _rigidbody = transform.root.GetComponent<Rigidbody2D>();
    }
    void OnMouseDown()
    {
        posInicial = transform.root.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        arrastando = true;
        conectado = false;
        movespeed = 15;
    }
    void OnMouseDrag()
    {
        posDestino = posInicial + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vetorDirecao = posDestino - transform.root.position;
        _rigidbody.velocity = vetorDirecao * movespeed;
    }
    void OnMouseUp()
    {
        arrastando = false;
        while (vetorDirecao.x > 0 && vetorDirecao.y > 0)
        {
            vetorDirecao.x--;
            vetorDirecao.y--;
        }
    }
    private void FixedUpdate()
    {
        if (!arrastando && !conectado)
        {
            distancia = Vector2.Distance(transform.root.position, conector.position);
            if (distancia < distanciaMinimaConector)
            {
                _rigidbody.velocity = Vector2.zero;
                transform.root.position = Vector2.MoveTowards(transform.root.position, conector.position, 0.02f);

            }
            if (distancia < 0.01f) //Chegou
            {
                conectado = true;
                transform.root.position = conector.position;
            }
        }
        if (!arrastando && conectado && !connect_1)
        {
            vermelho_azul.transform.position = vermelho.transform.position;
            connect_1 = true;
            vermelho.SetActive(false);
            azul.SetActive(false);
        }
    }
}
