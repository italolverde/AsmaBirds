using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuUi;
    private void Start()
    {
        PauseMenuUi.SetActive(false);
    }

    public void Click2Pause(GameObject PauseMenuUi)
    {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Click2Resume(GameObject PauseMenuUi)
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
    }
}
