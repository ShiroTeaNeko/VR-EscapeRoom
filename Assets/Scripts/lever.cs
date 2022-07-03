using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    //manage all levers for enigma 2
    manager manager;
    public GameObject leverChild;
    HingeJoint hingeJoint;
    public Light light;

    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = leverChild.GetComponent<HingeJoint>(); 
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<manager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hingeJoint.angle);

        // if lever is down
        if (hingeJoint.angle <= 10f)
        {
            // == 1

            light.enabled = false;
        }
        //if lever is up
        else if (hingeJoint.angle >= 80f)
        {
            // ==0

            light.enabled = true;
        }
    }

}
