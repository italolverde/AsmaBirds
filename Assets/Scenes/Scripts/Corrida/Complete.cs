using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complete : MonoBehaviour
{
    [SerializeField] private GameObject blue;
    [SerializeField] private GameObject red;
    [SerializeField] private GameObject rdgrid;
    [SerializeField] private GameObject BeB;
    [SerializeField] private GameObject BeR;
    [SerializeField] private GameObject gamelost;
    [SerializeField] private GameObject gamewin;
    private coin_increment increment;
    private float t = 0.3f;
    private bool bluewin;
    private bool redwin;

    private void Start()
    {
        gamelost.SetActive(false);
        gamewin.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "finish")
        {
            float bluePosX = blue.transform.position.x;
            float redPosX = red.transform.position.x;
            if(bluePosX > redPosX)
            {
                bluewin = true;
            }
            else if(redPosX > bluePosX)
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
            gamelost.SetActive(true);
            red.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (redwin)
        {
            gamewin.SetActive(true);
            blue.GetComponent<BoxCollider2D>().enabled = false;
            increment.adicionaMoedas(redwin);
            
        }
        else
        {
            Debug.Log("Empate!!!");
        }
    }
    private void FixedUpdate()
    {
        if(redwin)
        {
            Vector2 a = blue.transform.position;
            Vector2 b = BeB.transform.position;

            blue.transform.position = Vector2.MoveTowards(a, Vector2.Lerp(a,b,t), t);
        }
        else if (bluewin)
        {
            Vector2 a = rdgrid.transform.position;
            Vector2 b = BeR.transform.position;

            rdgrid.transform.position = Vector2.MoveTowards(a, Vector2.Lerp(a, b, t), t);
        }
    }
}