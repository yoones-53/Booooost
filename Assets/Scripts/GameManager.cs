using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    int highScore = 0;
    int score = 0;
    public int Score => score;

    
    public void RocketScore()
    {
        if (isGameOver) return;

        score = (int)player.position.x;
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = $"{score}km";
    }

    void Awake()
    {
        Instance = this;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    
    [SerializeField]
    Transform player;

    [Header("Alien")]
    [SerializeField]
    public GameObject[] alienPrefabs;

    [SerializeField]
    Vector2 alienSpawnYRange = new Vector2(-6f, 82f);

    [Header("GameOver")]
    public GameObject gameOverPanel;
    
    [SerializeField]
    Camera targetCamera;

    [SerializeField]
    Transform alienParent;

    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI highScoreText;
    

    [Header("Distance Spawn")]
    [SerializeField]
    float unitsPerSpawn = 10f;     // 이동거리마다 스폰

    [SerializeField]
    float unitsPerLevel = 100f;     // 이동거리마다 난이도 증가
    
    [SerializeField]
    int spawnCount = 1;
    float nextSpawnX = 10f;
    float nextLevelX = 100f;
    bool isGameOver = false;
    
    void Start()
    {
        highScoreText.text = $"{highScore}km";
    }

    void Update()
    {
        if (isGameOver)
        {
            if (Keyboard.current.anyKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            } 
            return;
        }

        RocketScore();

        if (player.position.x >= nextLevelX && spawnCount < 30)
        {
            spawnCount++;
            nextLevelX += unitsPerLevel;
        }

        if (player.position.x >= nextSpawnX)
        {
            SpawnAlien();
            nextSpawnX += unitsPerSpawn;
        }
    }

    public void GameOver()
    {
        isGameOver = true; // 게임오버
        gameOverPanel.SetActive (true); // 게임오버 텍스트

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        highScoreText.text = $"{highScore}km";
    }
    void SpawnAlien()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            float spawnX = player.position.x + Random.Range(20f, 30f);
            float spawnY = Random.Range(alienSpawnYRange.x, alienSpawnYRange.y);
            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);
            
            int randomIndex = Random.Range(0, alienPrefabs.Length);
            Instantiate(alienPrefabs[randomIndex], spawnPosition, Quaternion.identity, alienParent);
        }
    }
}
