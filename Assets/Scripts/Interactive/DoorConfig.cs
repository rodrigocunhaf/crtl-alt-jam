using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorConfig : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _keyPrefab;
    [SerializeField] private GameObject _doorbtnPrefab;
    private KeyConfig _keyConfig;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        if (_keyPrefab != null && _keyPrefab.GetComponent<KeyConfig>() != null)
        {
            _keyConfig = _keyPrefab.GetComponent<KeyConfig>();
        }
    }

    public Animator GetAnimator()
    {
        return animator;
    }

    public int MatchKey()
    {
        return _keyConfig.GetKey();
    }
}
