using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehavior<UIManager>
{
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private GameObject gameOverPanel;

    public void UpdateLives(int lives)
    {
        Debug.Log("Current lives: " + lives);
        livesText.text = "Lives: " + lives;
    }

    public void ShowGameOverScreen()
    {
        Debug.Log("You used all three lives! Showing game over screen...");
        gameOverPanel.SetActive(true);
    }
}
