using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunConfig : MonoBehaviour
{
    [SerializeField] private float projectileVelocity;

    [SerializeField] Color projectileColor;
    [SerializeField] float projectileScale;
    [SerializeField] private GameObject _beamPrefab;

    [SerializeField] private int _shoots;
    [SerializeField] int munitions;
    private bool _isReloading = false;

    [SerializeField] private float reloadTime;

    private float currentReloadingTime = 0;
    UIManager _uiManager;


    void Start()
    {
        StartCoroutine(ReloadingCoroutine());
        GameObject uiManager = GameObject.Find("UIManager");
        if (uiManager != null)
        {
            _uiManager = uiManager.GetComponent<UIManager>();
            _uiManager.SetMunitionsUI(munitions);
        }
    }

    void Update()
    {
        if (_isReloading)
        {
            _uiManager.SetShotBar(1 / reloadTime);
            currentReloadingTime += Time.deltaTime;
        }
        else
        {
            currentReloadingTime = reloadTime;
            _uiManager.SetShotBar(0);
        }

    }

    public float GetProjectileVelocity()
    {
        return projectileVelocity;
    }

    public Color GetProjectileColor()
    {
        return projectileColor;
    }
    public float GetProjectileScale()
    {
        return projectileScale;
    }

    public GameObject GetGunBeamPrefab()
    {
        return _beamPrefab;
    }

    public void SetMunitions(int munition)
    {
        munitions = munition;
        _uiManager.SetMunitionsUI(munitions);
    }

    public int GetMunitions()
    {
        return munitions;
    }

    public bool GetIsReloading()
    {
        return _isReloading;
    }

    public void SetIsReloading()
    {
        _isReloading = !_isReloading;
    }

    public int GetShoots()
    {
        return _shoots;
    }


    IEnumerator ReloadingCoroutine()
    {
        for (; ; )
        {
            if (_isReloading)
            {
                yield return new WaitForSeconds(reloadTime);
                SetIsReloading();
            }
            yield return null;
        }
    }
}
