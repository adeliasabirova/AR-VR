using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    private bool _isPaused = false;

    [SerializeField] private UnityEngine.UI.Button _bttnResume;
    [SerializeField] private UnityEngine.UI.Button _bttnRestart;

    [SerializeField] private UnityEngine.UI.Button _bttnMenu;

    private void Awake()
    {
        _bttnResume.onClick.AddListener(DeactivateMenu);
        _bttnRestart.onClick.AddListener(RestartGame);
        _bttnMenu.onClick.AddListener(MainMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            _isPaused = !_isPaused;
        }

        if (_isPaused)
            ActivateMenu();
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void MainMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        _isPaused = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("MenuScene");
    }

    void RestartGame()
    {
        DeactivateMenu();
        SceneManager.LoadScene("FirstLevelScene");
    }

    void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        _isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
