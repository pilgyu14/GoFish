using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float humanHomeHP { get; set; }
    public float fishHomeHP { get; set; }

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

    }

    public void PlayerGameWin()
    {

    }
}
