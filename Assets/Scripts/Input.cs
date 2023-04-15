using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Input : MonoBehaviour
{
    [SerializeField] private TMP_InputField titleTextInput;
    [SerializeField] private TMP_InputField descriptionTextInput;
    // items in some view
    [SerializeField] private TMP_InputField costInput;
    [SerializeField] private TMP_InputField saleInput;
    private string validCharacters = "0123456789";
    [SerializeField] private TMP_InputField bigIconNameInput;
    // Входные параметры окна извне:		
    // 1. Текст заголовка		
    // 2. Текст описания		
    // 3. Предметы в виде название / количество от 3 до 6		
    // 4. Цена		
    // 5. Скидка		
    // 6. Название большой иконки окна

    private void Start()
    { 
        costInput.onValidateInput = (string text, int charIndex, char addedChar) =>
        {
            return ValidateChar(validCharacters, addedChar);
        };
        saleInput.onValidateInput = (string text, int charIndex, char addedChar) =>
        {
            return ValidateChar(validCharacters, addedChar);
        };
        string titleText = titleTextInput.text;
    }

    private char ValidateChar(string validCharacters, char addedChar)
    {
        if (validCharacters.IndexOf(addedChar) != -1)
        {
            return addedChar;
        }
        else
        {
            return '\0';
        }
    }
}
