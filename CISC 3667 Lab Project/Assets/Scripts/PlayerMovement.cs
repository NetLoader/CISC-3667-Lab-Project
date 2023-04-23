using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpingPower = 25f;
    [SerializeField] private AudioSource jumpSFX; 
    [SerializeField] private AudioSource dashingSFX; 
    public bool isFacingRight = true;
    private float horizontal;
    private Animator anim;
    private SpriteRenderer sprite;
    private enum animState {idle, running, jumping, falling}
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    public Transform shootingPoint;
    public GameObject bulletPrefab;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSFX.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            dashingSFX.Play();
            StartCoroutine(Dash());
        }
        if (Keyboard.current.leftAltKey.wasPressedThisFrame || Keyboard.current.jKey.wasPressedThisFrame)
        {
            FirePin();
        }
        Flip();
        AnimationUpdate();
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void AnimationUpdate() 
    {
        animState state;
        //Running & idle
        if (horizontal != 0f)
        {
            state = animState.running;
        } 
        else 
        {
            state = animState.idle;
        }
        //Jumping & Falling
        if (rb.velocity.y > 0.1f)
        {
            state = animState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = animState.falling;
        }
        anim.SetInteger("AnimationState", (int)state);
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    void FirePin()
    {
        GameObject pin = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        if (!isFacingRight)
        {
            pin.transform.Rotate(0, 0, 180f); 
        }
        Rigidbody2D pinRb = pin.GetComponent<Rigidbody2D>();
        pinRb.velocity = new Vector2(transform.localScale.x * 10f, 0f);
    }
}
