using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogoMenu : MonoBehaviour
{
    [Header("Dialogo")]
    [SerializeField] private List<DialogoMenuSettings> textos;
    [SerializeField] private TextMeshProUGUI dialogo_txt;

    [Space]
    [SerializeField] private float delay = 0.08f;

    public string SAVE_DIALOG_MENU = "DIALOGOMENU";

    private int indice;
    private AudioSource audio_;

    [SerializeField] private GameObject activeObj;

    void Start()
    {
        audio_ = GetComponent<AudioSource>();

        if (!PlayerPrefs.HasKey(SAVE_DIALOG_MENU))
            StartCoroutine(Dialogo());
        else
        {
            activeObj.SetActive(true);
            dialogo_txt.gameObject.SetActive(false);
        }
    }

    IEnumerator Dialogo()
    {
        dialogo_txt.text = "";

        audio_.clip = textos[indice].sound;
        audio_.Play();

        foreach (char c in textos[indice].texto)
        {
            dialogo_txt.text += c;
            yield return new WaitForSeconds(delay);
        }

        audio_.Stop();
        yield return new WaitForSeconds(textos[indice].delayFinal);

        indice++;

        if (indice < textos.Count)
        {
            StartCoroutine(Dialogo());
        }
        else
        {
            activeObj.SetActive(true);
            PlayerPrefs.SetInt(SAVE_DIALOG_MENU, 1);
            dialogo_txt.gameObject.SetActive(false);
        }
    }

}

[Serializable]
public class DialogoMenuSettings
{
    [TextArea]
    public string texto;

    public AudioClip sound;
    public float delayFinal;
}
