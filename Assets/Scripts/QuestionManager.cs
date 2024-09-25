using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] TMP_Text _messageBoxTextField;
    [SerializeField] TMP_InputField _answerInputField; 
    [SerializeField] private int answer;
    
    private string question;

    // Start is called before the first frame update
    void Start()
    {
        //Find random numbers for operand
        int operand1 = Random.Range(1, 100);
        int operand2 = Random.Range(1, 100);

        if (Random.value < 0.5)
        {
            question = $"{operand1} + {operand2} =";
            answer = operand1 + operand2;
        }
        else
        {
            question = $"{operand1} - {operand2} =";
            answer = operand1 - operand2;
        }

        _messageBoxTextField.text = question;

        _answerInputField.Select();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
