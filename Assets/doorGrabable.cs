using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorGrabable : UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable
{
    public Transform handler;

    /*protected override void Drop()
    {
        base.Drop();
        transform.position = handler.transform.position;
        transform.rotation = handler.transform.rotation;
    }*/

    protected override void Detach()
    {
        base.Detach();
        transform.position = handler.transform.position;
        transform.rotation = handler.transform.rotation;
    }
}
