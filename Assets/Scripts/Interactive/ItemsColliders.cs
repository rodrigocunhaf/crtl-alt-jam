using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemsColliders : MonoBehaviour
{
    GameManager _gameManager;
    UIManager _uiManager;

    void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("Player"))
        {
            Destroy(gameObject);

            if (gameObject.name == "Battery")
            {
                _gameManager.AddEnergy();
                _uiManager.SetUIEnergies();
            }

            if (gameObject.name == "Key")
            {
                _gameManager.SetKeys();

            }

        }
    }
    // Start is called before the first frame update
}
