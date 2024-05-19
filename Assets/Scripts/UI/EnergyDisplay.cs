using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnergyDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _energyPrefab;
    GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        for (int i = 0; i < _gameManager.GetEnergies(); i++)
        {
            AddBatteryUI();
        }
    }

    public void AddBatteryUI()
    {
        Transform container = gameObject.transform;
        int childrens = container.childCount;
        GameObject newNergie = Instantiate(_energyPrefab, new Vector3(container.position.x + 34.2f * childrens, container.position.y, container.position.z), Quaternion.identity);
        newNergie.transform.SetParent(container.transform);
    }

    public void RemoveBatteryUI()
    {
        Transform container = gameObject.transform;
        print(gameObject.transform.childCount);
        Destroy(container.GetChild(container.childCount - 1).gameObject);
    }
}
