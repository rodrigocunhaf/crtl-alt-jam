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
        if (other.CompareTag("Player"))
        {
            print("colideiiiii");
            Destroy(gameObject);
            _gameManager.RemoveEnergy();
            if (_gameManager.GetEnergies() > 0)
            {
                _uiManager.RemoveUIEnergies();

            }
        }
    }

}
