using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Player")
        {
            collision.gameObject.GetComponent<PlayerCtrl>().IsFloor = true;
        }
    }

    
}

