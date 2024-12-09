using UnityEngine;

public class ControlManager : MonoBehaviour
{
    public GameObject curController;
    private Rigidbody2D rb;
    public float jumpForce;
    public float speed;
    public GameObject split1;
    public GameObject split2;
    public bool isGrounded;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float checkRadius = .2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);


        rb = curController.GetComponent<Rigidbody2D>();
        transform.position = curController.transform.position;
        
        if(curController == split1 && Input.GetKeyDown(KeyCode.E))
        {
            curController = split2;
        } else if (curController == split2 && Input.GetKeyDown(KeyCode.E))
        {
            curController = split1;
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

    }
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }
    
}
