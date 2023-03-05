using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class HoverOverScript : MonoBehaviour
{
    [SerializeField]
    private GameObject componentOne;
    [SerializeField]
    private int id;
    [SerializeField]
    private RectTransform linkedMenu;

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
        if ( TheCloud.uiMenuOpen == false )
        {
            componentOne.SetActive(true);
            TheCloud.credits++;
        }
    }

    private void OnMouseExit()
    {
        componentOne.SetActive(false);
    }

    private void OnMouseDown()
    {
        if ((TheCloud.uiMenuOpen == false) && ((id > -1) && (id < 5)))
        {
            linkedMenu.gameObject.SetActive(true);
            TheCloud.uiMenuOpen = true;
        }
    }

}
