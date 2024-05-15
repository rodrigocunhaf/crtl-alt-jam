using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _energyPrefab;
    PlayerDisplay _playerDisplay;
    GameManager _gameManager;

    PlayerMoviment _playerMoviment;

    void Awake()
    {

        GameObject gameManager = GameObject.Find("GameManager");
        GameObject playerDisplay = GameObject.Find("PlayerDisplay");
        GameObject player = GameObject.Find("Player");
        if (gameManager != null && playerDisplay != null && player != null)
        {
            _gameManager = gameManager.GetComponent<GameManager>();
            _playerDisplay = playerDisplay.GetComponent<PlayerDisplay>();
            _playerMoviment = player.GetComponent<PlayerMoviment>();
        }
    }

    void Start()
    {

    }
    void Update()
    {
        if (_playerDisplay != null)
        {
            _playerDisplay.SetDashBarGUI(_playerMoviment.GetDashTimeCooldown());
        }
    }

}
