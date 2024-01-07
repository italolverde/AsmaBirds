using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public MeshRenderer mesh;
    public static float speedbg = 0.2f;
    
    void Update()
    {
        mesh.material.mainTextureOffset += new Vector2(speedbg * Time.deltaTime, 0);
    }
}
