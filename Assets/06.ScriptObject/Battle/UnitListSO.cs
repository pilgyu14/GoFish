using UnityEngine; 
using System.Collections.Generic;

[CreateAssetMenu(menuName = "SO/Battle/UnitListSO")]
public class UnitListSO : ScriptableObject
{
    public List<UnitScript> unitList = new List<UnitScript>(); 
}
