using System;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameController : MonoBehaviour
{
    private PelletSpawner _pelletSpawner;
    private PelletCollector _pelletCollector;

    [SerializeField] private GameObject _gameOverScreen;

    private void Awake()
    {
        _pelletSpawner = GetComponent<PelletSpawner>();
        _pelletCollector = GetComponent<PelletCollector>();
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        _gameOverScreen.SetActive(false);
        _pelletCollector.ResetCounter();
        _pelletSpawner.SpawnPellets();
    }

    public void EndGame()
    {
        _gameOverScreen.SetActive(true);
    }

    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
