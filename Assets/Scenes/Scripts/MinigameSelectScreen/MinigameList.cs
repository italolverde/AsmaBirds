using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinigameList : MonoBehaviour
{
    public static MinigameList instance = null;
    [SerializeField] List<MinigameStats> minig_ = new List<MinigameStats>();
    private int selectedMGindex;
    public int SelectMGindex
    { 
        get { return selectedMGindex; } 
        set 
        {
            if (value < 0) return;
            if (value >= minig_.Count) return;

            selectedMGindex = value; 
            currentMinigame = minig_[selectedMGindex];
        } 
    }

    internal MinigameStats currentMinigame;
    void Awake()
    {
        instance = this;
    }

    public MinigameStats GetCurrent()
    {
        var index = SelectMGindex;
        if (index >= minig_.Count || index < 0)  { return null; }
        return minig_[index];
    }
}
