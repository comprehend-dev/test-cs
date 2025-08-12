using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Text scoreText;
    public Text livesText;
    public GameObject gameOverPanel;
    
    [Header("Game Settings")]
    public int maxLives = 3;
    
    private int score = 0;
    private int lives;
    private bool gameRunning = true;
    
    public static GameManager Instance { get; private set; }
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        lives = maxLives;
        UpdateUI();
    }
    
    public void AddScore(int points)
    {
        if (!gameRunning) return;
        
        score += points;
        UpdateUI();
    }
    
    public void LoseLife()
    {
        if (!gameRunning) return;
        
        lives--;
        UpdateUI();
        
        if (lives <= 0)
        {
            GameOver();
        }
    }
    
    private void GameOver()
    {
        gameRunning = false;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        score = 0;
        lives = maxLives;
        gameRunning = true;
        gameOverPanel.SetActive(false);
        UpdateUI();
    }
    
    private void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }
}