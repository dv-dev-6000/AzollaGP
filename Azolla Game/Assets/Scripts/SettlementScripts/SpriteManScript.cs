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
    [SerializeField]
    private Sprite uniOne;
    [SerializeField]
    private Sprite recCentreOne;
    [SerializeField]
    private Sprite windOne;
    [SerializeField]
    private Sprite observatoryOne;
    [SerializeField]
    private Sprite gymOne;
    [SerializeField]
    private Sprite recycleFacOne;

    public Sprite Emp_0_0 { get; set; }
    public Sprite Sec_1_1 { get; set; }
    public Sprite Sec_2_1 { get; set; }
    public Sprite Sec_3_1 { get; set; }
    public Sprite Mor_1_1 { get; set; }
    public Sprite Mor_2_1 { get; set; }
    public Sprite Mor_3_1 { get; set; }
    public Sprite Env_1_1 { get; set; }
    public Sprite Env_2_1 { get; set; }
    public Sprite Env_3_1 { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Emp_0_0 = emptyPlot;
        Sec_1_1 = wTowerOne;
        Mor_1_1 = parkOne;
        Env_1_1 = airpureOne;
        Sec_2_1 = uniOne;
        Mor_2_1 = recCentreOne;
        Env_2_1 = windOne;
        Sec_3_1 = observatoryOne;
        Mor_3_1 = gymOne;
        Env_3_1 = recycleFacOne;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
