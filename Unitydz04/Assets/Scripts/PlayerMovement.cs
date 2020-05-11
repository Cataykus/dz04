using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _runSpeed;
    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private SpriteRenderer playerSpriteRenderer;

    private bool isGround = true;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            playerRigidbody.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
            isGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //playerRigidbody.MovePosition(playerRigidbody.position + Vector2.left * _runSpeed * Time.fixedDeltaTime);


            playerRigidbody.velocity = new Vector2(-1f * _runSpeed * Time.fixedDeltaTime * 100f, playerRigidbody.velocity.y);


            playerSpriteRenderer.flipX = true;
            playerAnimator.SetInteger("State", 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //playerRigidbody.MovePosition(playerRigidbody.position + Vector2.right * _runSpeed * Time.fixedDeltaTime);


            playerRigidbody.velocity = new Vector2(1f * _runSpeed * Time.fixedDeltaTime * 100f, playerRigidbody.velocity.y);


            playerSpriteRenderer.flipX = false;
            playerAnimator.SetInteger("State", 1);
        }
        else
        {
            playerAnimator.SetInteger("State", 0);
        }
    }
}
