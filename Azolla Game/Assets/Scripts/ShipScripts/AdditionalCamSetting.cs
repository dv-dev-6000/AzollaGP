using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Assets.Scripts;

public class AdditionalCamSetting : MonoBehaviour
{
    public Texture2D cursorArrow;

    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Set cursor texture
        
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);

        if (TheCloud.disableStarScroll)
        {
            animator.GetComponent<Animator>().enabled = false;
        }
    }
}

