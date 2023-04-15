using System;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class View : Elements
{
    [Header("Windows")]
    [SerializeField] private GameObject form;
    [SerializeField] private GameObject shop;
    
    [Header("Scriptable objects")]
    [SerializeField] private IconSpriteInfo iconList;
    [SerializeField] private ItemInfo cellInfo;
    
    [SerializeField] private List<GameObject> cells = new List<GameObject>();

    [Header("Text objects")]
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private TMP_Text discountText;
    [SerializeField] private TMP_Text afterDiscountText;
    [SerializeField] private GameObject icon;

    private Image _bigImage;
    
    private void Start()
    {
        _bigImage = icon.GetComponent<Image>();
    }

    public void Show()
    {
        form.SetActive(false);
        shop.SetActive(true);
    }
    
    public void UpdateTexts(string title, string description, int cost, int discount)
    {
        titleText.text = title;
        descriptionText.text = description;
        costText.text = cost.ToString();
        discountText.text = "-" + discount.ToString() + "%";
        afterDiscountText.text = (cost * (1 - (float)discount / 100)).ToString(CultureInfo.CurrentCulture);
    }

    public void UpdateImage(string spriteName)
    {
        _bigImage.sprite = iconList.GetByName(spriteName);
    }

    public void UpdateCells(int cellCount, Dictionary<string, int> dictionary)
    {
        for (int i = 0; i < cellCount; i++)
        {
            cells[i].SetActive(true);
        }

        foreach (var pare in dictionary)
        {
            for (int i = 0; i < UPPER; i++)
            {
                
            }
        }
    }
}
