using UnityEngine;

public class CloseAndDestroy : MonoBehaviour
{
    public void Destroir()
    {
        Destroy(gameObject);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
