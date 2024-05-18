using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeamColliders : MonoBehaviour
{
    GameManager _gameManager;
    UIManager _uiManager;

    void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _gameManager.GetVulnerability() == true)
        {
            print("colideiiiii");
            Destroy(gameObject);
            if (_gameManager.GetEnergies() > 0)
            {
                _uiManager.RemoveUIEnergies();
                _gameManager.RemoveEnergy();

            }
        }
    }

}
