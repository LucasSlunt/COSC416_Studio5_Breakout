using System.Collections;
using TMPro;
using UnityEngine;

public class FlashingText : MonoBehaviour
{
    private TextMeshProUGUI gameOverText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(FlashText());
    }

    // Update is called once per frame
    private IEnumerator FlashText()
    {
            Debug.Log("FlashingText coroutine started!"); // Add this

        while (true)
        {
            gameOverText.alpha = 0;
            Debug.Log("Text hidden");

            yield return new WaitForSecondsRealtime(0.5f);

            gameOverText.alpha = 1;
            Debug.Log("Text shown");

            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
