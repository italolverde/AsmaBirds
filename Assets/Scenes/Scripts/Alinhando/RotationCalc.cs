using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCalc : MonoBehaviour
{
    public RaycastHit hit;
    [SerializeField] private GameObject maxheight;
    [SerializeField] private GameObject pointref;
    private float taxa_maxima = 100f;

    private void Start()
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

    private void calc_rotation_acerto(float r_point, float r_hitimpact, float r_alturamax)
    {
        float r_diferenca_altura = Mathf.Abs(r_point - r_hitimpact);
        float r_taxa_reducao_por_unidade = taxa_maxima / (r_alturamax - r_point);

        float r_taxa_de_acerto = taxa_maxima - r_diferenca_altura * r_taxa_reducao_por_unidade;
        r_taxa_de_acerto = Mathf.Max(Mathf.Min(r_taxa_de_acerto, taxa_maxima), 0);

        Debug.Log($"Taxa de acerto de ângulo: {r_taxa_de_acerto.ToString("F")}%");

    }

    public void OnEndClick()
    {
        pointref.GetComponent<GameObject>();

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity))
        {
            calc_rotation_acerto(pointref.transform.position.y, hit.point.y, maxheight.transform.position.y);
        }
        else
        {
            Debug.Log($"Taxa de acerto: 0.00%");
        }
        
    }

    public void MediaCalc(float taxa_h, float taxa_r)
    {
        float media = (taxa_h + taxa_r) / 200;
        Debug.Log($"Taxa média de acerto: {media.ToString("F")}");
    }
}
