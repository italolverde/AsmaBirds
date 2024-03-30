using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocList : MonoBehaviour
{
    public static DocList Instance = null;
    [SerializeField] List<DocStats> pages = new List<DocStats>();

    private int selectedPageIndex;

    public int SelectPageIndex
    {
        get{ return selectedPageIndex; }
        set
        { 
            if(value < 0) return; 
            if(value >= pages.Count) return;

            selectedPageIndex = value; 
            currentPage = pages[selectedPageIndex];
        }
    }

    internal DocStats currentPage;
    
    void Awake()
    {
        Instance = this;
    }

}
