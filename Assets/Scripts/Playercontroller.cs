using Unity.Mathematics;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    public float moveSpeed = 1.0f;
    bool facingRight = true;
    public float jumpSpeed = 1.0f, jumpFrequency=1f,nextJumpTime;
    public bool isGround = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
        OnGroundCheck();
        
        if(playerRB.linearVelocity.x < 0 && facingRight)
        {
            flipFace();
        }
        else if (playerRB.linearVelocity.x > 0 && !facingRight)
        {
            flipFace();
        }
        if(Input.GetAxis("Vertical")>0 && isGround && (nextJumpTime<Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            jump();
        }

    }
    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("playerSpeed",math.abs(playerRB.velocity.x));
    }
    void flipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale=tempLocalScale;
    }
    void jump()
    {
        playerRB.AddForce(new Vector2(0f,jumpSpeed));
    }
    void OnGroundCheck()
    {
       isGround= Physics2D.OverlapCircle(groundCheckPosition.position,groundCheckRadius,groundCheckLayer);
        playerAnimator.SetBool("isGroundedanim", isGround);
    }
}
