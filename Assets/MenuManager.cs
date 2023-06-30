using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject main;
    public GameObject options;
    public GameObject controls;
    private bool isMainMenu;

    private bool isOpen = false;

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        options.SetActive(false);
        controls.SetActive(false);

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            main.SetActive(true);
            isMainMenu = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    private void Update()
    {
        Menu();

    }
    public void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isOpen)
        {
            main.SetActive(true);
            isOpen = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isOpen)
        {
            main.SetActive(false);
            isOpen = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }



    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenOptionsPage()
    {
        main.SetActive(false);
        options.SetActive(true);
    }
    public void OpenControlsPage()
    {
        main.SetActive(false);
        controls.SetActive(true);
    }
    public void BackToMainPage()
    {
        main.SetActive(true);
        options.SetActive(false);
        controls.SetActive(false);
    }

    public void Exit()
    {
       Application.Quit();
    }


}
