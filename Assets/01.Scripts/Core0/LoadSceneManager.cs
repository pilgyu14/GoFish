using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadSceneManager : MonoBehaviour
{

    #region Ÿ��Ʋ������ �̵�
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
    /// ��κ��� ���� �̵��� �� �������� �κ�
    /// </summary>
    public void SceneLoadBase()
    {
        //��� ��Ʈ�� ����
        DOTween.KillAll();
        //�ð��� 1�� �ǵ���
        Time.timeScale = 1f;
        //���̺� �����Ϳ� �����ϴ� ������Ʈ�� ����
        //EventManager.Instance.TriggerEvent(EventsType.ClearEvents); // �̺�Ʈ �ʱ�ȭ 
    }
}
