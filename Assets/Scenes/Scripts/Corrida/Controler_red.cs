using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class Controler_red : MonoBehaviour
{
    private int pos = 0;
    private bool moving = false;
    private float speed = 0.8f;
    [SerializeField] private GameObject personagem;
    [SerializeField] private GameObject linha_up;
    [SerializeField] private GameObject linha_mid;
    [SerializeField] private GameObject linha_down;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (pos < 1)
            {
                moving = true;
                pos++;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (pos > -1)
            {
                moving = true;
                pos--;
            }
        }
    }
    private void FixedUpdate()
    {
        if (pos == 0 && moving)
        {
            Vector2 a = personagem.transform.position;
            Vector2 b = linha_mid.transform.position;

            personagem.transform.position = Vector2.MoveTowards(a, Vector2.Lerp(a,b,speed), speed);

        }
        else if (pos == 1 && moving)
        {
            Vector2 a = personagem.transform.position;
            Vector2 b = linha_up.transform.position;

            personagem.transform.position = Vector2.MoveTowards(a, Vector2.Lerp(a, b, speed), speed);

        }
        else if (pos == -1 && moving)
        {
            Vector2 a = personagem.transform.position;
            Vector2 b = linha_down.transform.position;

            personagem.transform.position = Vector2.MoveTowards(a, Vector2.Lerp(a, b, speed), speed);

        }
    }
}