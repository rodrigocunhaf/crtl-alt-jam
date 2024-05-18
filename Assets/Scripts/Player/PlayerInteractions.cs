using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private GameObject _playerGun;
    private bool _shooting = false;
    [SerializeField] GameObject body;
    private Animator animator;

    void Start()
    {
        StartCoroutine(FireShot());
        animator = body.GetComponent<Animator>();
    }


    public void OnShot(InputAction.CallbackContext context)
    {
        _shooting = context.ReadValueAsButton();

    }

    void Update()
    {
        if (_shooting)
        {
            animator.SetBool("shoot", true);
        }
        else
        {
            animator.SetBool("shoot", false);
        }
    }

    IEnumerator FireShot()
    {
        while (true)
        {
            _playerGun.transform.rotation = gameObject.transform.rotation;
            if (_shooting)
            {

                GunConfig gunConfig = _playerGun.GetComponent<GunConfig>();
                print(gunConfig);
                GameObject firedBeam = Instantiate(gunConfig.GetGunBeamPrefab(), _playerGun.transform.position, Quaternion.identity);
                Beam beamConfig = firedBeam.GetComponent<Beam>();
                firedBeam.transform.rotation = _playerGun.transform.rotation;
                firedBeam.transform.parent = _playerGun.transform;
                beamConfig.SetBeanConfig(gunConfig, "PlayerBeam");
                print("Shoot");

            }


            yield return new WaitForSeconds(0.1f);
        }
    }


}
