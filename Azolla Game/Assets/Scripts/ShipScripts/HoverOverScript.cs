using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOverScript : MonoBehaviour
{
    [SerializeField]
    private GameObject componentOne;
    [SerializeField]
    private GameObject shipManager;
    [SerializeField]
    private int id;

    //TEST
    [SerializeField]
    private RectTransform cosmoMapMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (!shipManager.GetComponent<ShipManagerScript>().MenuOpen)
        {
            componentOne.SetActive(true);
            shipManager.GetComponent<ShipManagerScript>().HoverID = id;
        }

        //TESTING _________________________________________________________
        cosmoMapMenu.gameObject.SetActive(true);

        //int tmp = shipManager.GetComponent<ShipManagerScript>().HoverID;
        //
        //if (tmp != -1)
        //{
        //    shipManager.GetComponent<ShipManagerScript>().openUI(tmp);
        //}
    }

    private void OnMouseExit()
    {
        componentOne.SetActive(false);
        shipManager.GetComponent<ShipManagerScript>().HoverID = -1;
    }

}
