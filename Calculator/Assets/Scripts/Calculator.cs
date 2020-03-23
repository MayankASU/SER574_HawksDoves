using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using calculatordll;

public class Calculator : MonoBehaviour
{
    // Start is called before the first frame update
    public Text InputField;
    string inputString;
    int[] number = new int[2];
    string operatorSymbol;
    int i = 0;
    int result;
    bool displayedResults = false;
    public void ButtonPressed()
    {
        if (displayedResults == true)
        {
            InputField.text = "";
            inputString = "";
            displayedResults = false;
        }
        string buttonValue = EventSystem.current.currentSelectedGameObject.name;
        inputString += buttonValue;
        int arg;
        if (int.TryParse(buttonValue, out arg))
        {
            if (i > 1) i = 0;
            number[i] = arg;
            i++;

        }
        else {
            switch (buttonValue)
            {
                case "+":
                    operatorSymbol = buttonValue;
                 
                    break;
                case "-":
                    operatorSymbol = buttonValue;
                    break;
                case "=":
                    calculatordll.Calculator obj = new calculatordll.Calculator();
                    switch (operatorSymbol)
                    {
                        case "+":
                            result = obj.Add(number[0], number[1]);
                         
 
                  
                            break;
                        case "-":
                            result = obj.Sub(number[0], number[1]);
                          
                            break;
                    }
                    displayedResults = true;
                    inputString = result.ToString();
                    number = new int[2];
                    break;
            }
        }
        
        

        InputField.text = inputString;

    }

    
}
