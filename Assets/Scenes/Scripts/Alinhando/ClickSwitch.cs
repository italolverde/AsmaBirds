using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ClickSwitch : MonoBehaviour
{
    [SerializeField] GameObject buttondisable;
    [SerializeField] GameObject buttonactivate;
    public void OnButtonClick()
    {
        if (GetComponent<MoverObj>().enabled)
        {
            buttonactivate = GetComponent<GameObject>();
            buttondisable = GetComponent<GameObject>();

            GetComponent<MoverObj>().enabled = false;
            GetComponent<SpinObject>().enabled = true;
            buttonactivate.SetActive(true);
            buttondisable.SetActive(false);
            


            
        }
    }
}
