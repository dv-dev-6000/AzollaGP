using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyManager : MonoBehaviour
{
    [SerializeField]
    GameObject allPlanets;
    [SerializeField]
    GameObject allStars;

    private float planetSpeed = 0.003f;
    private float starSpeed = -0.002f;

    // Update is called once per frame
    void Update()
    {
        allPlanets.transform.Rotate(0, 0, planetSpeed);
        allStars.transform.Rotate(0, 0, starSpeed);
    }
}
