using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _energy = 3;


    public int GetEnergies()
    {
        return _energy;
    }
    public void SetEnergies()
    {
        _energy += 1;
    }
}
