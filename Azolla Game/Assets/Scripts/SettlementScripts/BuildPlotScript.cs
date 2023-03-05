using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
public class BuildPlotScript : MonoBehaviour
{
    private string type;
    private int option;
    private int level;

    [SerializeField]
    GameObject gameManager;
    [SerializeField]
    GameObject spriteManager;

    [SerializeField]
    private int id;
    [SerializeField]
    private GameObject hovCir;

    // Start is called before the first frame update
    void Start()
    {
        //update plots
        UpdatePlot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        //check if menu closed
        if (TheCloud.uiMenuOpen == false)
        {
            hovCir.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        //check if menu closed
        if (TheCloud.uiMenuOpen == false)
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

            if (level == 0)
            {
                gameManager.GetComponent<GameManagerScript>().OpenBuildMenu();
            }
            else
            {
                gameManager.GetComponent<GameManagerScript>().OpenUpgradeMenu();
            }

            hovCir.SetActive(false);
        }
    }

    public void UpdatePlot()
    {
        type = TheCloud.Plots[id].Type;
        option = TheCloud.Plots[id].Option;
        level = TheCloud.Plots[id].Level;

        //set sprite
        string tmp = type + "_" + option + "_" + level;

        switch (tmp)
        {
            case "sec_1_1":
                this.GetComponent<SpriteRenderer>().sprite = spriteManager.GetComponent<SpriteManScript>().Sec_1_1;
                break;
            case "mor_1_1":
                this.GetComponent<SpriteRenderer>().sprite = spriteManager.GetComponent<SpriteManScript>().Mor_1_1;
                break;
            case "env_1_1":
                this.GetComponent<SpriteRenderer>().sprite = spriteManager.GetComponent<SpriteManScript>().Env_1_1;
                break;
            case "empty_0_0":
                this.GetComponent<SpriteRenderer>().sprite = spriteManager.GetComponent<SpriteManScript>().Emp_0_0;
                break;
            default:
                this.GetComponent<SpriteRenderer>().sprite = spriteManager.GetComponent<SpriteManScript>().Emp_0_0;
                break;
        }
        gameManager.GetComponent<GameManagerScript>().debugText.text = tmp;
    }
}
