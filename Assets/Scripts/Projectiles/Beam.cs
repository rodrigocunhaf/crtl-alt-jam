using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    [SerializeField] private float speed;
    private float _secToDestroy = 1f;
    private float timer = 0;


    void Start()
    {
        GameObject projectilesContainer = GameObject.Find("Projectiles");
        if (projectilesContainer != null)
        {
            transform.parent = projectilesContainer.transform;
        }
        else
        {
            transform.parent = new GameObject("Projectiles").transform;
        }



    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        timer += Time.deltaTime;

        if (timer >= _secToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
