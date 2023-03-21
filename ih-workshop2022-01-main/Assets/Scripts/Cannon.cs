using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject _bullet_abstr;
    [SerializeField] private GameObject _bulletSpawner;

    [SerializeField] private float time_between_shots = 3f;
    [SerializeField] private float shot_force;
    private float time_counter = 0f;

    private void Update()
    {
        time_counter += Time.deltaTime;
        if (time_counter >= time_between_shots)
        {
            time_counter = 0;
            Shot();
        }
    }

    private void Shot()
    {
        GameObject _bullet = Instantiate(_bullet_abstr) as GameObject;
        _bullet.transform.position = _bulletSpawner.transform.position;
        _bullet.transform.rotation = _bulletSpawner.transform.rotation;
        _bullet.transform.Translate(1f,0,0);
        _bullet.GetComponent<Rigidbody>().AddRelativeForce(_bullet.transform.right * shot_force, ForceMode.VelocityChange);
    }

}
