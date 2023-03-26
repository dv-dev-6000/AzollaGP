using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsSystem : MonoBehaviour
{
    public Image[] hearts;
    public  static int life = 4;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    private void Awake()
    {
        life = 4;
    }

    private void Update()
    {
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
