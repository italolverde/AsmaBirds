using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ligarverde : MonoBehaviour
{
    public GameObject verde;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<FixedJoint2D>().enabled == true)
        {
            verde.SetActive(true);
        }
    }
}
