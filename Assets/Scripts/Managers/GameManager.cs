using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _energy;
    [SerializeField] private int _keys;

    [SerializeField] bool _vunerability = true;
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

    void Start()
    {
        StartCoroutine(VulnerabilityCountdown());
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
    }

    public bool GetVulnerability()
    {
        return _vunerability;
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

        for (; ; )
        {
            if (!_vunerability)
            {
                print("invulneravel");
                for (int i = 0; i < 6; i++)
                {
                    if (i % 2 == 0)
                    {
                        rend.material = _transparenceMateiral;
                        isTransparent = true;
                        yield return new WaitForSeconds(1f);
                    }
                    else
                    {
                        rend.material = _defaultMaterial;
                        isTransparent = false;
                        yield return new WaitForSeconds(1f);

                    }
                    if (i == 6 - 1)
                    {
                        _vunerability = true;
                    }

                }



            }
            yield return new WaitForSeconds(0.1f);

        }

    }


}
