using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] bool menuActivated = false;

    private void Start()
    {
        menu = GameObject.Find("Menu");
    }

    void Update()
    {
        IsActivate();
    }

    public void IsActivate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuActivated = !menuActivated;           
        }

        if (menuActivated == true)
        {
            OpenMenu();
        }
        else
        {
            CloseMenu();
        }
    }

    public void OpenMenu()
    {
        menu.SetActive(true);

        Time.timeScale = 0.0f;
    }

    public void CloseMenu()
    {
        menu.SetActive(false);

        Time.timeScale = 1.0f;
    }
}