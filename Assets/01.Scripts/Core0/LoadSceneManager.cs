using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadSceneManager : MonoBehaviour
{

    #region 타이틀씬에서 이동
    public void LoadStage1Scene()
    {
        SceneLoadBase();
        //SceneManager.LoadScene("");
    }

    public void LoadStage2Scene()
    {
        SceneLoadBase();
        //SceneManager.LoadScene("");
    }

    public void LoadStage3Scene()
    {
        SceneLoadBase();
        //SceneManager.LoadScene("");
    }

    public void LoadStage4Scene()
    {
        SceneLoadBase();
        //SceneManager.LoadScene("");
    }

    public void LoadStage5Scene()
    {
        SceneLoadBase();
        //SceneManager.LoadScene("");
    }

    public void LoadTutorialScene()
    {
        SceneLoadBase();
        SceneManager.LoadScene("Tutorial1");
    }
    #endregion

    public void LoadBattleScene()
    {
        SceneLoadBase();
        SceneManager.LoadScene("BattleScene");
    }

    public void LoadTitleScene()
    {
        SceneLoadBase();
        SceneManager.LoadScene("Title");
    }

    /// <summary>
    /// 대부분의 씬을 이동할 때 공통적인 부분
    /// </summary>
    public void SceneLoadBase()
    {
        //모든 닷트윈 제거
        DOTween.KillAll();
        //시간을 1로 되돌림
        Time.timeScale = 1f;
        //세이브 데이터에 접근하는 오브젝트들 제거
        //EventManager.Instance.TriggerEvent(EventsType.ClearEvents); // 이벤트 초기화 
    }
}
