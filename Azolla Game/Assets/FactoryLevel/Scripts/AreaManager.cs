using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AreaManager : MonoBehaviour
{
    public static AreaManager instance;
    public Texture2D cursor;
    [SerializeField] private AudioSource deathEffect;
    [SerializeField] private AudioSource winEffect;

    private void Start()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.visible = false;
    }
    private void Awake()
    {
        if (AreaManager.instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        Cursor.visible = true;
        UIManager _ui = GetComponent<UIManager>();

        if (_ui != null)
        {
            _ui.ToggleDeathPanel();
            deathEffect.Play();
        }
    }

    public void WinScreen()
    {
        Cursor.visible = true;
        UIManager _ui = GetComponent<UIManager>();

        if (_ui != null)
        {
            _ui.ToggleWinPanel();
            winEffect.Play();
        }
    }
}
