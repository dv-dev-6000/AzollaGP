using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts;

public class CreditScoreScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI crScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (int.Parse(crScore.text) != TheCloud.credits)
        {
            crScore.text = ""+TheCloud.credits;
        }
    }
}
