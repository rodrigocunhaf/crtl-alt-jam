using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnterCollider : MonoBehaviour
{
    // Start is called before the first frame update DoorConfig _doorConfig;

    [SerializeField] DoorConfig _doorConfig;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            GameObject bag = GameObject.Find("PlayerBag");
            if (bag.transform.childCount > 0)
            {

                KeyConfig key = bag.transform.GetChild(0).gameObject.GetComponent<KeyConfig>();
                if (key != null && _doorConfig.MatchKey() == key.GetKey())
                {
                    _doorConfig.GetAnimator().SetBool("open", true);
                }
            }
        }
    }
}
