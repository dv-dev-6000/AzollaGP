using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteManScript : MonoBehaviour
{
    [SerializeField]
    private Sprite emptyPlot;
    [SerializeField]
    private Sprite wTowerOne;
    [SerializeField]
    private Sprite parkOne;
    [SerializeField]
    private Sprite airpureOne;

    public Sprite Emp_0_0 { get; set; }
    public Sprite Sec_1_1 { get; set; }
    public Sprite Mor_1_1 { get; set; }
    public Sprite Env_1_1 { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Emp_0_0 = emptyPlot;
        Sec_1_1 = wTowerOne;
        Mor_1_1 = parkOne;
        Env_1_1 = airpureOne;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
