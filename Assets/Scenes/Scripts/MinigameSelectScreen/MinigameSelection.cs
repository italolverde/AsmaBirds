using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameSelection : MonoBehaviour
{
    [SerializeField] MinigamePanel mgPanel;

    void Start()
    {
        MinigameList.instance.SelectMGindex = 0;
        UpdateMG();
    }

    public void OnRightClick()
    {
        MinigameList.instance.SelectMGindex++;
        UpdateMG();
    }
    public void OnLeftClick()
    {
        MinigameList.instance.SelectMGindex--;
        UpdateMG();
    }

    private void UpdateMG()
    {
        mgPanel.updateMGpanel(MinigameList.instance.GetCurrent());
    }
    
}
