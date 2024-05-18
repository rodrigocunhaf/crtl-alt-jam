using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour

{

    void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);

        }
    }


}
