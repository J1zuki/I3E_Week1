using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI scoreText;
    public Image coinTrackingIcon;
    public Sprite[] coinTrackingSprites;
    int currentScore = 0;
    int currentCoinCount = 0;

    void Start()
    {
        scoreText.text = "SCORE: " + currentScore.ToString();
        coinTrackingIcon.sprite = coinTrackingSprites[currentCoinCount];
    }

    // Update is called once per frame
    public void ModifyScore(int amt)
    {
        currentScore += amt;
        scoreText.text = "SCORE: " + currentScore.ToString();

        // Update the coin tracking icon
        ++currentCoinCount;

        if (currentCoinCount >= coinTrackingSprites.Length)
        {
            currentCoinCount = coinTrackingSprites.Length - 1;
        }

        coinTrackingIcon.sprite = coinTrackingSprites[currentCoinCount];
    }
}