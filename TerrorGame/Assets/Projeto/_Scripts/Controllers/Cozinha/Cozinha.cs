using Unity.VisualScripting;
using UnityEngine;

public class Cozinha : MonoBehaviour
{
    public AudioSource sino;
    public GameObject chef;

    [Header("Comanda")]
    [SerializeField] private GameObject comanda_;
    [SerializeField] private GameObject mao;
    [SerializeField] private GameObject interface_chef;

    private bool comanda;

    public void Sino()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            if (!comanda)
            {
                sino.Play();
                GetComponent<AudioSource>().Play();
                sino.GetComponent<Animator>().SetTrigger("sino");
                chef.GetComponent<Animator>().SetTrigger("sino");
            }
            else
            {
                sino.Play();
                GetComponent<AudioSource>().Play();
                sino.GetComponent<Animator>().SetTrigger("sino");
                chef.GetComponent<Animator>().SetTrigger("voltar");

                comanda_.SetActive(false);
            }
        }
    }

    public void Comanda()
    {
        comanda_.SetActive(true);
        mao.SetActive(false);
        interface_chef.SetActive(false);

        comanda = true;
    }
}
