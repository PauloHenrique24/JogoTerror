using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    [Header("Texto Dialogo")]
    [SerializeField] private TextMeshProUGUI texto_txt; 
    [SerializeField] private List<DialogoNpc> dialogos_txt;
}
