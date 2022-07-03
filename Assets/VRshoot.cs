using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRshoot : MonoBehaviour
{
    public SimpleShoot simpleShoot;

    UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable grab;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
