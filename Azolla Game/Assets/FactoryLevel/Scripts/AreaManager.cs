using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public static AreaManager instance;
    public Texture2D cursor;

    [SerializeField] private AudioSource deathEffect;
    [SerializeField] private AudioSource winEffect;

    private void Start()
    {
        // Setting cursor texture and disabling visibility
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

    // Make cursor visible and enable game over panel
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

    // Make cursor visible and enable win panel
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
