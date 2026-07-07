using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Image coinTrackingIcon;
    public Sprite[] coinTrackingSprites;

    int currentScore = 0;
    int currentCoinCount = 0;

    void Start()
    {
        scoreText.text = "SCORE: " + currentScore.ToString();

        if (coinTrackingIcon != null && coinTrackingSprites.Length > 0)
        {
            coinTrackingIcon.sprite = coinTrackingSprites[currentCoinCount];
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Touched: " + other.gameObject.name);

        Collectible collectible = other.GetComponent<Collectible>();

        if (collectible != null)
        {
            int scoreAmount = collectible.Interact();
            ModifyScore(scoreAmount);
        }
    }

    public void ModifyScore(int amt)
    {
        currentScore += amt;
        scoreText.text = "SCORE: " + currentScore.ToString();

        ++currentCoinCount;

        if (coinTrackingIcon != null && coinTrackingSprites.Length > 0)
        {
            if (currentCoinCount >= coinTrackingSprites.Length)
            {
                currentCoinCount = coinTrackingSprites.Length - 1;
            }

            coinTrackingIcon.sprite = coinTrackingSprites[currentCoinCount];
        }
    }
}