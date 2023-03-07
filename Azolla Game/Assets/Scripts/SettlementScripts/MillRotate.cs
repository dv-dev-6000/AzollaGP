using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Transform>().Rotate(0, 0, -0.05f);
    }
}
