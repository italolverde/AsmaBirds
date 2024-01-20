using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Connected : MonoBehaviour
{
    public GameObject azul;
    public GameObject vermelho;
    public GameObject roxo;
    public Transform conector;
    private float distancia;
    private float distanciaMinima = 0.8f; // A distância mínima para ativar a conexão
    public static bool conectado;


    private FixedJoint2D joint2D;

    void Start()
    {
        joint2D = conector.GetComponent<FixedJoint2D>();

        if (joint2D == null)
        {
            Debug.LogError("O objeto 'conector' deve ter um componente FixedJoint2D.");
        }
        conectado = false;
    }

    void FixedUpdate()
    {
        distancia = Vector2.Distance(azul.transform.root.position, conector.position);

        if (distancia <= distanciaMinima)
        {
            ConectarAzul();
        }
        else
        {
            return;
        }
    }

    void ConectarAzul()
    {
        azul.transform.position = Vector2.MoveTowards(azul.transform.position, conector.position, 0.04f);

        if(distancia < 0.01f) //chegou
        {
            joint2D.connectedBody = azul.GetComponent<Rigidbody2D>();
            conectado = true;
            azul.SetActive(false);
            vermelho.SetActive(false);
            roxo.transform.position = azul.transform.position;
        }
        
    }
}