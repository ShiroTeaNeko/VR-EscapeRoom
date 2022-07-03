using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorGrabable : UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable
{
    //Script that can interact with door handler to move them
    public Transform handler;

    protected override void Detach()
    {
        base.Detach();
        transform.position = handler.transform.position;
        transform.rotation = handler.transform.rotation;
    }
}
