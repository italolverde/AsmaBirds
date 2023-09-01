using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCalc : MonoBehaviour
{
    public RaycastHit hit;
    [SerializeField] private GameObject maxheight;
    [SerializeField] private GameObject pointref;
    private float taxa_maxima = 100f;
    void FixedUpdate()
    {

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.red);

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 16, Color.green);
        }
    }

    private void calc_rotation_acerto(float alturaref, float alturaobj, float alturamax)
    {
        float diferenca_altura = Mathf.Abs(alturaref - alturaobj);
        float taxa_reducao_por_unidade = taxa_maxima / (alturamax - alturaref);

        float taxa_de_acerto = taxa_maxima - diferenca_altura * taxa_reducao_por_unidade;
        taxa_de_acerto = Mathf.Max(Mathf.Min(taxa_de_acerto, taxa_maxima), 0);

        Debug.Log($"Taxa de acerto: {taxa_de_acerto.ToString("F")}%");
    }

    public void OnEndClick()
    {
        pointref.GetComponent<GameObject>();
        maxheight.GetComponent<GameObject>();

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity))
        {
            calc_rotation_acerto(pointref.transform.position.y, hit.transform.position.y, maxheight.transform.position.y);
        }
        else
        {
            Debug.Log($"Taxa de acerto: 0.00%");
        }
        
    }
}
