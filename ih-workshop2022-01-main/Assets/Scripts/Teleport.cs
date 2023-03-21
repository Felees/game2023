using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform _teleportPoint;

    private void OnTriggerStay(Collider collider)
    {
/*        if (collider.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            collider.transform.position = _teleportPoint.transform.position;
        }*/
        collider.transform.position = _teleportPoint.transform.position;
    }
}
