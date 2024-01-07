using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Loader(string cena)
    {
        SceneManager.LoadScene(cena);
    }
    
}
