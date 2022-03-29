using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeFusible : MonoBehaviour
{
    Rigidbody rb;
    UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable grab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "fusibleSpace")
        {
            grab.enabled = false;
            gameObject.transform.position = collision.transform.position;
            gameObject.transform.rotation = collision.transform.rotation;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.useGravity = false;
            collision.enabled = false;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
