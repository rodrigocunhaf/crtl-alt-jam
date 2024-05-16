using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunConfig : MonoBehaviour
{
    [SerializeField] private float projectileVelocity;

    [SerializeField] Color projectileColor;
    [SerializeField] float projectileScale;
    [SerializeField] private GameObject _beamPrefab;



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
}
