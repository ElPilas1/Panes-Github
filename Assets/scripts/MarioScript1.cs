using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MarioScript : MonoBehaviour
{
    public KeyCode rightKey, leftKey, jumpKey;
    public float speed, jumpForce, rayDistance;
    public LayerMask groundMask;//mascara de colisiones
    private SpriteRenderer _rend;
    private Rigidbody2D rb;
    private Vector2 dir;
    private bool isJumping = false;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _rend = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        dir = Vector2.zero;
        if (Input.GetKey(rightKey))
        {
            _rend.flipX = false;
            dir = Vector2.right;
        }
        else if (Input.GetKey(leftKey))
        {
            _rend.flipX = false;
            dir = new Vector2(-1, 0);
        }

        // isJumping = false;
        if (Input.GetKeyDown(jumpKey) && IsGrounded())
        {
            isJumping = true;
        }

        if (dir != Vector2.zero)
        {

            //estamos andando
            _animator.SetBool("isWalking", true);

        }
          else
        {
            //estamos parados
            _animator.SetBool("isWalking", false);
        }
    }



    

    private void FixedUpdate()//se ejecuta mas veces
    {
        bool grnd=IsGrounded();
        if(dir != Vector2.zero)
        {
           float currentYVel=rb.velocity.y;
            Vector2 nVel=dir*speed;
            nVel.y = currentYVel;
            rb.velocity = nVel;
          
        }

        if (isJumping && IsGrounded())
        {
            _animator.Play("jump");
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce * rb.gravityScale*rb.drag,ForceMode2D.Impulse);
            isJumping = false;
            _animator.Play("walk");

        }
        print(IsGrounded());
    }

    
    private bool IsGrounded()//se pone un laser desde el personaje hacia abajo y va a detectar la mascara de colisiones que hemos establecido(suelo)
    {
        RaycastHit2D[] collisions = Physics2D.RaycastAll(transform.position, Vector2.down, rayDistance);

        foreach(RaycastHit2D raycastHit in collisions)
        {
            if(raycastHit.collider.gameObject.CompareTag("Suelo"))
            {
                return true;
            }
        }

        return false; // hector has visto los TIKTOKS wake up is the first of the month una bala y estais muertos 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}
