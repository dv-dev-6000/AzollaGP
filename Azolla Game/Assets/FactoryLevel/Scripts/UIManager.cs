using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    PlayerController playerController;

    [SerializeField] GameObject deathPanel;
    [SerializeField] GameObject winPanel;

    // Toggling win and death panels
    public void ToggleDeathPanel()
    {
        deathPanel.SetActive(!deathPanel.activeSelf);
    }

    public void ToggleWinPanel()
    {
        winPanel.SetActive(!winPanel.activeSelf);
    }
}
