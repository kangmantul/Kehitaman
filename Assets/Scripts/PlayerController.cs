using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpforce;
    [SerializeField] float movespeed;
    private Animator anim;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX * movespeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (moveX > 0.01f)
            transform.localScale = new Vector3(3, 3, 3);

        else if(moveX < -0.01f)
            transform.localScale = new Vector3(-3, 3, 3);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        anim.SetBool("run", moveX != 0);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
