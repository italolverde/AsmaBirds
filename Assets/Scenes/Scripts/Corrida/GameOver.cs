using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameoverscreen;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Gameover")
        {
            Time.timeScale = 0f;
            gameoverscreen.SetActive(true);
        }
    }
}
