using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interactive : MonoBehaviour
{
    [SerializeField] private Camera _fpsCamera;
    private Ray _ray;
    private RaycastHit _hit;

    [SerializeField] private float _maxDistanceRay;

    private void Update()
    {
        Ray();
        DrawRay();
        Intetact();
    }

    private void Ray()
    {
        _ray = _fpsCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }
    private void DrawRay()
    {
        if(Physics.Raycast(_ray,out _hit, _maxDistanceRay))
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.blue);
        }
        if(_hit.transform == null)
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.red);
        }
    }
    private void Intetact()
    {
        if(_hit.transform != null && _hit.transform.GetComponent<Door>())
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green);
            if (Input.GetKeyDown(KeyCode.E))
            {
                _hit.transform.GetComponent<Door>().Open();
            }
        }
    }
}
