using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private float speed = 4f;
    [SerializeField] private LayerMask _muskObjectalces;

    private Vector3 _position;

    private void Awake()
    {
        _position = _target.InverseTransformPoint(this.transform.position);
    }
    private void Update()
    {
        var OldRotation = _target.rotation;
        _target.rotation = Quaternion.Euler(0, 0, 0);
        var CurrentPosition = _target.TransformPoint(_position);
        _target.rotation = OldRotation;

        transform.position = Vector3.Lerp(this.transform.position, CurrentPosition, speed * Time.deltaTime);
        var currentRotation = Quaternion.LookRotation(_target.position - this.transform.position);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, currentRotation, speed * Time.deltaTime);
    }
}