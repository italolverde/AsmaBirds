using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField] GameObject verde;
    [SerializeField] GameObject roxo;
    [SerializeField] Transform conector;
    private float distanciaMinima = 0.8f;
    [SerializeField] GameObject ui_endgame;
    static public bool game_ended = false;

    void Awake(){
        game_ended = false;
    }
    
    void FixedUpdate()
    {
        float distancia = Vector2.Distance(verde.transform.position, conector.position);

        if(distancia <= distanciaMinima && game_ended == false)
        {
            verde.transform.position = Vector2.MoveTowards(verde.transform.position, conector.position, 0.03f);

            if(distancia < 0.01f) //chegou
            {
            game_ended = true;
            ui_endgame.SetActive(true);
            roxo.SetActive(false);
            verde.SetActive(false);
            }
        }
    }
}
