using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PowerUp : BackgroundScroll
{
    private float distance = 5.0f;
    [SerializeField] private GameObject linhas;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Powerup")
        {
            speedbg += 0.05f;
            linhas.transform.position += new Vector3(distance, 0, 0);
            Destroy(coll.gameObject);

        }
    }
}
