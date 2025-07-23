using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController current;

    [Header("Sensibilidade")]
    public static float MouseSensitivity = 1f;

    void Start()
    {
        DontDestroyOnLoad(this);

        if (current == null) current = this;
        else Destroy(gameObject);

        MouseSensitivity = PlayerPrefs.GetFloat("Sensitivity", 1f);
    }
}
