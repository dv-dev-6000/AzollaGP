using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Texture2D cursor;
    [SerializeField] GameObject tutorialPanel;
    [SerializeField] AudioSource menuSelect;

    private void Start()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
    }
    public void ChangeSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {
        Debug.Log("Application Exited");
        Application.Quit();
    }

    public void ToggleTutorialPanel()
    {
        menuSelect.Play();
        tutorialPanel.SetActive(!tutorialPanel.activeSelf);
    }
}
