using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AdditionalCamSetting : MonoBehaviour
{
    public Texture2D cursorArrow;
    private Animator cameraAnimation;

    // Start is called before the first frame update
    void Start()
    {
        cameraAnimation = GetComponent<Animator>();

        // Set cursor texture and make it invisible
        
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    void Update()
    {
       
    }

}

