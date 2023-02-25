using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlotScript : MonoBehaviour
{
    [SerializeField]
    private GameObject hovCir;

    // Start is called before the first frame update
    void Start()
    {
        hovCir.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        hovCir.SetActive(true);
    }

    private void OnMouseExit()
    {
        hovCir.SetActive(false);
    }

    // if clicked and empty open builder menu

    // if clicked and occupied, get state and open upgrade menu
}
