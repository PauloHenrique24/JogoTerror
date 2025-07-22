using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(AudioSource))]
public class UIButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler , IPointerClickHandler
{
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public GameObject animation_;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null)
        {
            audioSource.PlayOneShot(hoverSound);
            animation_.GetComponent<Animator>().SetBool("hover",true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
            animation_.GetComponent<Animator>().SetTrigger("click");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animation_.GetComponent<Animator>().SetBool("hover",false);
    }
}
