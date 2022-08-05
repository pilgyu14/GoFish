using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public string[] tutorialContents;

    public Button NextTutorialButton;
    public TextMeshProUGUI NextTutorialButtonText;
    public int currentTutorial = 1;
    public TextMeshProUGUI tutorialText;

    private bool isSpawn; //���� Ʃ�丮�� Ŭ����
    private bool isKill; //�� ��� Ʃ�丮�� Ŭ����

    public UnityEvent SpawnEvent;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            isSpawnClear();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            isSpawnClear();
        }
    }

    public void PutNextTutorialButton()
    {
        CheckIsLast();

        currentTutorial++;
        
        tutorialText.text = tutorialContents[currentTutorial - 1];

        if(currentTutorial == 4 && isSpawn == false)
        {
            NextTutorialButton.interactable = false;
            NextTutorialButtonText.text = "������ ��ȯ�غ���";
        }

        if(currentTutorial == 6)
        {
            SpawnEvent?.Invoke();
        }
        //if (currentTutorial == 6 && isKill == false)
        //{
        //    NextTutorialButton.interactable = false;
        //    NextTutorialButtonText.text = "���� ��ƺ���";
        //}
    }
            
    private void CheckIsLast()
    {
        if (currentTutorial == tutorialContents.Length)
        {
            LoadMain();
        }
    }

    private void LoadMain()
    {
        SceneManager.LoadScene("Title");
    }

    public void isSpawnClear()
    {
        NextTutorialButton.interactable = true;
        NextTutorialButtonText.text = "���� Ʃ�丮��";
        isSpawn = true;
    }

    public void isKillClear()
    {
        NextTutorialButton.interactable = true;
        NextTutorialButtonText.text = "���� Ʃ�丮��";
        isKill = true;
    }
}
    