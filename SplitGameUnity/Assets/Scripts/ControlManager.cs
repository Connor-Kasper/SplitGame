using UnityEngine;

public class ControlManager : MonoBehaviour
{
    public GameObject curController;
    private Rigidbody2D rb;
    public float jumpForce;
    public float speed;
    public GameObject split1;
    public GameObject split2;
    public GameObject notSplit;
    public bool isGrounded;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public Vector2 boxSize = new Vector2(1f, 0.1f);
    public float gColliderOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curController = notSplit;
        rb = curController.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapBox(new Vector3(groundCheck.position.x, (groundCheck.position.y - gColliderOffset), groundCheck.position.z), boxSize, 0f, groundLayer);


        rb = curController.GetComponent<Rigidbody2D>();
        transform.position = curController.transform.position;


        if(curController == notSplit)
        {
            boxSize = new Vector2(1.8f, 0.1f);
        }
        if (curController == split1 || curController == split2)
        {
            boxSize = new Vector2(.8f, 0.1f);
        }


        if (curController == split1 && Input.GetKeyDown(KeyCode.E))
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

    void OnDrawGizmos()
    {
        // Visualize the overlap box in the Scene view
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(new Vector3(groundCheck.position.x, (groundCheck.position.y - gColliderOffset), groundCheck.position.z), boxSize);
        }
    }

}
