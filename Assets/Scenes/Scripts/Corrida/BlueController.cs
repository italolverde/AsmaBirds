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
    private float t = 0.1f;
    private float speed = 1.0f;
    public RaycastHit hit;


    //exibir raycast e detectar contato
    void FixedUpdate()
    {

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector2.right), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * hit.distance, Color.red);
            if (hit.distance < 10)
            {
                int chance = Desvia();

                if (chance < 26)
                {
                    return;
                }
                else if (chance > 26 && chance < 63)
                {
                    if (pos == 0)
                    {
                        Vector2 a = azul.transform.position;
                        Vector2 b = linhaup.transform.position;

                        azul.transform.position = Vector2.MoveTowards(a, Vector2.Lerp(a, b, t), speed);
                        pos = 1;
                    }
                    else if (pos == -1)
                    {
                        Vector2 a = azul.transform.position;
                        Vector2 b = linhamid.transform.position;

                        azul.transform.position = Vector2.MoveTowards(a, Vector2.Lerp(a, b, t), speed);
                        pos = 0;
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    if (pos == 1)
                    {
                        Vector2 a = azul.transform.position;
                        Vector2 b = linhamid.transform.position;

                        azul.transform.position = Vector2.MoveTowards(a, Vector2.Lerp(a, b, t), speed);
                        pos = 0;
                    }
                    else if (pos == 0)
                    {
                        Vector2 a = azul.transform.position;
                        Vector2 b = linhadown.transform.position;

                        azul.transform.position = Vector2.MoveTowards(a, Vector2.Lerp(a, b, t), speed);
                        pos = -1;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 6, Color.green);
        }
    }

    //Chance de desviar
    int Desvia()
    {
        int chance = Random.Range(0, 101);
        return chance;
    }
}
