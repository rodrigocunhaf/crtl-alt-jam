using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{
    [SerializeField] GameObject _player;

    private Camera _mainCamera;
    Slider _slider;


    void Awake()
    {
        GameObject player = GameObject.Find("Player");
        Camera mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        GameObject dashBar = GameObject.Find("DashBar");
        if (mainCamera != null && dashBar != null)
        {
            _mainCamera = mainCamera;
            _slider = dashBar.GetComponent<Slider>();
            _player = player;
            Vector3 positionPlayer = _mainCamera.WorldToScreenPoint(_player.transform.position);
            RectTransform rectPosition = GetComponent<RectTransform>();
            rectPosition.anchoredPosition = new Vector3(positionPlayer.x, positionPlayer.y + 100f, positionPlayer.z);
        }
    }
    void Start()
    {
    }

    void Update()
    {

        Vector3 positionPlayer = _mainCamera.WorldToScreenPoint(_player.transform.position);
        RectTransform rectPosition = GetComponent<RectTransform>();
        rectPosition.anchoredPosition = new Vector3(positionPlayer.x, positionPlayer.y + 100f, positionPlayer.z);
    }

    public void SetDashBarGUI(float dashCooldown, float interval)
    {
        if (dashCooldown > 0)
        {
            _slider.value += (1 / interval) * Time.deltaTime;
        }
        else
        {
            _slider.value = 0;
        }

    }
}
