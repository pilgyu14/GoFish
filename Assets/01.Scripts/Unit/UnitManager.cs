using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//소환된 유닛들을 리스트에 담아 관리하는 애
//나중에 게임 매니저랑 합치는게 나을듯
public class UnitManager : MonoBehaviour
{
    static private UnitManager instance;
    static public UnitManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<UnitManager>();
                if(instance == null)
                {
                    instance = new GameObject(nameof(UnitManager)).AddComponent<UnitManager>();
                }
            }
            return instance;
        }
    }

    private List<UnitScript> fishList;
    public List<UnitScript> FishList => fishList;
    private List<UnitScript> humanList;
    public List<UnitScript> HumanList => humanList;

    private void Awake()
    {
        fishList = new List<UnitScript>();
        humanList = new List<UnitScript>();
    }

    public void SummonUnit(UnitScript unit, Vector3 pos)
    {
        UnitScript newUnit = PoolManager.Instance.Pop(unit) as UnitScript;
        if (newUnit.UnitData.isHuman)
            humanList.Add(newUnit);
        else
            fishList.Add(newUnit);
        newUnit.transform.position = pos;
    }

    public void DeleteInList(UnitScript unit)
    {
        if (unit.UnitData.isHuman)
            humanList.Remove(unit);
        else
            fishList.Remove(unit);
    }
}
