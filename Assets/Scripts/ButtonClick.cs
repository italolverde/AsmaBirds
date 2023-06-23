using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private Button buttonclick;
    [SerializeField] private GameObject quadrado;
    private float speed = 16.25f;

    private void Awake()
    {
        buttonclick.onClick.AddListener(cliked);
    }

    private void cliked()
    {
        quadrado.transform.position = new Vector2(quadrado.transform.position.x + speed, quadrado.transform.position.y);
    }
}

