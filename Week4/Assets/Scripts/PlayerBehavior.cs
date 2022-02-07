using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [Header("Player Movement")]
    
    public float horizontalForce;
    public float verticalForce;

    [Header("Ground Detection")]
    public Transform Groundcheck;
    public float groundRadious;
    public LayerMask groundLayerMask;
    public bool isGrounded;
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        //isGrounded = Physics2D.Linecast(transform.position, Groundcheck.position);
        isGrounded = Physics2D.OverlapCircle(Groundcheck.position, groundRadious, groundLayerMask);
        
        if(isGrounded)
        {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Jump");

        if(x != 0)
        {
            x = Flip(x);

            //animation
        }
        Vector2 move = new Vector2( x * horizontalForce, y * verticalForce );
        rigidbody2D.AddForce(move);
        }
    }
    
    private float Flip(float x)
    {
        //uses the Temporary operator
        x = (x > 0) ? 1 : -1;

        transform.localScale = new Vector3(x, 1.0f);
        
        return x;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(Groundcheck.position, groundRadious);
        //Gizmos.DrawLine(transform.position, Groundcheck.position);
    }
}
