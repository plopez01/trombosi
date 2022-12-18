using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizHolder : MonoBehaviour
{
    [SerializeField] private PopupController popupController;
    [SerializeField] private Sprite quizQuestionIcon;
    private QuizQuestion[] quizQuestions;
    void Start()
    {
        quizQuestions = GetComponentsInChildren<QuizQuestion>(true);
    }

    private QuizQuestion getRandomQuestion()
    {
        return quizQuestions[Random.Range(0, quizQuestions.Length)];
    }

    public void openQuiz(PopupController.Call correctCall, PopupController.Call incorrectCall)
    {
        QuizQuestion question = getRandomQuestion();
        string ok, nok;
        PopupController.Call okC, nokC;
        int invert = Random.Range(0, 2);
        if (invert == 1)
        {
            ok = question.fakeAnswer;
            nok = question.correctAnswer;
            okC = incorrectCall;
            nokC = correctCall;
        } else
        {
            ok = question.correctAnswer;
            nok = question.fakeAnswer;
            okC = correctCall;
            nokC = incorrectCall;
        }
        popupController.launchPopup(
            "Quiz Time!",
            question.question,
            ok,
            nok,
            quizQuestionIcon,
            okC,
            nokC);
    }
}
