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

    private bool isSpawn; //스폰 튜토리얼 클리어
    private bool isKill; //적 잡기 튜토리얼 클리어

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
            NextTutorialButtonText.text = "유닛을 소환해보기";
        }

        if(currentTutorial == 6)
        {
            SpawnEvent?.Invoke();
        }
        //if (currentTutorial == 6 && isKill == false)
        //{
        //    NextTutorialButton.interactable = false;
        //    NextTutorialButtonText.text = "적을 잡아보기";
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
        NextTutorialButtonText.text = "다음 튜토리얼";
        isSpawn = true;
    }

    public void isKillClear()
    {
        NextTutorialButton.interactable = true;
        NextTutorialButtonText.text = "다음 튜토리얼";
        isKill = true;
    }
}
    