using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/SkinLIstSO")]
public class SkinListSO : ScriptableObject
{
    public List<CardNamingSkins> skinList = new List<CardNamingSkins>();
}

[System.Serializable]
public class CardNamingSkins
{
    public CardNamingType cardNamingType;
    public List<SkinData> skinDataList = new List<SkinData>();  
}

