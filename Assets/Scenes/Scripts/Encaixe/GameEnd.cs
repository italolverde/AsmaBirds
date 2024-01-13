using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField] GameObject verde;
    [SerializeField] GameObject roxo;
    [SerializeField] GameObject conector;
    [SerializeField] GameObject ui_endgame;
    static public bool game_ended = false;

    void Awake(){
        game_ended = false;
    }
    
    void Update()
    {
        if(verde.transform.position == conector.transform.position && game_ended == false)
        {
            game_ended = true;
            ui_endgame.SetActive(true);
            roxo.SetActive(false);
            verde.SetActive(false);
        }
    }
}
