using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject myDeerMain = GameObject.FindWithTag("Player");
        if (myDeerMain != null)
        {
            float x = myDeerMain.transform.position.x;
            float distance = Mathf.Abs(transform.position.x-x);
            if (distance > 25)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
