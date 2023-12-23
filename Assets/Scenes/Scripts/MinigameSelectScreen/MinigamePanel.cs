using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinigamePanel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] bool showPanel = false;
    [SerializeField] Image mgImage;
    [SerializeField] TMP_Text mgText;
    [SerializeField] TMP_Text mgScore;

    void Start()
    {
        panel.SetActive(showPanel);
    }
    internal void updateMGpanel(MinigameStats selectMGindex)
    {
        mgImage.sprite = selectMGindex.cover;
        mgText.SetText(selectMGindex.gameName);
        mgScore.SetText(selectMGindex.score);
    }
}
