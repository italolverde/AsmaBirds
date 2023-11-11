using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneChanger : MonoBehaviour 
{    
    public LevelLoader levelLoader;
    public string cena
    public string sceneName;

    public void LoadScene() 
    {

        levelLoader.Transition(sceneName);
    }
    public void SceneChange(){
        SceneManagement.LoadScene(cena)
    }
}
