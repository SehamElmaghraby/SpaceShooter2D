// using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance ;
   public GameObject enemyPrefab;
   public float minInstantiateValue;
     public float maxInstantiateValue;
    public float enemyDestroyTime = 10f;
    [Header("practical effects")]
    public GameObject explosion ;
    public GameObject muzzleflash ;
     [Header("panels")]
     public GameObject startMenu ;
     public GameObject pauseMenu;
     public GameObject playerPrefab; 
public Transform playerSpawnPoint;
     

    void Awake()
    {
        instance=this;
    }
    void Start()
    {
         startMenu.SetActive(true);
         pauseMenu.SetActive(false);
         Time.timeScale=0f;
        InvokeRepeating("InstantiateEnemy",1f,1f);
    }
    void Update()
{
     if(Input.GetKeyDown(KeyCode.Escape))
    {
        PauseGame(!pauseMenu.activeSelf);
    }

}

    
    
    void InstantiateEnemy()
    {
        Vector3 enemyPos = new Vector3(Random.Range(minInstantiateValue,maxInstantiateValue),4f);
        GameObject enemy =  Instantiate(enemyPrefab, enemyPos,Quaternion.Euler(0f,0f,180f));
        Destroy(enemy,enemyDestroyTime);
    }
    public void StartGameButton()
    {
       startMenu.SetActive(false); 
       Time.timeScale=1f;
    }
    public void PauseGame(bool isPaused)
    {  
         if(isPaused)
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    else
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
       
    }
    public void QuitGame()
    {
        pauseMenu.SetActive(false);
    
    
    startMenu.SetActive(true);
    
    
    Time.timeScale = 0f;  
    }
   

}
