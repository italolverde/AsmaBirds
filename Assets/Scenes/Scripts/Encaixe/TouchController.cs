using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    private Vector2 touchStartPos;
    private bool isDragging = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        HandleTouchInput();
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("Começou");
                    Vector2 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);
                    bool touchingObject = IsTouchingObjectWithLayer(touchWorldPos, "Drag");
                    if (touchingObject)
                    {
                        isDragging = true;
                        touchStartPos = Camera.main.ScreenToWorldPoint(touch.position);
                    }
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        Vector2 currentTouchPos = Camera.main.ScreenToWorldPoint(touch.position);
                        Vector2 touchDelta = currentTouchPos - touchStartPos;
                        rb.MovePosition(rb.position + touchDelta);
                        touchStartPos = currentTouchPos;
                    }
                    break;

                case TouchPhase.Ended:
                    Debug.Log("Terminou");
                    isDragging = false;
                    break;
                    
                case TouchPhase.Canceled:
                    Debug.Log("Terminou");
                    isDragging = false;
                    break;
            }
        }
    }

    bool IsTouchingObjectWithLayer(Vector2 touchPosition, string layerName)
    {
        int layerMask = LayerMask.GetMask(layerName);
        Collider2D collider = Physics2D.OverlapPoint(touchPosition, layerMask);
        if (collider != null)
        {
            bool touchingThisObject = (collider.gameObject == gameObject);
            Debug.Log("Touching object with layer: " + touchingThisObject);
            return touchingThisObject;
        }
        else
        {
            Debug.Log("Not touching object with layer");
            return false;
        }
    }
}