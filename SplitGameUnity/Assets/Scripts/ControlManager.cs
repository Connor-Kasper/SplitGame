using UnityEngine;

public class ControlManager : MonoBehaviour
{
    public GameObject curController;
    private Rigidbody2D rb;
    public float speed;
    public GameObject split1;
    public GameObject split2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = curController.transform.position;
        rb = curController.GetComponent<Rigidbody2D>();
        if(curController == split1 && Input.GetKeyDown(KeyCode.E))
        {
            curController = split2;
        } else if (curController == split2 && Input.GetKeyDown(KeyCode.E))
        {
            curController = split1;
        }
    }
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }
}
