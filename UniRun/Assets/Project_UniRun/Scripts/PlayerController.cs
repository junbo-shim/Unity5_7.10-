using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 450f;

    private int jumpCount = 0;
    private bool isGround = false;
    private bool isDead = false;

    private Rigidbody2D playerRigidBody;
    private Animator animator;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Debug.Assert(playerRigidBody != null);
        Debug.Assert(animator != null);
        Debug.Assert(playerAudio != null);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) 
        {
            return;
        }
        if(Input.GetMouseButtonDown(0) && jumpCount < 2) 
        {
            jumpCount += 1;
            playerRigidBody.velocity = Vector2.zero;
            playerRigidBody.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        else if(Input.GetMouseButtonDown(0) && 
            0 < playerRigidBody.velocity.y) 
        {
            playerRigidBody.velocity = playerRigidBody.velocity * 0.5f;
        }
        animator.SetBool("Ground", isGround);
    }

    private void Die() 
    {
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRigidBody.velocity = Vector2.zero;
        isDead = true;

        GameManager.instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Dead") && isDead == false) 
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (0.7f < collision.contacts[0].normal.y) 
        {
            isGround = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
}
