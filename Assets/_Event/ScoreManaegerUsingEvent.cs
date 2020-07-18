using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManaegerUsingEvent : MonoBehaviour, IScoreHandler
{
    [SerializeField] Text m_scoreText;
    private int m_SumScore = 0;

    private void Awake()
    {
        ResetScore();
    }
    public void ResetScore()
    {
        m_SumScore = 0;
    }

    private void OnEnable()
    {
        EventManager.Instance.Subscribe(this.gameObject);
    }

    private void OnDisable()
    {
        EventManager.Instance.Unsubscribe(this.gameObject);
    }

    public void GetSocre(int score)
    {
        m_SumScore += score;
        Debug.LogWarning("aaaaaaaaaaa");

        m_scoreText.text = "Score: " + m_SumScore.ToString();
    }

}
