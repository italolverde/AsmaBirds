using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class BlueController : MonoBehaviour
{
    [SerializeField] GameObject azul;
    [SerializeField] GameObject linhaup;
    [SerializeField] GameObject linhamid;
    [SerializeField] GameObject linhadown;
    private int pos = 0;
    private float speed = 0.5f;
    private int chance = 0;
    private bool moving = false;

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Doença")
        {
            chance = Desvia();
        }
    }
    void FixedUpdate()
    {
        //nada ocorre
        if (chance < 10)
        {
            return;
        }
        //subindo
        else if (chance > 10 && chance < 55)
        {
            moving = true;

            if (pos == 0)
            {
                while (pos == 0 && moving)
                {
                    Vector2 a = azul.transform.position;
                    Vector2 b = linhaup.transform.position;

                    azul.transform.position = Vector2.MoveTowards(a, b, speed);
                    if (a == b)
                    {
                        pos = 1;
                        moving = false;
                    }

                }
            }
           
            else if (pos == -1)
            {
                while (pos == -1 && moving)
                {
                    Vector2 a = azul.transform.position;
                    Vector2 b = linhamid.transform.position;

                    azul.transform.position = Vector2.MoveTowards(a, b, speed);
                    if (a == b)
                    {
                        pos = 0;
                        moving = false;
                    }

                }
            }
        }
        //desce
        else
        {
            if (pos == 1)
            {
                while (pos == 1 && moving)
                {
                    Vector2 a = azul.transform.position;
                    Vector2 b = linhamid.transform.position;

                    azul.transform.position = Vector2.MoveTowards(a, b, speed);
                    if (a == b)
                    {
                        pos = 0;
                        moving = false;
                    }

                }


            }
            else if (pos == 0)
            {
                while (pos == 0 && moving)
                {
                    Vector2 a = azul.transform.position;
                    Vector2 b = linhadown.transform.position;

                    azul.transform.position = Vector2.MoveTowards(a, b, speed);
                    if (a == b)
                    {
                        pos = -1;
                        moving = false;
                    }

                }
            }
        }
        
    }

    //Chance de desviar
    int Desvia()
    {
        int rng = Random.Range(0, 101);
        return rng;
    }
}
