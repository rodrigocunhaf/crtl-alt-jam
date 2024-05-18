using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerColliders : MonoBehaviour
{
    [SerializeField] private GameObject _bag;
    [SerializeField] private GameObject _energyShield;
    GameManager _gameManager;
    bool shieldActive = false;

    void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Start()
    {
        StartCoroutine(CountdownShield());
    }
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.name == "Key")
        {
            _bag.SetActive(true);
        }

        if (collider.CompareTag("Projectile") && collider.gameObject.layer == 6)
        {
            if (_gameManager.GetEnergies() > 0)
            {
                _gameManager.SetVulnerability();
                shieldActive = true;
                _energyShield.SetActive(true);
            }
        }
    }

    IEnumerator CountdownShield()
    {
        for (; ; )
        {
            if (shieldActive)
            {
                yield return new WaitForSeconds(6f);
                _energyShield.SetActive(false);
                shieldActive = false;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    void CancelShield()
    {
        _energyShield.SetActive(false);
    }
}
