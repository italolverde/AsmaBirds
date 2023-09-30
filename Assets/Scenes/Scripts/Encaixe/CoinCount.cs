using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    private int score;
    private int score_ui;
    public Text score_txt;
    public Text Ui_end_score;
    void Start()
    {
        score = 0;
        score_txt.text = score.ToString();
    }

    void FixedUpdate()
    {
        if (GameEnd.game_ended)
        {
            if(score_ui < 10)
            {
                score_ui += 1;
                Ui_end_score.text = "+" + score_ui.ToString();
            }
            score = 10;
            score_txt.text = score.ToString();
        }
    }
}
