using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PCsettings : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Sprites
    public Sprite customPC;
    public Sprite encycloPC;
    public Sprite achievePC;
    public Sprite multiPC;
    // On hover sprites
    public Sprite highlightedAchievePC;
    public Sprite highlightedCustomPC;
    public Sprite highlightedEncycloPC;   
    public Sprite highlightedMultiPC;

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("smth happened");  
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
    }

}
