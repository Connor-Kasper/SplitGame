using UnityEngine;

public class BigPlayer : MonoBehaviour
{
    public GameObject notSplit;
    public GameObject split1;
    public GameObject split2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            split1.SetActive(true);
            split1.transform.position = notSplit.transform.position;
            split1.transform.position = new Vector3 (split1.transform.position.x - 0.5f, split1.transform.position.y, split1.transform.position.z) ;
            split2.SetActive(true);
            split2.transform.position = notSplit.transform.position;
            split2.transform.position = new Vector3 (split2.transform.position.x + 0.5f, split2.transform.position.y, split2.transform.position.z);
            StartCoroutine(WaitForSplit(.07f));
            
        }
    }

    System.Collections.IEnumerator WaitForSplit(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        notSplit.SetActive(false);
    }
}
