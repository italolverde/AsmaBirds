using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complete : MonoBehaviour
{
    [SerializeField] private GameObject blue;
    [SerializeField] private GameObject red;
    [SerializeField] private GameObject BeB;
    [SerializeField] private GameObject BeR;
    private bool end = false;
    private float t = 0.3f;
    private bool bluewin;
    private bool redwin;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "finish")
        {
            float bluePos = blue.transform.position.x;
            float redPos = red.transform.position.x;
            if(bluePos > redPos)
            {
                bluewin = true;
            }
            else if(redPos > bluePos)
            {
                redwin = true;
            }
            OnLineCross();
        }
    }
    private void OnLineCross()
    {
        if (bluewin)
        {
            Debug.Log("Você perdeu!");
            red.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (redwin)
        {
            Debug.Log("Você venceu! Parabéns!");
            blue.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            Debug.Log("Empate!!!");
        }
        end = true;
    }
    private void FixedUpdate()
    {
        if (end)
        {
            Vector2 a = blue.transform.position;
            Vector2 b = BeB.transform.position;

            blue.transform.position = Vector2.MoveTowards(a, Vector2.Lerp(a,b,t), t);
        }
    }
}