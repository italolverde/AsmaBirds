using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class MinigamePanel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Image mgImage;
    [SerializeField] TMP_Text mgText;
    [SerializeField] TMP_Text mgScore;

    internal void updateMGpanel(MinigameStats selectMGindex)
    {
        mgImage.sprite = selectMGindex.cover;
        mgText.SetText(selectMGindex.gameName);
        mgScore.SetText(selectMGindex.score);
    }
    internal void MinigameLoader(MinigameStats selectMGindex)
    {
        SceneManager.LoadScene(selectMGindex.link);
    }
}
