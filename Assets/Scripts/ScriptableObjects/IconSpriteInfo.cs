using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public struct IconImage
{
    public string name;
    public Sprite sprite;
}

[CreateAssetMenu(fileName = "IconSpriteInfo", menuName = "Shop/New IconSpriteInfo")]
public class IconSpriteInfo : ScriptableObject
{
    [SerializeField] private List<IconImage> _iconList;
    public List<IconImage> IconList => this._iconList;
    
    public Sprite GetByName(string imageName)
    {
        return _iconList.FirstOrDefault(x => x.name == imageName).sprite;
    }
}
