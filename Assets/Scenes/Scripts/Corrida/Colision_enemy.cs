using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision_enemy : MonoBehaviour
{
    [SerializeField] GameObject personagem;
    private float distance = -3.0f;
    private float cooldown = 1.0f;
    private float lastHit;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Doença")
        {
            if(Time.time - lastHit < cooldown)
            {
                return;
            }
            lastHit = Time.time;
            personagem.transform.position += new Vector3(distance, 0, 0);
        }
        
    }
}
