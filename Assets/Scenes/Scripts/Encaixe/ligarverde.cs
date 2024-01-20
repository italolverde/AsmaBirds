using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class ligarverde : MonoBehaviour
{
    public GameObject verde;
    public GameObject roxo;
    void Update()
    {
        if(Connected.conectado)
        {
            verde.SetActive(true);
        }
    }
}
