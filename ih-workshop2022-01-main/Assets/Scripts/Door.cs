using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private bool _isOpened;
    public void Open()
    {
        _animator.SetBool("isOpened", _isOpened);
        _isOpened = !_isOpened;
    }
}
