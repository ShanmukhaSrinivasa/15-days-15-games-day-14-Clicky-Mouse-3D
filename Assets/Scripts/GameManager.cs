using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> targets;

    private float spawnRate = 1.0f;

    public bool isGameActive = false;

    [Header("Canvas Groups")]
    [SerializeField] private CanvasGroup gameStartCG;
    [SerializeField] private CanvasGroup gameCG;
    [SerializeField] private CanvasGroup gameOverCG;

    [Header("UI Elements")]
    private int score = 0;
    private int highScore = 0;
    public int lives = 3;
    [SerializeField] private TextMeshProUGUI scoreCount;
    [SerializeField] private TextMeshProUGUI highScoreCount;
    [SerializeField] private TextMeshProUGUI go_scoreCount;
    [SerializeField] private TextMeshProUGUI go_highScoreCount;
    [SerializeField] private TextMeshProUGUI livesCount;

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

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreCount.text = highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        ShowCG(gameCG);
        HideCG(gameStartCG);
        HideCG(gameOverCG);

        isGameActive = true;
        lives = 3;
        UpdateLives();

        PlayerPrefs.GetInt("highScore");
        highScoreCount.text = highScore.ToString();

        StartCoroutine(SpawnTargets());
        score = 0;
        UpdateScore(0);
    }

    public void GameOver()
    {
        isGameActive = false;

        ShowCG(gameOverCG);
        HideCG(gameCG);
        HideCG(gameStartCG);
        go_scoreCount.text = score.ToString();
        go_highScoreCount.text = highScore.ToString();
    }

    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreCount.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        highScoreCount.text = highScore.ToString();
    }

    public void UpdateLives()
    {
        livesCount.text = lives.ToString();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void ShowCG(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    public void HideCG(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    public void RestartButtonCallback()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
