using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private CheckGround _checkGround;

    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private SpriteRenderer playerSpriteRenderer;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (playerRigidbody.velocity.y > 0.1f)
        {
            playerAnimator.SetInteger("State", 2);
        }
        else if (playerRigidbody.velocity.y < -0.1f)
        {
            playerAnimator.SetInteger("State", 3);
        }
        else
        {
            if (playerRigidbody.velocity.x < -0.1f || playerRigidbody.velocity.x > 0.1f)
            {
                playerAnimator.SetInteger("State", 1);
            }
            else
            {
                playerAnimator.SetInteger("State", 0);
            }
        }

        if (_checkGround.IsGround && Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.velocity = Vector2.up * _jumpForce;
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody.velocity = new Vector2(-1f * _runSpeed * Time.fixedDeltaTime * 100f, playerRigidbody.velocity.y);

            playerSpriteRenderer.flipX = true;      
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerRigidbody.velocity = new Vector2(1f * _runSpeed * Time.fixedDeltaTime * 100f, playerRigidbody.velocity.y);

            playerSpriteRenderer.flipX = false;
        }
        else
        {
            playerRigidbody.velocity = new Vector2(0f, playerRigidbody.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<OpposumMovement>(out OpposumMovement enemy))
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
