using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] private Jump playerJumps;
    private bool playerOnFloor;
    private SoundManager soundManager;
    private ParticleSystem rainbowParticles;

    [SerializeField]
    private float runningSpeed;

    [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private float flySpeed;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        soundManager = GetComponent<SoundManager>();
        rainbowParticles = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");

        UpdatePlayerPosition(horizontalInput);

        UpdatePlayerFacing(horizontalInput);

        UpdatePlayerAnimation(horizontalInput);
    }

    private void UpdatePlayerAnimation(float horizontalInput)
    {
        animator.SetBool("WillRun", horizontalInput != 0);
        animator.SetBool("PlayerOnFloor", playerOnFloor);
    }

    private void UpdatePlayerPosition(float horizontalAxis)
    {
        body.velocity = new Vector2(horizontalAxis * runningSpeed, body.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && playerJumps.JumpsAreLessThanMax())
        {
            Jump();
        }
        else if (Input.GetKey(KeyCode.Space) && playerJumps.AreEqualToMax())
        {
            Fly();
        }
    }

    private void Fly()
    {
        UpdatePlayerYVelocity(flySpeed);
        rainbowParticles.Play();
    }

    private void Jump()
    {
        animator.SetTrigger("jump");
        UpdatePlayerYVelocity(jumpSpeed);
        SetPlayerOnFloor(false);
        soundManager.PlayJumpSound();
    }

    private void UpdatePlayerYVelocity(float amount)
    {
        body.velocity = new Vector2(body.velocity.x, amount);
    }

    public void SetPlayerOnFloor(bool onFloor)
    {
        this.playerOnFloor = onFloor;
        rainbowParticles.Stop();
    }

    private void UpdatePlayerFacing(float horizontalInput)
    {
        if (horizontalInput > 0.001f)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput < -0.001f)
        {
            spriteRenderer.flipX = false;
        }
    }
}
