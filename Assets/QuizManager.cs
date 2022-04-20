using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<MCQ> QA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionText;
    public GameObject QuestionPanel;
    public GameObject RetryPanel;
    public Text Score;
    public int ScoreCount;

    int totalQ = 0;
    public void Start()
    {
        totalQ = QA.Count;
        RetryPanel.SetActive(false);
        generateRandomQuestion();
    }

    public void GameOver()
    {
        QuestionPanel.SetActive(false);
        RetryPanel.SetActive(true);
        Score.text = ScoreCount + "/" + totalQ;
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Correct()
    {
        QA.RemoveAt(currentQuestion);
        ScoreCount++;
        generateRandomQuestion();
    }

    public void Wrong()
    {
        QA.RemoveAt(currentQuestion);
        generateRandomQuestion();
    }

    public void SetAnswers()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>() .text = QA[currentQuestion].Answers[i];

            if (QA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent <AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateRandomQuestion()
    {
        if (QA.Count <= 0)
        {
            Debug.Log("MCQ Finished");
            GameOver();
            return;
        }
        currentQuestion=Random.Range(0, QA.Count);

        QuestionText.text = QA[currentQuestion].Question;
        SetAnswers();
    }
}
