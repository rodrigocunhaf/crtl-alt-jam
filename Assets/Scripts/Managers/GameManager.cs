using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _energy;
    [SerializeField] private int _keys;

    bool _vunerability = true;
    [SerializeField] private float immunityTimeMax = 3f;
    private float currentimmunityTime = 3;

    [SerializeField] GameObject _player;

    Material _transparenceMateiral;
    Material _defaultMaterial;

    private bool isTransparent;
    MeshRenderer rend;

    void Awake()
    {
        rend = _player.GetComponent<MeshRenderer>();
        _defaultMaterial = rend.material;
        _transparenceMateiral = Resources.Load<Material>("transparent");

    }

    void Update()
    {
        if (!_vunerability)
        {
            currentimmunityTime -= Time.deltaTime;
        }

    }

    public int GetEnergies()
    {
        return _energy;
    }
    public void AddEnergy()
    {
        _energy += 1;
    }

    public void RemoveEnergy()
    {
        if (_energy > 0)
        {
            _energy -= 1;
        }
        else
        {
            print("EndGame");
        }
    }

    public void SetVulnerability()
    {
        _vunerability = !_vunerability;
        currentimmunityTime = 3f;
        StartCoroutine(VulnerabilityCountdown());
    }

    public int GetKeys()
    {
        return _keys;
    }
    public void SetKeys()
    {
        _keys += 1;
    }

    IEnumerator VulnerabilityCountdown()
    {
        while (!_vunerability)
        {
            if (!isTransparent)
            {
                rend.material = _transparenceMateiral;
                isTransparent = true;

            }
            else
            {
                rend.material = _defaultMaterial;
                isTransparent = false;


            }
            yield return new WaitForSeconds(0.25f);
        }
        Invoke("CarolDerrota", 3f);

    }

    private void CarolDerrota()
    {
        StopCoroutine(VulnerabilityCountdown());
    }

}
