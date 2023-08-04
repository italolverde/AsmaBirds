using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpnDown : MonoBehaviour
{
    private Vector3 mousePos;
    private float startPosX;
    private float startPosY;
    private bool dragging = false;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosY = mousePos.y - transform.localPosition.y;
            startPosX = mousePos.x - transform.localPosition.x;

            dragging = true;
        }
    }
    private void Update()
    {
        if (dragging)
        {
            gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0f);

            if (gameObject.transform.localPosition.y > 4.99f)
            {
                mousePos.y = 4.99f;
            }
            else if (gameObject.transform.localPosition.y < -4.99f)
            {
                mousePos.y = -4.99f;
            }
        }
    }
    private void OnMouseUp()
    {
        dragging = false;
    }
}