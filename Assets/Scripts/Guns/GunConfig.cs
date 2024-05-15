using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunConfig : MonoBehaviour
{
    [SerializeField] private readonly float fireHate;

    public float GetFireHate()
    {
        return fireHate;
    }
}
