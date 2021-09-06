using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private GameObject _panelSettings;

    [SerializeField] private UnityEngine.UI.Button _bttnStart;
    [SerializeField] private UnityEngine.UI.Button _bttnSettings;
    [SerializeField] private UnityEngine.UI.Button _bttnQuit;
    [SerializeField] private UnityEngine.UI.Button _bttnBack;

    [SerializeField] private UnityEngine.UI.Toggle _tgglMuteMusic;
    [SerializeField] private UnityEngine.UI.Toggle _tgglMuteSounds;

    private bool _muteMusic = false;
    private bool _muteSound = false;

    private void Awake()
    {
        _bttnStart.onClick.AddListener(StartGame);
        _bttnSettings.onClick.AddListener(ShowSetting);
        _bttnQuit.onClick.AddListener(QuitGame);
        _bttnBack.onClick.AddListener(ShowMenu);
        PlayerPrefs.DeleteAll();
    }

    private void ShowSetting()
    {
        _panelSettings.SetActive(true);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void ShowMenu()
    {
        _panelSettings.SetActive(false);
    }
    private void StartGame()
    {
        SceneManager.LoadScene("FirstLevelScene");
    }

    public void MuteSound(bool value)
    {
        _muteSound = value;
        PlayerPrefs.SetString("MuteSound", _muteSound.ToString());
    }

    public void MuteMusic(bool value)
    {
        _muteMusic = value;
        PlayerPrefs.SetString("MuteMusic", _muteMusic.ToString());
    }

}
