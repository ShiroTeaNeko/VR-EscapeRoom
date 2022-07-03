using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    public GameObject leverChild;
    HingeJoint hingeJoint;
    public Light light;

    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = leverChild.GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hingeJoint.angle);

        if (hingeJoint.angle >= 70f)
        {
            // == 1

            light.enabled = true;
        }
        else if (hingeJoint.angle <= 10f)
        {
            // ==0

            light.enabled = false;
        }
    }
}
