using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _energyPrefab;
    [SerializeField] GameObject _batteryPrefab;
    PlayerDisplay _playerDisplay;
    GameManager _gameManager;

    PlayerMoviment _playerMoviment;

    void Start()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        GameObject playerDisplay = GameObject.Find("PlayerDisplay");
        GameObject player = GameObject.Find("Player");
        if (gameManager != null && playerDisplay != null && player != null)
        {
            _gameManager = gameManager.GetComponent<GameManager>();
            _playerDisplay = playerDisplay.GetComponent<PlayerDisplay>();
            _playerMoviment = player.GetComponent<PlayerMoviment>();
            _playerDisplay.CreateBatteryGUI(_gameManager.GetEnergies(), _batteryPrefab);
        }

        StartCoroutine(Teste());
    }

    void Update()
    {

    }


    IEnumerator Teste()
    {
        while (true)
        {
            // _playerDisplay.SetDashBarGUI(_playerMoviment.GetDashTimeCooldown(), _playerMoviment._dashInterval);
            // yield return new WaitForSeconds(1f);
        }
    }

}
