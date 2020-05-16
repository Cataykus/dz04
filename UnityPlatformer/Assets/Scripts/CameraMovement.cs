using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothness;

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, _target.position, _smoothness);
    }
}
