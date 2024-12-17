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
    public Vector2 boxSize = new Vector2(1.1f, 0.01f);
    public float gColliderOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

        curController = notSplit;
        rb = curController.GetComponent<Rigidbody2D>();
        split1.layer = default;
    }

    // Update is called once per frame
    void Update() {

        //Makes a ray box and checks if it is touching a ground object
        isGrounded = Physics2D.OverlapBox(new Vector3(groundCheck.position.x, (groundCheck.position.y - gColliderOffset), groundCheck.position.z), boxSize, 0f, groundLayer);

        //turns rb to be the current player character
        rb = curController.GetComponent<Rigidbody2D>();
        //Puts the Focus Cam at the position of the current character
        transform.position = curController.transform.position;

        //Determines the box size for the isGrounded
        if(curController == notSplit) {

            boxSize = new Vector2(1.8f, 0.1f);
        }

        if (curController == split1 || curController == split2) {

            boxSize = new Vector2(.8f, 0.1f);
        }

        //Makes the splits part of the ground if they are not the current character
        if (curController == split1 && Input.GetKeyDown(KeyCode.E)) {

            curController = split2;
            split1.layer = 6;
            split2.layer = default;

        } 
        
        else if (curController == split2 && Input.GetKeyDown(KeyCode.E)) {

            curController = split1;
            split2.layer = 6;
            split1.layer = default;
        }

        //Jump!
        if (Input.GetKeyDown(KeyCode.W) && isGrounded) {

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void FixedUpdate() 
    {
        //Moves Char Left/Right
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