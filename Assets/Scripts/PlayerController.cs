using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float V;
    private float jumpForce;
    private bool jumpBlock;
    private float horizontal;
    private float vertical;
    private Vector2 force;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        V = 3f;
        jumpForce = 40f;
        jumpBlock = false;

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        if(horizontal > 0.1f || horizontal < 0.1f)
        {
            force = new Vector2(horizontal * V, 0f);
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        if (vertical > 0.1f && jumpBlock == false)
        {
            force = new Vector2(0f, vertical * jumpForce);
            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "terrain")
        {
            jumpBlock = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "terrain")
        {
            jumpBlock = true;
        }
    }
}