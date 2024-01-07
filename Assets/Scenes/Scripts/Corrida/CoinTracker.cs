using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinTracker : MonoBehaviour
{
    private int score;
    public Text score_txt;
    void Start()
    {
        score = 0;
        score_txt.text = score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Moeda")
        {
            score++;
            Destroy(coll.gameObject);
        }
    }
    void FixedUpdate()
    {
        score_txt.text = score.ToString();
    }
}
