using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _tryAgainButton;
    [SerializeField] private Button _exitGameButton;
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource _backgroundMusic;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
        _tryAgainButton.onClick.AddListener(OnTryAgainButtonClick);
        _exitGameButton.onClick.AddListener(OnExitGameButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
        _tryAgainButton.onClick.RemoveListener(OnTryAgainButtonClick);
        _exitGameButton.onClick.RemoveListener(OnExitGameButtonClick);
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
    }

    private void OnPlayerDied()
    {
        _gameOverGroup.alpha = 1;
        Time.timeScale = 0;
        _backgroundMusic.Stop();
    }

    private void OnTryAgainButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnExitGameButtonClick()
    {
        Application.Quit();
    }
}
