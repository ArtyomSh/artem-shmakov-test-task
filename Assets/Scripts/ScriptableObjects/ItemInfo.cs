using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public struct СellInfo
{
    public string name;
    public Sprite sprite;
    public int count;
}

[CreateAssetMenu(fileName = "ItemInfo", menuName = "Shop/New ItemInfo")]
public class ItemInfo : ScriptableObject
{
    [SerializeField] private List<СellInfo> _cellList;
    public List<СellInfo> CellList => this._cellList;
    
    public Sprite GetSpriteByName(string itemName)
    {
        return _cellList.FirstOrDefault(x => x.name == itemName).sprite;
    }
    
    public int GetCountByName(string itemName)
    {
        return _cellList.FirstOrDefault(x => x.name == itemName).count;
    }
}