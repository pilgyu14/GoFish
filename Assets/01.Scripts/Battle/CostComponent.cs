using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro; 

[Serializable]
public class CostComponent
{
    private int _money;
    public int Money
    {
        get => _money;
        set
        {
            _money = value; 
        }
    }

    private BattleManager _battleManager;
    [SerializeField]
    private WarrningComponent _warrningComponent;
    [SerializeField]
    private TextMeshProUGUI _moneyText; 

    private int _addedMoney = 1;
    private float _time = 0.5f;
    public float Time => _time;
    public WarrningComponent WarrningComponent => _warrningComponent; 
    public void Initialize(BattleManager battleManager)
    {
        _battleManager = battleManager; 
    }

    public void AddMoney()
    {
        _money += _addedMoney;
        _moneyText.text = _money.ToString(); 
    }

    public void MinusMoney(int cost)
    {
        _money -= cost; 
    }
}