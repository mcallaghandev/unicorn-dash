using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int playerTotalScore;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        playerTotalScore = 0;
        SetScoreText(0);
    }

    private void SetScoreText(int score)
    {
        scoreText.text = $"{score}";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flower"))
        {
            var flowerProps = collision.gameObject.GetComponent<FlowerModel>();

            playerTotalScore += flowerProps.flowerScore;
            SetScoreText(playerTotalScore);
        }
    }
}
