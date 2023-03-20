using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Move and jump
    private float horizontal;
    private float speed = 5f;
    private float jumpingPower = 12f;
    private bool isFacingRight = true;
    // Dash
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 30.0f;
    private float dashingTime = 0.25f;
    private float dashingCooldown = 1f;
    // Double Jump
    private bool doubleJump;
    // Wall Slide
    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;
    // Wall Jump
    private bool isWallJumping;
    private float wallJumpingDirection;
    private float WallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(4f, 8f);
    // Coyote time
    // Can still jump 0.2f after leaving the ground
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    // Bounce variable
    private float bounceSpeed = 7f;
    // Player health
    public int maxHealth = 50;
    public int currentHealth;
    // Collectibles
    private int woodCount = 0;
    private int ironCount = 0;
    private int copperCount = 0;
    private int goldCount = 0;
    
    // Serialized Fields
    // Rigidbody, ground check/layer
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Trail effect
    [SerializeField] private TrailRenderer tr;
    // Wall checks
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    // Audio sources
    [SerializeField] private AudioSource jumpEffect;
    [SerializeField] private AudioSource oreCollectEffect;
    [SerializeField] private AudioSource woodCollectEffect;
    [SerializeField] private AudioSource damageEffect;
    [SerializeField] private AudioSource deathEffect;
    // UI labels for collectibles
    [SerializeField] private Text woodText;
    [SerializeField] private Text ironText;
    [SerializeField] private Text copperText;
    [SerializeField] private Text goldText;

    public ParticleSystem dust;
    public HealthBar healthBar;
    private Animator anim;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Run", horizontal != 0);
        anim.SetBool("IsGrounded", IsGrounded());

        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        // If 0 health, player dies
        if (currentHealth == 0)
        {
            //deathEffect.Play();
            //Destroy(gameObject);
        }

        // Coyote time counter
        if(IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        // Disable double jump if player is on the ground
        if(IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        // Double jump
        if (Input.GetButtonDown("Jump"))
        {
            if (coyoteTimeCounter > 0f || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                doubleJump = !doubleJump;
                jumpEffect.Play();
                CreateDust();
            }
        }

        // Jump and reset coyote time counter
        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            jumpEffect.Play();

            coyoteTimeCounter = 0f;
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        // Wall slide - jump methods.
        WallSlide();
        WallJump();

        if (!isWallJumping)
        {
            Flip();
        }
    }

    // Reducing player health and setting as its current health
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void FixedUpdate()
    {
        // Dash
        if (isDashing)
        {
            return;
        }

        if (!isWallJumping)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    // Check player isGrounded
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    // Check player isWalled
    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    // Wall slide
    private void WallSlide()
    {
        if (IsWalled() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    // Wall jump
    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallSliding = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = WallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    // Flip player sprite
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            CreateDust();
        }
    }

    // Dash settings
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

    // Create player dust effect
    void CreateDust()
    {
        dust.Play();
    }

    // Player collision with obsticles
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SpikesDanger"))
        {
            rb.velocity += Vector2.up * bounceSpeed;
            TakeDamage(10);
            damageEffect.Play();
        }
    }

    // Player collision with collectibles
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Wood
        if (collision.gameObject.CompareTag("Wood"))
        {
            woodCollectEffect.Play();
            Destroy(collision.gameObject);
            woodCount++;
            woodText.text = "Wood: " + woodCount;
        }

        // Iron
        if (collision.gameObject.CompareTag("IronOre"))
        {
            oreCollectEffect.Play();
            Destroy(collision.gameObject);
            ironCount++;
            ironText.text = "Iron: " + ironCount;
        }

        // Gold
        if (collision.gameObject.CompareTag("GoldOre"))
        {
            oreCollectEffect.Play();
            Destroy(collision.gameObject);
            goldCount++;
            goldText.text = "Gold: " + goldCount;
        }

        // Copper
        if (collision.gameObject.CompareTag("CopperOre"))
        {
            oreCollectEffect.Play();
            Destroy(collision.gameObject);
            copperCount++;
            copperText.text = "Copper " + copperCount;
        }

        
    }
}
