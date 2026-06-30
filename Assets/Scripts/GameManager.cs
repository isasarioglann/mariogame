using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text scoreText;
   

    private int score = 0;
    private int maxScore = 10; // Skor 10 olduðunda oyun bitecek

    public GameObject gameOverPanel;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0; // Skoru sýfýrla
        scoreText.text = "PUAN: " + score;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int value)
    {
        if (instance == null)
        {
            Debug.LogError("GameManager instance is NULL!");
            return;
        }

        score += value;
        scoreText.text = "PUAN: " + score;

        if (score >= maxScore)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("OYUN TAMAMLANDI ");
        Time.timeScale = 0; // Oyunu durdur
        gameOverPanel.SetActive(true); // Game Over yazýsýný aç
    }

}
