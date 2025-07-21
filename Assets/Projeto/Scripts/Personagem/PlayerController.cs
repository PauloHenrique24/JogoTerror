using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movimentação")]
    [SerializeField] private float speed = 3f;

    private Vector3 inputs;
    private Animator anim;

    private bool _isFacing;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        SetMoviment();
    }

    public void OnMove(InputValue value)
    {
        inputs = value.Get<Vector2>();
    }

    public void SetMoviment()
    {
        Vector3 mov = inputs.normalized;
        transform.position += mov * speed * Time.deltaTime;

        if (mov != Vector3.zero)
        {
            anim.SetBool("walk", true);

            anim.SetFloat("x", mov.x);
            anim.SetFloat("y", mov.y);
        }
        else anim.SetBool("walk", false);

        if (mov.x < 0 && _isFacing) Flip();
        else if(mov.x > 0 && !_isFacing) Flip();

    }

    void Flip()
    {
        _isFacing = !_isFacing;
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
