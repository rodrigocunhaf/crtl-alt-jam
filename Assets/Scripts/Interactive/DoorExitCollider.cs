using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            else
            {

                SceneManager.LoadScene("Enemy");
            }
            _doorConfig.GetAnimator().SetBool("open", false);
        }

    }
}
