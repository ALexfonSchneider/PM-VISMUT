using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    protected Canvas menu;
    private void Start()
    {
        menu = GetComponent<Canvas>();

        menu.enabled = false;
    }
    private void Update()
    {
        PauseGame();
    }

    public void dosome()
    {
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Refresh()
    {
        Time.timeScale = 1f;
    }
    public void PauseAndShowMenu()
    {
        Pause();
        menu.enabled = true;
    }
    public void RefreshAndHideMenu()
    {
        Time.timeScale = 1f;
        menu.enabled = false;
    } 
    public void PauseGame()
    {
        var on_esc_down = Input.GetKeyUp(KeyCode.Escape);

        if (on_esc_down)
        {
            if (menu.enabled)
            {
                RefreshAndHideMenu();
            }
            else
            {
                PauseAndShowMenu();
            }
        }
    }

    
}
