using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private GameObject _playerGun;
    [SerializeField] private GameObject _beam;

    [SerializeField] private float _fireRate;
    private bool _shooting = false;

    void Start()
    {
        StartCoroutine(FireShot());
    }


    public void OnShot(InputAction.CallbackContext context)
    {
        _shooting = context.ReadValueAsButton();

    }

    IEnumerator FireShot()
    {
        while (true)
        {
            _playerGun.transform.rotation = gameObject.transform.rotation;
            if (_shooting)
            {
                GameObject firedBeam = Instantiate(_beam, _playerGun.transform.position, Quaternion.identity);
                firedBeam.transform.rotation = _playerGun.transform.rotation;
                firedBeam.transform.parent = _playerGun.transform;
            };
            yield return new WaitForSeconds(_fireRate);
        }
    }


}
