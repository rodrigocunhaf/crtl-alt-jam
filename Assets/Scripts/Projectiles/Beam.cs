using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    private float speed;
    private float _secToDestroy = 3f;
    private float timer = 0;

    //[SerializeField] private bool bouncingEffect = false;

    //[SerializeField] private float zigZag = 10f;
    private bool bouncingTop = false;
    private float bouncingTime = 5f;

    private bool changeDirection = false;
    private float zigZagTime = 0f;
    //[SerializeField] float sin = 0;
    private Renderer _rend;


    void Awake()
    {
        _rend = GetComponent<Renderer>();
    }
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


        // if (bouncingEffect)
        // {
        //     BouncingEffect();
        // }
        transform.Translate(speed * Time.deltaTime, 0, 0);
        /*
                if (!changeDirection)
                {
                    transform.Translate(speed * Time.deltaTime, 0, sin * Time.deltaTime);
                }
                if (changeDirection)
                {
                    transform.Translate(speed * Time.deltaTime, 0, -sin * Time.deltaTime);

                }



                if (timer > 1 && !changeDirection)
                {
                    changeDirection = !changeDirection;
                    timer = 0;
                }
                else if (timer > 2 && changeDirection)
                {
                    changeDirection = !changeDirection;
                    timer = 0;
                }

                zigZagTime += Time.deltaTime;
                */
        timer += Time.deltaTime;

        if (timer >= _secToDestroy)
        {
            Destroy(gameObject);
        }

    }
    void BouncingEffect()
    {
        if (bouncingTime > 0.25f && !bouncingTop)
        {
            transform.Rotate(0, 200f * Time.deltaTime, 0);
        }
        bouncingTime += Time.deltaTime;
    }

    public void SetBeanConfig(GunConfig gunConfig, string beanName)
    {
        speed = gunConfig.GetProjectileVelocity(); ;
        _rend.material.color = gunConfig.GetProjectileColor();
        transform.name = beanName;
        transform.localScale = new Vector3(gunConfig.GetProjectileScale(), gunConfig.GetProjectileScale(), gunConfig.GetProjectileScale());
    }

}
