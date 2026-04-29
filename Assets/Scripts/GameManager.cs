using UnityEngine; 
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public GameObject gameOverText;  
    public Rocket rocket;
    public bool isGameOver = false;


    [Header("Score")]
    public TMP_Text scoreText;
    public Transform player;

    private int score;
    private bool canRestart = false;
    
    void Awake()
    {
        if (instance == null)              instance = this;
        else if(instance != this)        Destroy (gameObject);
    }
    void Update()
    {
        RocketScored();
        
        if (!isGameOver || !canRestart) return;

        if ((isGameOver && Keyboard.current.anyKey.wasPressedThisFrame) || Mouse.current.leftButton.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
        } 
    }
    public void RocketExplode()
    {
        gameOverText.SetActive (true);
        isGameOver = true;
        rocket.Explode();

        Invoke(nameof(EnableRestart), 0.2f);
    }
    void EnableRestart()
    {
        canRestart = true;
    }
    public void RocketScored()
    {
        if (isGameOver) return;

        score = (int)player.position.x;
        
        if (score < 0)
        {
            score = 0;
        }

        scoreText.text = score.ToString() + "km";
    }
}
