using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            transform.GetComponent<Button>().onClick?.Invoke();
        }
    }

    public GameObject menuPanel;

    public void Menu_button()
    {
        Time.timeScale = 0; //게임 일시정지
        menuPanel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}

