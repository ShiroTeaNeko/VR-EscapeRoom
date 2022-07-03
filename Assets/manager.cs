using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class manager : MonoBehaviour
{
    private XRController leftController = null;
    private XRController rightController = null;
    public GameObject leftHand;
    public GameObject rightHand;

    public List<GameObject> targets = new();

    public List<GameObject> fusibles = new();

    public List<GameObject> levers = new();
    Vector3 baseLeverPos = new Vector3(0f, 0f, 308.609985f);
    Vector3 finalLeverPos = new Vector3(7.18544626f, 358.526245f, 28.2367992f);

    public Transform fusibleTargetPosition;

    public int targetDestroyed = 0;

    bool isLever1;
    bool isLever2;
    bool isLever3;
    bool isLever4;
    bool isTriggerPressed;

    AudioSource audio;
    AudioSource audioDebug;

    private void Awake()
    {
        leftController = leftHand.GetComponent<XRController>();
        rightController = rightHand.GetComponent<XRController>();
    }

    private void Start()
    {
        audioDebug = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (leftController.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool leftTrigger) || rightController.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool rightTrigger))
        {
            isTriggerPressed = true;
        }
        /*else
        {
            isTriggerPressed = false;
        }*/
        
        if (targetDestroyed >= 4)
        {
            fusibles[0].transform.position = fusibleTargetPosition.position;
            audio = fusibles[0].GetComponent<AudioSource>();
            audio.Play();
            targetDestroyed = 0;
        }

        if (isTriggerPressed)
        {
            audioDebug.Play();
        }

        if (levers[0].GetComponent<HingeJoint>().angle >= 70f /*&& isLever1 == false*/ && isTriggerPressed)
        {
            levers[2].transform.localEulerAngles = baseLeverPos;
            //isLever3 = false;
            //isLever1 = true;
        }

        if (levers[1].GetComponent<HingeJoint>().angle >= 70f /*&& isLever2 == false*/ && isTriggerPressed)
        {
            levers[0].transform.localEulerAngles = baseLeverPos;
            //isLever1 = false;
            levers[3].transform.localEulerAngles = baseLeverPos;
            //isLever4 = false;
            //isLever2 = true;
        }

        if (levers[2].GetComponent<HingeJoint>().angle >= 70f /*&& isLever3 == false*/ && isTriggerPressed)
        {
            levers[3].transform.localEulerAngles = finalLeverPos;
            //isLever3 = true;
        }

        if (levers[3].GetComponent<HingeJoint>().angle >= 70f /*&& isLever4 == false*/ && isTriggerPressed)
        {
            levers[0].transform.localEulerAngles = finalLeverPos;
            levers[2].transform.localEulerAngles = finalLeverPos;
            //isLever4 = true;
        }

    }

    void LeverDown()
    {

    }
}
