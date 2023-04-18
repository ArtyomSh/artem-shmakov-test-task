using System.Collections.Generic;
using UnityEngine;

public class Model : Elements
{
    public int cellsCount = 0;

    public List<string> items =
        new List<string>();
    
    public string titleText;
    public string descriptionText;
    public float cost;
    public int discount;
    public string iconName;
}
