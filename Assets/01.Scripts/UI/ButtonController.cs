using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    public GameObject menuPanel;

    public void Menu_button()
    {
        Time.timeScale = 0; //���� �Ͻ�����
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

