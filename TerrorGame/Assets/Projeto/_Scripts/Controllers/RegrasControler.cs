using TMPro;
using UnityEngine;

public class RegrasControler : MonoBehaviour
{
    
    [Header("Texto")]
    [SerializeField] private GameObject regra_interface;
    [SerializeField] private TextMeshProUGUI regra_txt;
    [SerializeField] private TextMeshProUGUI texto_txt;

    [Header("Iniciar")]
    [SerializeField] private GameObject Regras;

    public void OpenFolha(int num, string texto)
    {
        regra_interface.SetActive(true);

        regra_txt.text = num + " . Regra";
        texto_txt.text = texto;
    }

    public void Iniciar()
    {
        Regras.SetActive(false);
    }
}
 