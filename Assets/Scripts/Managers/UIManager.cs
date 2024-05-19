using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _batteryPrefab;
    PlayerDisplay _playerDisplay;
    GameManager _gameManager;

    PlayerMoviment _playerMoviment;
    EnergyDisplay _energyDisplay;

    Munitions _munitions;

    Slider _shotBar;

    void Awake()
    {

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); ;
        _playerDisplay = GameObject.Find("PlayerDisplay").GetComponent<PlayerDisplay>();
        _playerMoviment = GameObject.Find("Player").GetComponent<PlayerMoviment>();
        _energyDisplay = GameObject.Find("Energies").GetComponent<EnergyDisplay>(); ;
        _munitions = GameObject.Find("Munitions").GetComponent<Munitions>();
        _shotBar = GameObject.Find("ShotBar").GetComponent<Slider>();
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

    public void SetMunitionsUI(int munitions)
    {
        _munitions.SetUIMunitions(munitions);

    }

    public void SetShotBar(float timer)
    {
        if (timer == 0)
        {
            _shotBar.value = 0;
        }
        else
        {

            _shotBar.value += (_shotBar.value + timer) * Time.deltaTime;
        }

    }

}
