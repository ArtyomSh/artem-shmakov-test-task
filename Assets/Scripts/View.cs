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

    [SerializeField] private GameObject discountIcon;
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

    public void Hide()
    {
        shop.SetActive(false);
    }
    
    public void UpdateTexts(string title, string description, float cost, int discount)
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

    public void UpdateCells(int cellCount, List<string> items)
    {
        for (int i = 0; i < cellCount; i++)
        {
            cells[i].SetActive(true);
        }

        int counter = 0;
        
        foreach (string name in items)
        {
            cells[counter].GetComponentsInChildren<Image>()[1].sprite = cellInfo.GetSpriteByName(name);
            cells[counter].GetComponentInChildren<TMP_Text>().text = cellInfo.GetCountByName(name).ToString();
            counter++;
        }
    }

    public void TurnOffDiscount(float cost)
    {
        discountText.gameObject.SetActive(false);
        costText.gameObject.SetActive(false);
        afterDiscountText.text = cost.ToString();
        discountIcon.SetActive(false);
    }
}
