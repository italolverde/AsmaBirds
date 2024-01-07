using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;
public class Controler_red : MonoBehaviour
{
    [SerializeField] private SwipeListener _swipeListener;
    private string swipeInput;
    private int pos = 0;
    private bool moving = false;
    private float speed = 0.8f;
    [SerializeField] private GameObject personagem;
    [SerializeField] private GameObject linha_up;
    [SerializeField] private GameObject linha_mid;
    [SerializeField] private GameObject linha_down;


    private void OnEnable()
    {
        _swipeListener.OnSwipe.AddListener(OnSwipe);
    }

    private void OnSwipe(string swipe)
    {
        swipeInput = swipe;
        Debug.Log(swipe);
    }
    private void OnDisable()
    {
        _swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }
    private void Update()
    {
        if (swipeInput == "Up")
        {
            if (pos < 1)
            {
                moving = true;
                pos++;
                swipeInput = " ";
            }
        }
        if (swipeInput == "Down")
        {
            if (pos > -1)
            {
                moving = true;
                pos--;
                swipeInput = " ";
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