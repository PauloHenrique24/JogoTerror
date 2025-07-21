using UnityEngine;
using UnityEngine.InputSystem;

public class RegrasPapel : MonoBehaviour
{
    public int numeroRegra;
    [TextArea]
    public string texto;

    public void OpenRegras()
    {
        FindFirstObjectByType<RegrasControler>().OpenFolha(numeroRegra, texto);
    }
}
