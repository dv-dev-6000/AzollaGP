using UnityEngine;
using UnityEngine.UI;

public class HeartsSystem : MonoBehaviour
{
    [Header ("Hearts System")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public static int life = 4;

    private void Awake()
    {
        // Start the game with 4 hearts
        life = 4;
    }

    private void Update()
    {
        // Change full heart to empty heart when full heart is destroyed
        foreach (Image img in hearts) 
        {
            img.sprite = emptyHeart;
        }

        for (int i = 0; i < life; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
}
