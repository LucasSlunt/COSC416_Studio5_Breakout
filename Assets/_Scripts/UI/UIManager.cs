using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehavior<UIManager>
{
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private GameObject gameOverPanel;

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    public void ShowGameOverScreen()
    {
        gameOverPanel.SetActive(true);
    }
}
