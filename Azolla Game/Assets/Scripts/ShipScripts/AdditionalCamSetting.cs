using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AdditionalCamSetting : MonoBehaviour
{
    public Texture2D cursorArrow;

    // Start is called before the first frame update
    void Start()
    {
        // Set cursor texture
        
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
}

