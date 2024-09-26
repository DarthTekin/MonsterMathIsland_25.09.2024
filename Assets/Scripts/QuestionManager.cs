using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private MonsterManager _monsterManager;
    [SerializeField] TMP_Text _messageBoxTextField;
    [SerializeField] TMP_InputField _answerInputField; 
    [SerializeField] private int answer;

    void Start()
    {
     GenerateQuestion();
    }
    
    void GenerateQuestion()
    {
        var qa = GenerateAddSubtract(1, 100);

        _messageBoxTextField.text = qa.question;

        ClearInputField();
    }

    private (string question, int answer) GenerateAddSubtract(int min, int max)
    {
        //Find random numbers for operand
        int operand1 = Random.Range(min, max);
        int operand2 = Random.Range(min, max);

        string question = "";

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

        return (question, answer);
    }

    public void ValidateAnswer()
    {
        if (_answerInputField.text == answer.ToString())
        {
            _monsterManager.KillMonster(0);
            _monsterManager.MonsterAttacks(0);
            _monsterManager.MoveNextMonsterToQueue();
            GenerateQuestion();
        }
        else
        {
            ClearInputField();
        }
    }

    void ClearInputField()
    {
        _answerInputField.text = "";
        _answerInputField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
