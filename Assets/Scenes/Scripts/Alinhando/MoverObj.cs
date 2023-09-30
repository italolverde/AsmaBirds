using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObj : MonoBehaviour
{
    Vector2 getmousePos;
    bool _drag = false;
    [SerializeField] private Transform obj;
    private float fixedxpos;
    RaycastHit2D hit;
    private Vector2 offset;
    [SerializeField] private LayerMask layer;
    [SerializeField] private GameObject limite_top;
    [SerializeField] private GameObject limite_bottom;

    private void Start()
    {
        fixedxpos = obj.transform.position.x;
    }

    private void Update()
    {
        getmousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        getmousePos.x = fixedxpos;
        hit = Physics2D.Raycast(getmousePos, Vector2.zero, 0f, layer);
        follow();
    }
    private void follow()
    {
        if(Input.GetMouseButtonDown(0) && hit && _drag == false)
        {
            _drag = true;
            obj = hit.transform;
            float _x = obj.transform.position.x - getmousePos.x;
            float _y = obj.transform.position.y - getmousePos.y;
            offset = new Vector2(_x, _y);
        }
        if (_drag)
        {
            obj.transform.position = getmousePos + offset;


            if(obj.transform.position.y > limite_top.transform.position.y)
            {
                getmousePos.y = limite_top.transform.position.y;
                obj.transform.position = getmousePos + offset;
            }
            else if (obj.transform.position.y < limite_bottom.transform.position.y)
            {
                getmousePos.y = limite_bottom.transform.position.y;
                obj.transform.position = getmousePos + offset;
            }
        }
        if (Input.GetMouseButtonUp(0) && _drag)
        {
            obj = null;
            _drag = false;
            offset = new Vector2(0f, 0f);
        }
    }
   
}
