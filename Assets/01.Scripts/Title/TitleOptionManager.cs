using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class TitleOptionManager : MonoBehaviour
{
    public GameObject title;
    public GameObject option;

    public void LoadStageScene()
    {

    }

    public void LoadTutorialScene()
    {

    }

    public void OptionButton()
    {
        //title.transform.DOLocalMoveX(-2000, 0.5f);
        //option.transform.DOLocalMoveX(0, 0.5f);
        title.transform.DOLocalMoveX(-2100, 0.4f).OnComplete(() => { title.transform.DOLocalMoveX(-2000, 0.15f); });
        option.transform.DOLocalMoveX(-100, 0.4f).OnComplete(() => { option.transform.DOLocalMoveX(0, 0.15f); });
    }

    public void TitleButton()
    {
        //title.transform.DOLocalMoveX(0, 0.5f);
        //option.transform.DOLocalMoveX(2000, 0.5f);
        title.transform.DOLocalMoveX(100, 0.4f).OnComplete(() => { title.transform.DOLocalMoveX(0, 0.15f); });
        option.transform.DOLocalMoveX(2100, 0.4f).OnComplete(() => { option.transform.DOLocalMoveX(2000, 0.15f); });
    }

    public void FullScreen()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void Size1920_1080()
    {
        Screen.SetResolution(1920, 1080, false);
    }

    public void Size1280_720()
    {
        //캔버스의 해상도값때문에 일단 보류
        Screen.SetResolution(1280, 720, false);
    }

    public void QuitButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); 
        #endif
    }

    public void OnApplicationQuit()
    {
        //if you have any savedata before quit
    }
}
