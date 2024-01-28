using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private Animator anim;
        private float dirX = 0f;
    
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float jumpStrength;
    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (DialogManager.isActive == true)
        return;

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
        }
        UpdateAnimationUpdate();
            }
    private void UpdateAnimationUpdate()
    {
        if (dirX > 0f)
        {
            //anim.SetBool("running", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (dirX <0f)
        {
            //anime.SetBool("running", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            //anim.SetBool("running", false);
        }
    }
        private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .2f, jumpableGround);
    }
}