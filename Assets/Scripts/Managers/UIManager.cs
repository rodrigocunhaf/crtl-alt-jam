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
    EnergyDisplay _energyDisplay;

    void Awake()
    {

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); ;
        _playerDisplay = GameObject.Find("PlayerDisplay").GetComponent<PlayerDisplay>();
        _playerMoviment = GameObject.Find("Player").GetComponent<PlayerMoviment>();
        _energyDisplay = GameObject.Find("Energies").GetComponent<EnergyDisplay>(); ;

    }

    void Start()
    {
        StartCoroutine(Teste());

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
        _energyDisplay.AddBatteryUI();
    }

    public void RemoveUIEnergies()
    {
        if (_gameManager.GetEnergies() >= 0)
        {
            _energyDisplay.RemoveBatteryUI();

        }

    }

}
