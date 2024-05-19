using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BtnDoor : MonoBehaviour
{
    [SerializeField] GameObject _doorPrefab;
    private DoorConfig _doorConfig;
    [SerializeField] int countdown;
    [SerializeField] GameObject _timerFab;

    TextMeshProUGUI _txt;

    private bool onRadius = false;

    private float timer = 0;
    private bool started = false;



    void Start()
    {
        _doorConfig = _doorPrefab.GetComponent<DoorConfig>();
        if (_timerFab)
        {

            _txt = _timerFab.GetComponent<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        if (onRadius && Input.GetKeyDown(KeyCode.F))
        {
            started = true;
        }

        if (started)
        {
            timer += Time.deltaTime;
            if (_txt)
            {
                _txt.text = $"{(int)Mathf.Abs(countdown - timer)}";
            }
        }
        else
        {
            if (_txt != null)
            {

                _txt.text = $"";
            }

        }

        if (timer >= countdown)
        {
            started = false;
            _doorConfig.GetAnimator().SetBool("open", true);
        }



    }
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            onRadius = true;
        }
    }

    void OnCollisionExit()
    {
        onRadius = false;
    }

}
