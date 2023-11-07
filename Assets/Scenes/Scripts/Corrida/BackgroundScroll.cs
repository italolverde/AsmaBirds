using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public MeshRenderer mesh;
    private float speedbg = 0.3f;
    
    void Update()
    {
        mesh.material.mainTextureOffset += new Vector2(speedbg * Time.deltaTime, 0);
    }
}
