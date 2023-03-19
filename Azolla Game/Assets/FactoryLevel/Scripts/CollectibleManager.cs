using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CollectibleManager : MonoBehaviour
{
    // Fields
    private int woodCount = 0;
    private int ironCount = 0;
    private int copperCount = 0;
    private int goldCount = 0;

    // For UI labels
    [SerializeField]
    private Text woodText;
    [SerializeField]
    private Text ironText;
    [SerializeField]
    private Text copperText;
    [SerializeField]
    private Text goldText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Wood
        if(collision.gameObject.CompareTag("Wood"))
        {
            Destroy(collision.gameObject);
            woodCount++;
            woodText.text = "Wood: " + woodCount;
        }

        // Iron
        if (collision.gameObject.CompareTag("IronOre"))
        {
            Destroy(collision.gameObject);
            ironCount++;
            ironText.text = "Iron: " + ironCount;
        }

        // Gold
        if (collision.gameObject.CompareTag("GoldOre"))
        {
            Destroy(collision.gameObject);
            goldCount++;
            goldText.text = "Gold: " + goldCount;
        }

        // Copper
        if (collision.gameObject.CompareTag("CopperOre"))
        {
            Destroy(collision.gameObject);
            copperCount++;
            copperText.text = "Copper " + copperCount;
        }
    }
}
