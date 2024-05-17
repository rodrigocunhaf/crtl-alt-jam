using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerColliders : MonoBehaviour
{
    [SerializeField] private GameObject _bag;
    GameManager _gameManager;

    void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.name == "Key")
        {
            _bag.SetActive(true);
        }

        if (collider.CompareTag("Projectile") && collider.gameObject.layer == 6)
        {
            _gameManager.SetVulnerability();
        }
    }
}
