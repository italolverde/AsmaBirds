using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RotationCalc : MonoBehaviour
{
    public RaycastHit hit;
    [SerializeField] private GameObject maxheight;
    [SerializeField] private GameObject pointref;
    [SerializeField] private Text result_txt;
    [SerializeField] private Text media_txt;

    private float r_taxa_de_acerto;
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

        r_taxa_de_acerto = taxa_maxima - r_diferenca_altura * r_taxa_reducao_por_unidade;
        r_taxa_de_acerto = Mathf.Max(Mathf.Min(r_taxa_de_acerto, taxa_maxima), 0);

        result_txt.text = $"Taxa de acerto de ângulo: {r_taxa_de_acerto.ToString("F")}%";

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
            result_txt.text = "Taxa de acerto de ângulo: 0.00%";
        }
        MediaCalc(PositionCalc.h_taxa_de_acerto, r_taxa_de_acerto);
        
    }

    public void MediaCalc(float taxa_h, float taxa_r)
    {
        float media = (taxa_h + taxa_r) / 2;
        media_txt.text = $"Taxa média de acerto: {media.ToString("F")}%";
    }
}
