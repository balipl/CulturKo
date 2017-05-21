﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{

    public Text answerText;

    private AnswerData answerData;
    private GameControllr gameController;

    // Use this for initialization
    void Start()
    {
        gameController = FindObjectOfType<GameControllr>();
    }

    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }


    public void HandleClick()
    {
        gameController.AnswerButtonClicked(answerData.isCorrect);
    }
}