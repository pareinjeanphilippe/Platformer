using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    private SpriteRenderer sp;

    void Awake()
    {
        //Assignation des variables
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    void OnMove(InputValue value) => moveInput = value.Get<Vector2>();
    
    void Update()
    {
        //Animations marche
        animator.SetFloat("val_x", Mathf.Abs(moveInput.x));
        if (moveInput.x < 0) sp.flipX = true;
        if (moveInput.x > 0) sp.flipX = false;
    }

    void FixedUpdate()
    {
        //Movemement gauche droite
        Vector2 v = rb.linearVelocity;
        v.x = moveInput.x * moveSpeed;
        rb.linearVelocity = v;
    }
}
