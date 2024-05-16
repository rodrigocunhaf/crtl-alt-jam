using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour

{

    [SerializeField] private bool _infiniteRotate = false;


    private float _ramdomTimeShot = 0;

    private float angleTimer = 0f;
    private float timeToShoot = 0f;
    public float velocidade = 3.0f;
    public float intervaloMudancaDirecao = 2.0f;

    private float tempoDecorrido;
    private Vector3 direcaoAleatoria;

    void Start()
    {

        _ramdomTimeShot = Random.Range(1, 3);
        StartCoroutine(FireShot());
    }


    void Update()
    {
        if (_infiniteRotate)
        {
            gameObject.transform.Rotate(0, 60f * Time.deltaTime, 0);
        }
        transform.Translate(direcaoAleatoria * velocidade * Time.deltaTime);



        // Atualiza o tempo decorrido
        tempoDecorrido += Time.deltaTime;
        timeToShoot += Time.deltaTime;

        //transform.Translate(_speed * Time.deltaTime, 0, 0);

        if (tempoDecorrido >= intervaloMudancaDirecao)
        {
            MudarDirecaoAleatoria();
            tempoDecorrido = 0;
        }
    }


    IEnumerator FireShot()
    {
        while (true)
        {
            if (timeToShoot >= _ramdomTimeShot)
            {
                for (int k = 0; k < gameObject.transform.childCount; k++)
                {
                    Transform hand = gameObject.transform.GetChild(k);
                    for (int i = 0; i < hand.transform.childCount; i++)
                    {

                        Transform gun = hand.transform.GetChild(i);
                        GunConfig gunConfig = gun.GetComponent<GunConfig>();
                        GameObject firedBeam = Instantiate(gunConfig.GetGunBeamPrefab(), gun.transform.position, Quaternion.identity);
                        Beam beamConfig = firedBeam.GetComponent<Beam>();
                        beamConfig.SetBeanConfig(gunConfig, "EnemyBeam");
                        firedBeam.transform.rotation = gun.transform.rotation;
                        firedBeam.transform.parent = gun.transform;
                    };
                }

                _ramdomTimeShot = Random.Range(0, 3);
                timeToShoot = 0;
            }
            yield return new WaitForSeconds(_ramdomTimeShot);
        }
    }

    //INIMIGO DO DNA
    void SetAngleGun(GameObject gun)
    {
        if (angleTimer == 0f)
        {
            angleTimer += 1;
        }
        else if (angleTimer > 0 && angleTimer < 5)
        {
            gun.transform.Rotate(0, 10f, 0);
            angleTimer += 1;

        }
        else if (angleTimer >= 5)
        {
            gun.transform.Rotate(0, -10f, 0);
            angleTimer -= 1;
        }

    }

    void MudarDirecaoAleatoria()
    {
        // Gera uma nova direção aleatória
        direcaoAleatoria = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        transform.Rotate(0, 90, 0);
    }
}
