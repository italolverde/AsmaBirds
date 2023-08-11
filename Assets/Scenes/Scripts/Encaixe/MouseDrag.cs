using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MouseDrag : MonoBehaviour
{
    Vector3 posInicial;
    Vector3 posDestino;
    Vector3 vetorDirecao;
    Rigidbody2D _rigidbody;
    FixedJoint2D _fixedjoint;
    bool arrastando;
    float distancia;
    Vector2 zerado; 
    [HideInInspector]
    public bool conectado;
    [Range(1, 15)]
    public float movespeed = 15;
    public Rigidbody2D peca;
    public Transform conector;
    [Range(0.1f, 2.0f)]
    public float distanciaMinimaConector;
    void Start()
    {
        _rigidbody = transform.root.GetComponent<Rigidbody2D>();
        //_rigidbody.gravityScale = 1;
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
    private void OnMouseUp()
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
        if(!arrastando && !conectado)
        {
            distancia = Vector2.Distance(transform.root.position, conector.position);
            if (distancia < distanciaMinimaConector)
            {
                _rigidbody.velocity = Vector2.zero;
                transform.root.position = Vector2.MoveTowards(transform.root.position, conector.position, 0.02f);

            }
            if(distancia < 0.01f ) //Chegou
            {
                GetComponent<FixedJoint2D>().enabled = true;
                
                conectado = true;
                transform.root.position = conector.position;
            }
        }
    }
    void Update()
    {
       
        
    }
}
