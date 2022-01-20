using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool menuActive = false;
    public bool pressed = false;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape) && pressed == false)
        {
            pressed = true;
            if(menuActive == false)
            {
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                menuActive = true;
                pressed = false;
            }
            else
            {
                pauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                menuActive = false;
                pressed = false;
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        menuActive = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
