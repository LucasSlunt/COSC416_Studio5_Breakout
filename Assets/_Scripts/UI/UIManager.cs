using TMPro;
using UnityEngine;
using System.Collections;

public class UIManager : SingletonMonoBehavior<UIManager>
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverText;

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score; // Update the text with the current score
    }

    public void UpdateLives(int lives)
    {
        Debug.Log("Current lives: " + lives);
        livesText.text = "Lives: " + lives;
    }

    //shows the game over screen
    public void ShowGameOverScreen()
    {
        Debug.Log("You used all three lives! Showing game over screen...");
        gameOverPanel.SetActive(true);
        StartCoroutine(FlashText());

        Debug.Log("ShowGameOverScreen method has completed execution.");
    }

    public IEnumerator FlashText()
    {
        int flashCount = 3;

        Debug.Log("FlashingText coroutine started!");

        for (int i = 0; i < flashCount; i++)
        {
            gameOverText.alpha = 0;
            Debug.Log("Text hidden");

            yield return new WaitForSecondsRealtime(0.3f);

            gameOverText.alpha = 1;
            Debug.Log("Text shown");

            yield return new WaitForSecondsRealtime(0.3f);
        }

        Debug.Log("Flashing complete! Proceeding to Main Menu...");
    }
}
