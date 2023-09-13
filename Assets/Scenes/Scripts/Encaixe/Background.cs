using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] MeshRenderer mesh;
    private float speedbg = 0.3f;

    void Update()
    {
        mesh.material.mainTextureOffset += new Vector2(-speedbg * Time.deltaTime, speedbg * Time.deltaTime);
    }
}
