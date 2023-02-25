using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuilderScript : MonoBehaviour
{
    [SerializeField]
    private Button secOne;

    [SerializeField]
    private TextMeshProUGUI buildType;

    // Start is called before the first frame update
    void Start()
    {
        // Set Up Building Button Click Events
        Button sOne = secOne.GetComponent<Button>();
        sOne.onClick.AddListener(sOnePress);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void sOnePress()
    {
        buildType.GetComponent<TextMeshProUGUI>().text = "Security HQ";
    }
}
