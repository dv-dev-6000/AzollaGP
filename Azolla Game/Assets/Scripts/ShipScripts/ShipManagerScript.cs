using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManagerScript : MonoBehaviour
{
    [SerializeField]
    public bool MenuOpen { get; set; }
    [SerializeField]
    public int HoverID { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        HoverID = -1;
        MenuOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openUI(int id)
    {
        switch (id) 
        {
            case 0:
                //cosmoMapMenu.GetComponent<GameObject>().SetActive(true);
                break;
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
        }
        HoverID = -1;
    }
}
