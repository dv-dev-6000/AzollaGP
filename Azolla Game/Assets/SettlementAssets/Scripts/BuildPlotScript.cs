using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlotScript : MonoBehaviour
{
    [SerializeField]
    GameObject gameManager;

    [SerializeField]
    private int id;
    [SerializeField]
    private GameObject hovCir;

    // Start is called before the first frame update
    void Start()
    {
        hovCir.GetComponent<GameObject>();
        gameManager.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        //check if menu closed
        if (gameManager.GetComponent<GameManagerScript>().isMenuOpen == false)
        {
            hovCir.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        //check if menu closed
        if (gameManager.GetComponent<GameManagerScript>().isMenuOpen == false)
        {
            hovCir.SetActive(false);
        }
    }

    // if clicked and empty open builder menu
    private void OnMouseDown()
    {
        if (hovCir.activeInHierarchy == true)
        {
            gameManager.GetComponent<GameManagerScript>().currPlotSelection = id;
            gameManager.GetComponent<GameManagerScript>().OpenBuildMenu();
            hovCir.SetActive(false);
        }
    }

    // if clicked and occupied, get state and open upgrade menu
}
