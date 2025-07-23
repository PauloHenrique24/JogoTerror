using UnityEngine;
using UnityEngine.InputSystem;

public class InterfaceController : MonoBehaviour
{
    public static bool comanda = true;

    [Header("Comanda Interface")]
    [SerializeField] private GameObject comanda_;
    [SerializeField] private GameObject comanda_interface;

    private bool interfacecomanda;

    public void StartComanda()
    {
        comanda_.SetActive(true);
    }

    public void FecharComanda()
    {
        comanda_.SetActive(false);
    }

    public void OnComanda(InputValue value)
    {
        if (comanda)
        {
            interfacecomanda = !interfacecomanda;
            comanda_interface.SetActive(interfacecomanda);
        }
    }
}
