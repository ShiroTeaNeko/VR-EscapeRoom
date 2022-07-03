using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    manager manager;

    // Start is called before the first frame update
    void Start()
    {
        //get manager to change main variable
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //check if bullet hit target
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "target")
        {
            Destroy(collision.gameObject);
            manager.targetDestroyed += 1;
        }
    }
}
