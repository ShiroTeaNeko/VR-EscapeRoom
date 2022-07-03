using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollision : MonoBehaviour
{
    public Transform head;
    public Transform feet;


    // Update is called once per frame
    void Update()
    {
        //replace collider value by transform of feet and head
        gameObject.transform.position = new Vector3(head.position.x, feet.position.y, head.position.z);
    }
}
