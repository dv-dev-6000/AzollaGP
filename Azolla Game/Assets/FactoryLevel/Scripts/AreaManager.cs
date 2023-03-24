using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AreaManager : MonoBehaviour
{
    public static AreaManager instance;
    [SerializeField] private AudioSource deathEffect;

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
        UIManager _ui = GetComponent<UIManager>();

        if (_ui != null)
        {
            _ui.ToggleDeathPanel();
            deathEffect.Play();
        }
    }
}
