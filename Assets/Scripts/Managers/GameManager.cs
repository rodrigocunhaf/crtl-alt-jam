using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _energy;
    [SerializeField] private int _keys;

    [SerializeField] bool _vunerability = true;
    [SerializeField] private float immunityTimeMax = 3f;

    [SerializeField] GameObject _player;


    void Start()
    {
        StartCoroutine(GameProgressRoutine());
    }

    IEnumerator GameProgressRoutine()
    {
        for (; ; )
        {
            if (_energy < 0)
            {
                Time.timeScale = 0;
                yield return new WaitForSeconds(1f);
            }
            else
            {

                yield return new WaitForSeconds(1f);
            }
        }
    }

    public int GetEnergies()
    {
        return _energy;
    }
    public void AddEnergy()
    {
        _energy += 1;
    }

    public void RemoveEnergy()
    {
        if (_energy > 0)
        {
            _energy -= 1;
        }
    }

    public void SetVulnerability()
    {

    }

    public bool GetVulnerability()
    {
        return _vunerability;
    }

    public int GetKeys()
    {
        return _keys;
    }
    public void SetKeys()
    {
        _keys += 1;
    }

}
