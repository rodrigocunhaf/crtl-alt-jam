using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour

{

    [SerializeField] private bool _infiniteRotate = false;
    [SerializeField] private bool disableMove = false;

    private float _ramdomTimeShot = 0;

    private float angleTimer = 0f;
    private float timeToShoot = 0f;
    public float velocidade = 3.0f;
    public float intervaloMudancaDirecao = 2.0f;

    private float tempoDecorrido;
    private Vector3 direcaoAleatoria;

    [SerializeField] private GameObject _bodyPrefab;

    private bool stunned = false;
    [SerializeField] private float stunnedTime = 3f;
    private float currentStunTime = 0;

    private Animator animator;

    void Awake()
    {
        _ramdomTimeShot = Random.Range(1, 3);
    }

    void Start()
    {
        StartCoroutine(FireShot());
        animator = gameObject.transform.Find("Skin").GetComponent<Animator>();
    }


    void Update()
    {
        if (!stunned)
        {

            if (!disableMove)
            {
                if (_infiniteRotate)
                {
                    gameObject.transform.Rotate(0, 60f * Time.deltaTime, 0);
                }
                transform.Translate(direcaoAleatoria * velocidade * Time.deltaTime);



                // Atualiza o tempo decorrido
                tempoDecorrido += Time.deltaTime;

                //transform.Translate(_speed * Time.deltaTime, 0, 0);

                if (tempoDecorrido >= intervaloMudancaDirecao)
                {
                    MudarDirecaoAleatoria();
                    tempoDecorrido = 0;
                }

            }

        }
        else
        {
            if (currentStunTime > 0)
            {
                currentStunTime -= Time.deltaTime;
            }
            else
            {
                SetStunned();

            }
        }

        timeToShoot += Time.deltaTime;
    }


    IEnumerator FireShot()
    {
        while (true)
        {
            if (!stunned)
            {
                if (timeToShoot >= _ramdomTimeShot)
                {
                    //8 maos
                    for (int k = 0; k < _bodyPrefab.transform.childCount; k++)
                    {
                        //1
                        GameObject hand = _bodyPrefab.transform.GetChild(k).gameObject;
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
            else
            {
                yield return null;
            }
        }
    }


    public void SetStunned()
    {
        currentStunTime = stunnedTime;
        stunned = !stunned;
        disableMove = !disableMove;
        if (stunned)
        {

            animator.SetBool("disabled", true);
        }
        else
        {
            animator.SetBool("disabled", false);
        }
    }

    public bool GetStunned()
    {
        return stunned;
    }

    void MudarDirecaoAleatoria()
    {
        // Gera uma nova direção aleatória
        direcaoAleatoria = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        transform.Rotate(0, 90, 0);
    }
}
