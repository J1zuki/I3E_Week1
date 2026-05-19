using UnityEngine;
using TMPro;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    TextMeshProUGUI scoreText;
    int currentScore = 0;

    void Start()
    {
        scoreText.text = "SCORE: " + currentScore.ToString();
    }

    // Update is called once per frame
    public void ModifyScore(int amt)
    {
        currentScore += amt;
        scoreText.text = "SCORE: " + currentScore.ToString();
    }
}
