using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDisplay : MonoBehaviour
{
    [SerializeField] GameObject _enemy;

    private Camera _mainCamera;

    void Start()
    {

        GameObject enemy = GameObject.Find("Enemy");
        Camera mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        if (mainCamera != null && enemy != null)
        {
            _enemy = enemy;
            _mainCamera = mainCamera;
            Vector3 positionEnemy = _mainCamera.WorldToScreenPoint(_enemy.transform.position);
            RectTransform rectPosition = GetComponent<RectTransform>();
            rectPosition.anchoredPosition = new Vector3(positionEnemy.x, positionEnemy.y, 0);
        }
    }

    void Update()
    {

        Vector3 positionPlayer = _mainCamera.WorldToScreenPoint(_enemy.transform.position);
        RectTransform rectPosition = GetComponent<RectTransform>();
        rectPosition.anchoredPosition = new Vector3(positionPlayer.x, positionPlayer.y + 100f, positionPlayer.z);
    }

}
