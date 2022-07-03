using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fusibleCounter : MonoBehaviour
{
    public int count;
    public GameObject door;
    Rigidbody rb;

    private void Start()
    {
        rb = door.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (count == 4)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
