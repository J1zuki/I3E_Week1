using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private int score = 0;

    public TextMeshProUGUI ScoreText;
    public GameObject MenuPanel;

    void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        ScoreText.text = "Score: " + score;
    }

    public void OnMenu()
    {
        MenuPanel.SetActive(!MenuPanel.activeSelf);
    }
}