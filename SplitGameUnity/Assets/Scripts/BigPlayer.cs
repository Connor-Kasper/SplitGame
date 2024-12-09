using UnityEngine;

public class BigPlayer : MonoBehaviour
{
    [Header("Objects")]
    public GameObject notSplit;
    public GameObject split1;
    public GameObject split2;
    public GameObject focusCam;
    private GameObject focusObj;
    private ControlManager controlManager;

    [Header("Misc")]
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        split1.SetActive(false);
        split2.SetActive(false);
        controlManager = focusCam.GetComponent<ControlManager>();
        controlManager.curController = notSplit;
    }

    // Update is called once per frame
    void Update()
    {
        //Activates when the q key is pressed
        if(Input.GetKeyDown(KeyCode.Q))
        {
            //puts the splits on the scene and sets their x positions to be +- 0.5 where the big split was
            split1.SetActive(true);
            split1.transform.position = notSplit.transform.position;
            split1.transform.position = new Vector3 (split1.transform.position.x - 0.5f, split1.transform.position.y, split1.transform.position.z);

            controlManager.curController = split1;

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