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
        animator = body.GetComponent<Animator>();
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
            if (_shooting)
            {
                animator.SetBool("shoot", true);
                GunConfig gunConfig = _playerGun.GetComponent<GunConfig>();
                if (!gunConfig.GetIsReloading())
                {
                    if (gunConfig.GetMunitions() > 0)
                    {
                        if (gunConfig.GetMunitions() < gunConfig.GetShoots())
                        {

                            for (int i = 0; i < gunConfig.GetMunitions(); i++)
                            {
                                GameObject firedBeam = Instantiate(gunConfig.GetGunBeamPrefab(), _playerGun.transform.position, Quaternion.identity);
                                Beam beamConfig = firedBeam.GetComponent<Beam>();
                                firedBeam.transform.rotation = _playerGun.transform.rotation;
                                firedBeam.transform.parent = _playerGun.transform;
                                beamConfig.SetBeanConfig(gunConfig, "PlayerBeam");
                                _playerGun.transform.rotation = gameObject.transform.rotation;
                                yield return new WaitForSeconds(0.1f);
                            }
                            yield return new WaitForSeconds(0.1f);
                            gunConfig.SetMunitions(0);
                        }
                        else
                        {
                            for (int i = 0; i < gunConfig.GetShoots(); i++)
                            {
                                GameObject firedBeam = Instantiate(gunConfig.GetGunBeamPrefab(), _playerGun.transform.position, Quaternion.identity);
                                Beam beamConfig = firedBeam.GetComponent<Beam>();
                                firedBeam.transform.rotation = _playerGun.transform.rotation;
                                firedBeam.transform.parent = _playerGun.transform;
                                beamConfig.SetBeanConfig(gunConfig, "PlayerBeam");
                                _playerGun.transform.rotation = gameObject.transform.rotation;
                                gunConfig.SetMunitions(gunConfig.GetMunitions() - 1);

                                yield return new WaitForSeconds(0.1f);
                            }
                        }

                        gunConfig.SetIsReloading();
                    }

                }
            }
            else
            {
                animator.SetBool("shoot", false);
            }


            yield return null;
        }
    }


}
