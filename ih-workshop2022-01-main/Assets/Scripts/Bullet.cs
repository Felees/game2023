using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 50f;
    private void Start()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerController>().Health-=damage ;
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }        
    }
}
