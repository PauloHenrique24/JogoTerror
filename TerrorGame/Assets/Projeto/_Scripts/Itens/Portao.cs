using UnityEngine;

public class Portao : MonoBehaviour
{
    void Start()
    {
        // Adiciona um FixedJoint
        FixedJoint joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = null; // NULL = preso no mundo
    }
}
