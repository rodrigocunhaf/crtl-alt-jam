using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ItemsColliders : MonoBehaviour
{
    GameManager _gameManager;
    UIManager _uiManager;
    [SerializeField] int _quanty;


    void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void Start()
    {

    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("Player"))
        {


            if (gameObject.name == "Battery")
            {
                if (_gameManager.GetEnergies() < 5)
                {
                    _gameManager.AddEnergy();
                    _uiManager.SetUIEnergies();
                    Destroy(gameObject);

                }
            }

            if (gameObject.name == "Key")
            {
                GameObject playerBagPrefab = collider.gameObject.transform.Find("PlayerBag").gameObject;
                _gameManager.SetKeys();
                gameObject.transform.parent = playerBagPrefab.transform;
                gameObject.SetActive(false);

            }

            if (gameObject.name == "Munition")
            {
                GunConfig playerGun = collider.transform.Find("PlayerGun").GetComponent<GunConfig>();
                playerGun.SetMunitions(_quanty);
                Destroy(gameObject);
            }

        }
    }
    // Start is called before the first frame update
}
