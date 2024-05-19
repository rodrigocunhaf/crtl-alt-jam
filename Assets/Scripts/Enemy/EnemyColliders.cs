using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliders : MonoBehaviour
{
    EnemyMoviment enemyMoviment;

    void Start()
    {
        enemyMoviment = GetComponent<EnemyMoviment>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            enemyMoviment.MudarDirecaoAleatoria();
        }
    }
}
