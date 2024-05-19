using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    [SerializeField] GameObject rootPos;
    void Update()
    {
        transform.position = rootPos.transform.position;
    }
}
