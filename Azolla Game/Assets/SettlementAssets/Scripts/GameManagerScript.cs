using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    // Build/Upgrade Panel Menu
    [SerializeField]
    private RectTransform buildPanel;
    // Build/Upgrade Button
    [SerializeField]
    private Button buildButton;

    // Start is called before the first frame update
    void Start()
    {
        // Set Cursor Visibility
        Cursor.visible = true;

        // Set Up Build Button Click Event
        Button buildButt = buildButton.GetComponent<Button>();
        buildButt.onClick.AddListener(OnButtonPress);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// on click event logic for build button 
    /// </summary>
    void OnButtonPress()
    {
        if (buildPanel.gameObject.activeInHierarchy == false)
        {
            buildPanel.gameObject.SetActive(true);
        }
        else
        {
            buildPanel.gameObject.SetActive(false);
        }
    }
}
