using UnityEngine;

public class Cozinha : MonoBehaviour
{
    public AudioSource sino;
    public void Sino()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            sino.Play();
            GetComponent<AudioSource>().Play();
            sino.GetComponent<Animator>().SetTrigger("sino");
        }
    }
}
