using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _uiWinGame;
    [SerializeField] private GameObject _uiLoseGame;
    [SerializeField] private Button _btnRestartWinGame;
    [SerializeField] private Button _btnRestartMainGame;
    [SerializeField] private Button _btnRestartLoseGame;

    private void Start()
    {
        ShowHideWinUI(false);
        ShowHideLoseUI(false);
        _btnRestartMainGame.onClick.AddListener(OnClickRestartGame);
        _btnRestartWinGame.onClick.AddListener(OnClickRestartGame);
        _btnRestartLoseGame.onClick.AddListener(OnClickRestartGame);
    }

    public void ShowHideWinUI(bool isShow)
    {
        _uiWinGame.SetActive(isShow);
    }

    public void ShowHideLoseUI(bool isShow)
    {
        _uiLoseGame.SetActive(isShow);
    }

    private void OnClickRestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
