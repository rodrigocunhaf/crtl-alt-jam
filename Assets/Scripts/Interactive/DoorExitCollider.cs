using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExitCollider : MonoBehaviour
{

    [SerializeField] DoorConfig _doorConfig;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            GameObject bag = GameObject.Find("PlayerBag");
            if (bag.transform.childCount > 0)
            {

                Destroy(bag.transform.GetChild(0).gameObject);
            }
            _doorConfig.GetAnimator().SetBool("open", false);
        }
    }
}
