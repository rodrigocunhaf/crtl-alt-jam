using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyConfig : MonoBehaviour
{
    [SerializeField] private int _keyValue;

    public int GetKey()
    {
        return _keyValue;
    }
}
