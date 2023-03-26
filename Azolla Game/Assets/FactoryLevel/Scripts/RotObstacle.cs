using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotObstacle : MonoBehaviour
{
    // Assign an object to rotate around
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        // Spin around the target
        transform.RotateAround(target.transform.position, Vector3.forward, 60 * Time.deltaTime);
    }
}
