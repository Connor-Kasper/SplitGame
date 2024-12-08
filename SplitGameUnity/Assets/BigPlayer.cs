using UnityEngine;

public class BigPlayer : MonoBehaviour
{
    [Header("Objects")]
    public GameObject notSplit;
    public GameObject split1;
    public GameObject split2;
    private Rigidbody2D rb;

    [Header("Misc")]
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }
    // Update is called once per frame
    void Update()
    {
        //Activates when the space bar is pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //puts the splits on the scene and sets their x positions to be +- 0.5 where the big split was
            split1.SetActive(true);
            split1.transform.position = notSplit.transform.position;
            split1.transform.position = new Vector3 (split1.transform.position.x - 0.5f, split1.transform.position.y, split1.transform.position.z);


            split2.SetActive(true);
            split2.transform.position = notSplit.transform.position;
            split2.transform.position = new Vector3 (split2.transform.position.x + 0.5f, split2.transform.position.y, split2.transform.position.z);

            //waits for a fraction of a second so they actually start split apart and not just right next to eachother, more for animation and quality sake than anything else.
            StartCoroutine(WaitForSplit(.07f));

            

        }
    }
    //code for waiting
    System.Collections.IEnumerator WaitForSplit(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        //setting the big dude to false
        notSplit.SetActive(false);
    }
}
