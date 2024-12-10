using UnityEngine;
using System;

public class JoinSplits : MonoBehaviour
{
    private ControlManager controlManager;
    public float rayLength;
    public string groundTag = "Ground";
    public string playerTag = "Split2";
    public GameObject split1;
    public GameObject split2;
    public GameObject notSplit;
    public GameObject focusCam;
    private BigPlayer BigScript;
    public float cooldownTime = 3.0f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controlManager = focusCam.GetComponent<ControlManager>();
        BigScript = notSplit.GetComponent<BigPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rayDirection = (transform.position.x < split2.transform.position.x) ? Vector2.right : Vector2.left;

        Vector2 topPosition = new Vector2(transform.position.x, transform.position.y + 0.5f);
        Vector2 bottomPosition = new Vector2(transform.position.x, transform.position.y - 0.5f);
        
        rayLength = Math.Abs(transform.position.x - split2.transform.position.x ) + 1.0f;

        if ((controlManager.curController == split1 || controlManager.curController == split2) && Input.GetKeyDown(KeyCode.Q))
        {
            //This sends out the rays from the top and bottom of split1 depending on the direction of split2
            LayerMask oldLayer = split1.layer;
            split1.layer = 2;

            RaycastHit2D hitTop = Physics2D.Raycast(topPosition, rayDirection, rayLength);
            RaycastHit2D hitBottom = Physics2D.Raycast(bottomPosition, rayDirection, rayLength);

            split1.layer = oldLayer;

            Debug.DrawRay(topPosition, rayDirection * rayLength, Color.red, 0.5f);
            Debug.DrawRay(bottomPosition, rayDirection * rayLength, Color.blue, 0.5f);

            //Debug.Log(hitTop.collider.gameObject.tag);

            //checks if there was any hits on a player from either raycast
            if (hitTop.collider != null)
            {
                if (hitTop.collider.CompareTag(groundTag) || hitBottom.collider.CompareTag(groundTag))
                {
                    //Debug.Log("Ray hit the ground above, stopping!");
                    return; // Stop further execution
                }
                if (hitTop.collider.CompareTag(playerTag) || hitBottom.collider.CompareTag(playerTag))
                {
                    Join();
                    //Debug.Log("Found a player above!");
                }
            }
            else
            {
                //Debug.Log("Top Didn't hit anything");
            }


        }
    }

    void Join()
    {
        notSplit.SetActive(true);

        controlManager.curController = notSplit;
        notSplit.transform.position = new Vector2((transform.position.x + split2.transform.position.x) / 2, (transform.position.y + split2.transform.position.y) / 2);

        BigScript.cooldownUp = false;
        BigScript.JustSplit(cooldownTime);

        split2.SetActive(false);
        split1.SetActive(false);

    }

    
}
