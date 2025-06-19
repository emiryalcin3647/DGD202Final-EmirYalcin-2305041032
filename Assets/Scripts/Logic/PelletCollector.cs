using UnityEngine;
using TMPro;

public class PelletCollector : MonoBehaviour
{
    public static PelletCollector Instance;

    [SerializeField] private TMP_Text _counter;
    [SerializeField] private GameObject _gameCompletedPanel;

    private PelletSpawner _pelletSpawner;
    private AudioSource _audioSource;

    private int _numberToCollect;
    private int _numberCollected;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        _pelletSpawner = FindObjectOfType<PelletSpawner>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _numberToCollect = _pelletSpawner.NumberToSpawn;
        _numberCollected = 0;
        _counter.text = "0";

        if (_gameCompletedPanel != null)
            _gameCompletedPanel.SetActive(false);
    }

    public void PelletCollected()
    {
        _numberCollected++;
        _counter.text = _numberCollected.ToString();

        if (_audioSource != null && _audioSource.clip != null)
        {
            _audioSource.PlayOneShot(_audioSource.clip);
        }

        if (_numberCollected >= _numberToCollect)
        {
            if (_gameCompletedPanel != null)
                _gameCompletedPanel.SetActive(true);
        }
    }

    public void ResetCounter()
    {
        _numberCollected = 0;
        _counter.text = "0";

        if (_gameCompletedPanel != null)
            _gameCompletedPanel.SetActive(false);
    }
}
