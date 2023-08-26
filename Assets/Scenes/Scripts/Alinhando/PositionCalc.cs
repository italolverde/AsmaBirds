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

    private void calc_taxa_acerto(float alturaref, float alturaobj, float alturamax)
    {
        float diferenca_altura = Mathf.Abs(alturaref - alturaobj);
        float taxa_redução_por_unidade = taxa_maxima / (alturamax - alturaref);

        float taxa_de_acerto = taxa_maxima - diferenca_altura * taxa_redução_por_unidade;
        taxa_de_acerto = Mathf.Max(Mathf.Min(taxa_de_acerto, taxa_maxima), 0);

        Debug.Log($"Taxa de acerto: {taxa_de_acerto.ToString("F")}%");
    }

    public void OnButtonEndConfirm()
    {
        Start();
        calc_taxa_acerto(yrefpos, ynebpos, ymaxh);
    }


}
