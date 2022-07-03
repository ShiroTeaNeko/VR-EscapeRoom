using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fusibleCounter : MonoBehaviour
{
    //script to manage number of fuses placed to unlock the door

    public int count;
    public GameObject door;
    Rigidbody rb;

    private void Start()
    {
        rb = door.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //check that all fuses are place to unlock the door
        if (count == 4)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
