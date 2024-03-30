using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DocPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI page_txt;

    internal void UpdateDocPage(DocStats docStats)
    {
        // Substitua as quebras de linha no texto do ScriptableObject por "\n"
        string formattedText = docStats.Doc_text.Replace("\\n", "\n");

        page_txt.text = formattedText;
        page_txt.alignment = TextAlignmentOptions.Left;
        page_txt.ForceMeshUpdate();
    }
}