using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{
    [SerializeField] GameObject _player;

    private Camera _mainCamera;

    GameObject _energies;
    Slider _slider;


    void Start()
    {
        GameObject energies = GameObject.Find("Energies");
        GameObject player = GameObject.Find("Player");
        Camera mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        GameObject dashBar = GameObject.Find("DashBar");
        if (energies != null && mainCamera != null && dashBar != null)
        {
            _energies = energies;
            _mainCamera = mainCamera;
            _slider = dashBar.GetComponent<Slider>();
            _player = player;
            Vector3 positionPlayer = _mainCamera.WorldToScreenPoint(_player.transform.position);
            RectTransform rectPosition = GetComponent<RectTransform>();
            rectPosition.anchoredPosition = new Vector3(positionPlayer.x, positionPlayer.y + 100f, positionPlayer.z);
        }
    }

    void Update()
    {

        Vector3 positionPlayer = _mainCamera.WorldToScreenPoint(_player.transform.position);
        RectTransform rectPosition = GetComponent<RectTransform>();
        rectPosition.anchoredPosition = new Vector3(positionPlayer.x, positionPlayer.y + 100f, positionPlayer.z);
    }

    public void CreateBatteryGUI(int nErgies, GameObject _energyPrefab)
    {
        for (int i = 0; i < nErgies; i++)
        {
            GameObject newNergie = Instantiate(_energyPrefab, new Vector3(_energies.transform.position.x + 34.2f * i, _energies.transform.position.y, _energies.transform.position.z), Quaternion.identity);
            newNergie.transform.SetParent(_energies.transform);
        }
    }


    public void SetDashBarGUI(float dashCooldown)
    {
        if (dashCooldown < 0)
        {
            _slider.value = 1;
        }
        else
        {

            _slider.value = 1 - (1 / dashCooldown);
        }
    }
}
