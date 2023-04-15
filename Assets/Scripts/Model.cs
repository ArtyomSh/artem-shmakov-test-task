using System.Collections.Generic;
using UnityEngine;

public class Model : Elements
{
    public int summaryCellsCount = 0;

    public Dictionary<string, int> items =
        new Dictionary<string, int>();
    
    public string titleText;
    public string descriptionText;
    public int cost;
    public int discount;
    public string iconName;

    private void Start()
    {
        titleText = "baseText";
    }

    private void Update()
    {
        Debug.Log(titleText);
    }
    
}
