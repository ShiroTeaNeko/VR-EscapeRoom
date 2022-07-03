using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class manager : MonoBehaviour
{
    //Main manager to handle main action in scene

    private ActionBasedController leftController = null;
    private ActionBasedController rightController = null;
    public GameObject leftHand;
    public GameObject rightHand;

    public List<GameObject> targets = new();

    public List<GameObject> fusibles = new();

    public List<GameObject> levers = new();
    Vector3 baseLeverPos = new Vector3(0f, 0f, 308.609985f);
    Vector3 finalLeverPos = new Vector3(0f, 0f, 140f);

    public List<Light> lights = new();


    public Transform fusibleTargetPosition;
    public Transform fusibleLeverPosition;

    public int targetDestroyed = 0;
    public int lightOn = 0;

    bool isLever1;
    bool isLever2;
    bool isLever3;
    bool isLever4;
    bool isTriggerPressed;
    bool areAllLightsON;

    AudioSource audio;
    AudioSource audioDebug;

    private void Awake()
    {
        leftController = leftHand.GetComponent<ActionBasedController>();
        rightController = rightHand.GetComponent<ActionBasedController>();
    }

    private void Start()
    {
        //audioDebug = GetComponent<AudioSource>();
    }


    private void Update()
    {
        //Debug.Log(isTriggerPressed);
        if (leftController.selectAction.action.ReadValue<float>() >= 0.1f || rightController.selectAction.action.ReadValue<float>() >= 0.1f)
        {
            isTriggerPressed = true;
        }
        
        //check if all 4 target are destroyed to make the fuse appear with a sound
        if (targetDestroyed >= 4)
        {
            fusibles[0].transform.position = fusibleTargetPosition.position;
            audio = fusibles[0].GetComponent<AudioSource>();
            audio.Play();
            targetDestroyed = 0;
        }

        //check if all 4 lights are enabled to make the fuse appear with a sound
        if (AreAllLightEnabled() && !areAllLightsON)
        {
            fusibles[1].transform.position = fusibleLeverPosition.position;
            audio = fusibles[1].GetComponent<AudioSource>();
            audio.Play();
            areAllLightsON = true;
        }
    }

    //boolean to check if all lights are on
    bool AreAllLightEnabled()
    {
        foreach (Light light in lights)
        {
            if (light.enabled == false)
            {
                return false;
            }
        }
        return true;
    }

    // ALL LeverXDown manage each lever to set other status to on or off

    public void Lever1Down()
    {

        if (levers[0].GetComponent<HingeJoint>().angle >= 70f /*&& isLever1 == false*/ && isTriggerPressed)
        {
            levers[2].transform.localEulerAngles = baseLeverPos;
            //isLever3 = false;
            //isLever1 = true;
        }
    }
    public void Lever2Down()
    {
        if(levers[1].GetComponent<HingeJoint>().angle >= 70f /*&& isLever2 == false*/ && isTriggerPressed)
        {
            levers[0].transform.localEulerAngles = baseLeverPos;
            //isLever1 = false;
            levers[3].transform.localEulerAngles = baseLeverPos;
            //isLever4 = false;
            //isLever2 = true;
        }
    }
    public void Lever3Down()
    {
        if (levers[2].GetComponent<HingeJoint>().angle >= 70f /*&& isLever3 == false*/ && isTriggerPressed)
        {
            levers[3].transform.localEulerAngles = finalLeverPos;
            //isLever3 = true;
        }
    }
    public void Lever4Down()
    {
        if (levers[3].GetComponent<HingeJoint>().angle >= 70f /*&& isLever4 == false*/ && isTriggerPressed)
        {
            levers[0].transform.localEulerAngles = finalLeverPos;
            levers[2].transform.localEulerAngles = finalLeverPos;
            //isLever4 = true;
        }
    }
}
