using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PositionCalc : MonoBehaviour
{
    [SerializeField] private GameObject point_ref;
    [SerializeField] private GameObject nebulimetro;
    [SerializeField] private GameObject max_height;

    private float yrefpos;
    private float ynebpos;
    private float ymaxh;

    private float taxa_maxima = 100f; 
    
    void Start()
    {
        point_ref.GetComponent<GameObject>();
        nebulimetro.GetComponent<GameObject>();
        max_height.GetComponent<GameObject>();

        yrefpos = point_ref.transform.position.y;
        ynebpos = nebulimetro.transform.position.y;
        ymaxh = max_height.transform.position.y;
    }

    private void calc_taxa_acerto(float h_alturaref, float h_alturaobj, float alturamax)
    {
        float h_diferenca_altura = Mathf.Abs(h_alturaref - h_alturaobj);
        float h_taxa_redução_por_unidade = taxa_maxima / (alturamax - h_alturaref);

        float h_taxa_de_acerto = taxa_maxima - h_diferenca_altura * h_taxa_redução_por_unidade;
        h_taxa_de_acerto = Mathf.Max(Mathf.Min(h_taxa_de_acerto, taxa_maxima), 0);

        Debug.Log($"Taxa de acerto de altura: {h_taxa_de_acerto.ToString("F")}%");
    }

    public void OnButtonEndConfirm()
    {
        Start();
        calc_taxa_acerto(yrefpos, ynebpos, ymaxh);
    }


}
