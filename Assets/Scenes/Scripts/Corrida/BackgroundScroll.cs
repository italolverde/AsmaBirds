using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public MeshRenderer mesh;
    public float speed = 0.1f;

    void Start()
    {
        
    }

   
    void Update()
    {
        mesh.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
