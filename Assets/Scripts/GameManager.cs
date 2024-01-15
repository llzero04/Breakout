using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public Text livesUIText;
    public Text levelText;
    public GameObject gameOverUIPanel;

    int score = 0;
    int level = 1;
    int totalBricks = 0;
    int maxLevel = 4;
    int lives = 3;

    private void Awake()
    {
        level = PlayerPrefs.GetInt("GameLevel", 1);
        lives = 3;
        livesUIText.text = "Lives - " + lives.ToString();
        levelText.text = "Level - " + level.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().stopAudio("HomeTheme");
        FindObjectOfType<AudioManager>().playAudio("GameTheme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementScore(int inc)
    { 
        score += inc;
        if(score >= totalBricks)
        {
            loadNextLevel();
        }
    }

    public void deadBall()
    {
        if(lives == 0)
        {
            gameOver();
        }
        else
        {
            Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);
            lives -= 1;
            livesUIText.text = "Lives - " + lives.ToString();
        }
    }
    public void gameOver()
    {
        FindObjectOfType<AudioManager>().stopAudio("GameTheme");
        FindObjectOfType<AudioManager>().playAudio("GameOver");
        gameOverUIPanel.SetActive(true);
    }

    public int getLevel() {  return level; }
    public void setLevel(int lev) { level = lev; }
    public void setTotalBricks(int val) { totalBricks = val; }
    public void loadNextLevel()
    {
        if(level == maxLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            PlayerPrefs.SetInt("GameLevel", level + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void endGame()
    {
        PlayerPrefs.SetInt("GameLevel", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
