using System;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class Controller : Elements
{
    [SerializeField] private TMP_InputField titleTextInput;
    [SerializeField] private TMP_InputField descriptionTextInput;
    [SerializeField] private TMP_InputField itemListInput;
    [SerializeField] private TMP_InputField costInput;
    [SerializeField] private TMP_InputField discountInput;
    [SerializeField] private TMP_InputField bigIconNameInput;

    public void OnDataInput()
    {
        OnNotification(Notification.TitleChange, titleTextInput.text);
        OnNotification(Notification.DescriptionChange, descriptionTextInput.text);
        OnNotification(Notification.ItemListChange, itemListInput.text);
        OnNotification(Notification.CostChange, costInput.text);
        OnNotification(Notification.DiscountChange, discountInput.text);
        OnNotification(Notification.IconNameChange, bigIconNameInput.text);
        App.view.Show();
    }

    public void OnNotification(string event_path, string param)
    {
        switch(event_path)
        {
            case var value when value == Notification.TitleChange:
                App.model.titleText = param;
                App.view.UpdateTexts(App.model.titleText, App.model.descriptionText, App.model.cost, App.model.discount);
                break;
        
            case var value when value == Notification.DescriptionChange:
                App.model.descriptionText = param;
                App.view.UpdateTexts(App.model.titleText, App.model.descriptionText, App.model.cost, App.model.discount);
                break;
            
            case var value when value == Notification.ItemListChange:
                App.model.items = ParseInput(param, out int cellsCount);
                App.model.cellsCount = cellsCount;
                App.view.UpdateCells(App.model.cellsCount, App.model.items);
                break;

            case var value when value == Notification.CostChange:
                App.model.cost = float.Parse(param, CultureInfo.InvariantCulture.NumberFormat);;
                App.view.UpdateTexts(App.model.titleText, App.model.descriptionText, App.model.cost, App.model.discount);
                break;
     
            case var value when value == Notification.DiscountChange:
                App.model.discount = Int32.Parse(param);
                if (App.model.discount == 0)
                {
                    App.view.TurnOffDiscount(App.model.cost);
                    break;
                }
                App.view.UpdateTexts(App.model.titleText, App.model.descriptionText, App.model.cost, App.model.discount);
                break;
            
            case var value when value == Notification.IconNameChange:
                App.model.iconName = param;
                App.view.UpdateImage(App.model.iconName);
                break;
        }
    }

    private List<string> ParseInput(string input, out int cellsCount)
    {
        // input format: thing1, thing2, thing3/count or thing1 thing2 thing3/count
        
        string[] parse = input.Split('/');
        
        string[] items = parse[0].Split(' ');
        List<string> itemsList = new List<string>();
        
        cellsCount =  Int32.Parse(parse[1]);
        
        foreach (string item in items)
        {
            itemsList.Add(item.TrimEnd(new char[] {','}));
        }

        if (cellsCount != itemsList.Count || cellsCount < 3 || cellsCount > 6) 
        {
            Debug.Log("Incorrect input, please, check");
        }
        return itemsList;
    }
}
