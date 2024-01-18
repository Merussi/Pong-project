using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Vector2 startingVelocity = new Vector2(5f, 5f);

    public GameManager gameManager;

    public float speedUp = 1.1f;

    [SerializeField] float powerUp = 2f;

    [SerializeField] bool isPowered = false;

    public void ResetBall()
    {
        transform.position = Vector3.zero;

        if(rb == null) rb = GetComponent<Rigidbody2D>();
        rb.velocity = startingVelocity;
        gameManager.DesactivePower();
        isPowered = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.velocity;

            newVelocity.y = -newVelocity.y;
            rb.velocity = newVelocity;

        }

        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            rb.velocity *= speedUp;
            gameManager.ActivePower();
        }
        if (collision.gameObject.CompareTag("WallEnemy"))
        {
            gameManager.ScorePlayer();
            ResetBall();
        }
        if (collision.gameObject.CompareTag("WallPlayer"))
        {
            gameManager.EnemyScore();
            ResetBall();
        }
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp") && isPowered == false)
        {
            rb.velocity *= speedUp;
            isPowered = true;
        }
    }
}
