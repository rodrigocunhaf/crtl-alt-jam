using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _batteryPrefab;
    PlayerDisplay _playerDisplay;
    GameManager _gameManager;

    PlayerMoviment _playerMoviment;

    void Awake()
    {

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); ;
        _playerDisplay = GameObject.Find("PlayerDisplay").GetComponent<PlayerDisplay>();
        _playerMoviment = GameObject.Find("Player").GetComponent<PlayerMoviment>(); ;

    }

    void Start()
    {
        StartCoroutine(Teste());
        SetUIEnergies();
    }

    void Update()
    {

    }


    IEnumerator Teste()
    {
        while (true)
        {
            _playerDisplay.SetDashBarGUI(_playerMoviment.GetDashTimeCooldown(), _playerMoviment._dashInterval);
            yield return new WaitForSeconds(1f);
        }
    }

    public void SetUIEnergies()
    {
        _playerDisplay.CreateBatteryGUI(_gameManager.GetEnergies(), _batteryPrefab);
    }

    public void RemoveUIEnergies()
    {
        _playerDisplay.DestroyBatteryGUI(_gameManager.GetEnergies());
    }

}
