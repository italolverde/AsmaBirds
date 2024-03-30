using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocSelection : MonoBehaviour
{
    [SerializeField] DocPanel mainPage;
    void Start()
    {
        DocList.Instance.SelectPageIndex = 0;
        if(mainPage != null)
        {
            UpdatePage();
        }
    }


    public void OnUpButton()
    {
        DocList.Instance.SelectPageIndex--;
        UpdatePage();
    }
    public void OnDownButton()
    {
        DocList.Instance.SelectPageIndex++;
        UpdatePage();
    }
    private void UpdatePage()
    {
        if(mainPage != null)
        {
            mainPage.UpdateDocPage(DocList.Instance.currentPage);
        }
    }
}
