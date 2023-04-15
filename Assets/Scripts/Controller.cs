using System;
using TMPro;
using UnityEngine;

public class Controller : Elements
{
    [SerializeField] private TMP_InputField titleTextInput;
    [SerializeField] private TMP_InputField descriptionTextInput;
    // items in some view
    [SerializeField] private TMP_InputField costInput;
    [SerializeField] private TMP_InputField discountInput;
    private string validCharacters = "0123456789";
    [SerializeField] private TMP_InputField bigIconNameInput;
    
    private void Start()
    {
        
        
        // _items.Add("Wood", 5);
        //
        // foreach (var item in _items)
        // {
        //     _summaryCellsCount += item.Value;
        // }
        //
        // for (int i = 0; i < _summaryCellsCount; i++)
        // {
        //     cells[i].SetActive(true);
        // }
    }

    public void OnDataInput()
    {
        OnNotification(Notification.TitleChange, titleTextInput.text);
        OnNotification(Notification.DescriptionChange, descriptionTextInput.text);
        OnNotification(Notification.CostChange, costInput.text);
        OnNotification(Notification.DiscountChange, discountInput.text);
        OnNotification(Notification.IconNameChange, bigIconNameInput.text);
        App.view.Show();
    }

    public void OnNotification(string event_path, string param)
    {
        switch(event_path)
        {
            case var value when value == Notification.CostChange:
                App.model.cost = Int32.Parse(param);
                break;
     
            case var value when value == Notification.DiscountChange:
                App.model.discount = Int32.Parse(param);
                break;
        
            case var value when value == Notification.TitleChange:
                App.model.titleText = param;
                break;
        
            case var value when value == Notification.DescriptionChange:
                App.model.descriptionText = param;
                break;
        
            case var value when value == Notification.IconNameChange:
                App.model.iconName = param;
                break;
        } 
        App.view.UpdateTexts(App.model.titleText, App.model.descriptionText, App.model.cost, App.model.discount);
        App.view.UpdateImage(App.model.iconName);
        //App.view.UpdateCells(App.model.cellsInfo);
        //todo updateCells
    }
}
