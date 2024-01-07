using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgtofinalpoint : MonoBehaviour
{
    [SerializeField] private GameObject quad;
    [SerializeField] private GameObject fim;
    private float t = 45f;
    private void Update()
    {
        if (quad.transform.position.x < fim.transform.position.x)
        {
            quad.transform.position += new Vector3(t * Time.deltaTime, 0, 0);
        }
          

    }
}
