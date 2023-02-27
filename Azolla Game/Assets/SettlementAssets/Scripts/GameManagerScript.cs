using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public bool isMenuOpen { get; set; }
    public int currPlotSelection { get; set; }

    // players materials cache
    private int materialsCount;
    // materials prize amount
    private int matPrize = 75;

    [SerializeField]
    private TextMeshProUGUI debugText;

    // Build/Upgrade Panel Menu
    [SerializeField]
    private RectTransform buildPanel;
    // Materials Button
    [SerializeField]
    private Button matButton;

    // Materials UI text
    [SerializeField]
    private TextMeshProUGUI matDisplayText;

    // Start is called before the first frame update
    void Start()
    {
        // Set Cursor Visibility
        Cursor.visible = true;

        // set menuopen bool
        isMenuOpen = false;

        // Set initial material amount
        materialsCount = 0;

        // Set Up material Button Click Event
        Button matButt = matButton.GetComponent<Button>();
        matButt.onClick.AddListener(AddMaterials);

        debugText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// on click event logic for build button 
    /// </summary>
    public void OpenBuildMenu()
    {
        if (buildPanel.gameObject.activeInHierarchy == false)
        {
            buildPanel.gameObject.SetActive(true);
            isMenuOpen = true;
            debugText.text = "" + currPlotSelection;
        }
        else
        {
            buildPanel.gameObject.SetActive(false);
            isMenuOpen = false;
        }
    }

    void AddMaterials()
    {
        materialsCount = materialsCount + matPrize;
        matDisplayText.GetComponent<TextMeshProUGUI>().text = ""+materialsCount;
    }
}
