using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject win;
    [SerializeField]
    private GameObject lose;
    [SerializeField]
    private GameObject loadtitleB;

    public float humanHomeHP { get; set; }
    public float fishHomeHP { get; set; }

    protected override void Awake()
    {
        base.Awake();
        //DontDestroyOnLoad(this);
    }

    public void HumanHomeHP(float decrease)
    {
        humanHomeHP -= decrease;
        
        if(humanHomeHP <= 0)
        {
            PlayerGameWin();
        }
    }

    public void FishHomeHP(float decrease)
    {
        fishHomeHP -= decrease;

        if(fishHomeHP <= 0)
        {
            PlayerGameOver();
        }
    }

    public void SetHP()
    {
        humanHomeHP = 100f;
        fishHomeHP = 100f;
    }

    public void HPUISetting()
    {

    }

    public void PlayerGameOver()
    {
        Time.timeScale = 0;
        panel.GetComponent<Image>().DOFade(0.8f, 1).SetUpdate(true);
        lose.transform.DOLocalMoveY(170, 1f).SetUpdate(true);
        loadtitleB.transform.DOLocalMoveY(-145, 1f).SetUpdate(true);
    }

    public void PlayerGameWin()
    {
        Time.timeScale = 0;
        panel.GetComponent<Image>().DOFade(0.8f, 1).SetUpdate(true);
        win.transform.DOLocalMoveY(170, 1f).SetUpdate(true);
        loadtitleB.transform.DOLocalMoveY(-145, 1f).SetUpdate(true);
    }
}
