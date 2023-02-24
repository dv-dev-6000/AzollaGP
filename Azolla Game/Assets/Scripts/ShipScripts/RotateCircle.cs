using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCircle : MonoBehaviour
{
    // Right Circle
    [SerializeField]
    GameObject innerRight;
    [SerializeField]
    GameObject outterRight;
    [SerializeField]
    GameObject middleRight;

    // Left Circle
    [SerializeField]
    GameObject innerLeft;
    [SerializeField]
    GameObject outterLeft;
    [SerializeField]
    GameObject middleLeft;



    // Update is called once per frame
    void Update()
    {
        // Right 
        innerRight.transform.Rotate(0, 0, 0.2f);
        outterRight.transform.Rotate(0, 0, -0.2f);
        middleRight.transform.Rotate(0, 0, -0.4f);
        // Left
        innerLeft.transform.Rotate(0, 0, -0.2f);
        outterLeft.transform.Rotate(0, 0, 0.2f);
        middleLeft.transform.Rotate(0, 0, 0.4f);
    }
}
