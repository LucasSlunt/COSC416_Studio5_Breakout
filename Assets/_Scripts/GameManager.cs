﻿using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private Ball ball;
    [SerializeField] private Transform bricksContainer;

    private int currentBrickCount;
    private int totalBrickCount;

    private void OnEnable()
    {
        InputHandler.Instance.OnFire.AddListener(FireBall);
        ball.ResetBall();
        totalBrickCount = bricksContainer.childCount;
        currentBrickCount = bricksContainer.childCount;
    }

    private void OnDisable()
    {
        InputHandler.Instance.OnFire.RemoveListener(FireBall);
    }

    private void FireBall()
    {
        AudioManager.Instance.PlaySFX("hitPaddle");
        ball.FireBall();
        
    }

    public void OnBrickDestroyed(Vector3 position)
    {
        // fire audio here
        AudioManager.Instance.PlaySFX("destroyBlock");
        // implement particle effect here
        // add camera shake here
        ShakeManager.addShake();
        currentBrickCount--;
        Debug.Log($"Destroyed Brick at {position}, {currentBrickCount}/{totalBrickCount} remaining");
        if (currentBrickCount == 0)
        {
            AudioManager.Instance.PlaySFX("gameWin");
            SceneHandler.Instance.LoadNextScene();
        }
        
    }

    public void KillBall()
    {
        AudioManager.Instance.PlaySFX("loseLife");

        maxLives--;
        // update lives on HUD here
        UIManager.Instance.UpdateLives(maxLives);
        
        // game over UI if maxLives < 0, then exit to main menu after delay
        if (maxLives <= 0)
        {
            StartCoroutine(GameOver());
            return;
        }

        ball.ResetBall();
    }

    private IEnumerator GameOver()
    {
        AudioManager.Instance.PlaySFX("gameOver");

        //freeze the game so the player cannot do anything
        Time.timeScale = 0;

        //Show the game over screen
        AudioManager.Instance.PlayMusic("gameOverMusic");
        UIManager.Instance.ShowGameOverScreen();

        //wait 1.5 seconds
        yield return new WaitForSeconds(1.5f);

        Time.timeScale = 1;

        Debug.Log("Loading Menu Scene...");
        SceneHandler.Instance.LoadMenuScene();
        Debug.Log("Main Menu scene loaded.");
    }
}
