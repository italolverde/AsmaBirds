using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FechaApp : MonoBehaviour
{
    public void FechaJogo()
    {
        Debug.Log("Saiu do Jogo");
        Application.Quit();
    }
}
