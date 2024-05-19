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
    [SerializeField] GameObject[] _doorsPrefabs;
    [SerializeField] GameObject[] _keysDoorsPrefabs;

    private IEnumerator routineUI;

    void Update()
    {

        if (_energy < 0)
        {
            Time.timeScale = 0;
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
        if (_energy >= 0)
        {
            _energy -= 1;
        }
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

    IEnumerable OnEnergyFuel()
    {
        while (true)
        {
            if (_energy <= 0)
            {
                Time.timeScale = 0;

            }
            print("EndGame");
            yield return new WaitForSeconds(1f);
        }
    }

}
