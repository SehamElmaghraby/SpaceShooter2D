using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool playerDestroyed = false;
    public bool gameOverShown = false;


    
    [Header("Enemy Settings")]
    public GameObject enemyPrefab;
    public float minInstantiateValue;
    public float maxInstantiateValue;
    public float enemyDestroyTime = 10f;

    [Header("Practical Effects")]
    public GameObject explosion;
    public GameObject muzzleflash;

    [Header("UI Panels")]
    public GameObject startMenu;
    public GameObject pauseMenu;
    public GameObject gameOver;
    public GameObject HUD;

    [HideInInspector]
    public bool isGameOver = false; 
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        startMenu.SetActive(true);
        pauseMenu.SetActive(false);
        gameOver.SetActive(false);
        HUD.SetActive(false);
        Time.timeScale = 0f;
        InvokeRepeating("InstantiateEnemy", 1f, 1f);
    }



void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape) && !playerDestroyed)
    {
        PauseGame(!pauseMenu.activeSelf);
    }

    if (Input.GetKeyDown(KeyCode.G) && playerDestroyed && !gameOverShown)
    {
        GameOver();
        gameOverShown = true;
    }
}


    void InstantiateEnemy()
    {
        Vector3 enemyPos = new Vector3(Random.Range(minInstantiateValue, maxInstantiateValue), 4f);
        GameObject enemy = Instantiate(enemyPrefab, enemyPos, Quaternion.Euler(0f, 0f, 180f));
        Destroy(enemy, enemyDestroyTime);
    }

    public void StartGameButton()
    {
        startMenu.SetActive(false);
        HUD.SetActive(true);
        pauseMenu.SetActive(false);
        gameOver.SetActive(false);
        isGameOver = false;
        Time.timeScale = 1f;
    }

    public void PauseGame(bool isPaused)
    {
        if (isPaused)
        {
            pauseMenu.SetActive(true);
            HUD.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            HUD.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    public void QuitGame()
    {
        pauseMenu.SetActive(false);
        startMenu.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
        isGameOver = false;
    }


    public void GameOver()
    {
        isGameOver = true;
        gameOver.SetActive(true);
        gameOver.transform.SetAsLastSibling();
        HUD.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        isGameOver = false;
    }
}
