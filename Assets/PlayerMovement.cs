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
    private float timeBtwShots;
    private float startTimeBtwShots = 0.25f;
    
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float jumpStrength = 16.5f;
    [SerializeField] private float moveSpeed = 8.5f;

    public enum MovementState { idle, running, fire }
  
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
        MovementState state; 
        

        if (dirX > 0f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            state = MovementState.running;

        }
        else if (dirX <0f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            state = MovementState.running;
        }
        else if (Input.GetButtonDown("Fire1") && (timeBtwShots <= 0))
        {
            state = MovementState.fire;
            timeBtwShots = startTimeBtwShots;
        } 
           
        else
        {
            timeBtwShots -= Time.deltaTime;
            state = MovementState.idle;
        }
        anim.SetInteger("state", (int)state);
    }

        private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .2f, jumpableGround);
    }
}