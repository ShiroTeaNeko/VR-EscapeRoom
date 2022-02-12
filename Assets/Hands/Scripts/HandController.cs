using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    ActionBasedController controller;

    Hand hand;
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
    }

    void Update()
    {
        hand.SetGrip(controller.selectAction.action.ReadValue<float>());
        //hand.SetTrigger(controller.selectAction.action.ReadValue<float>());
    }
}
