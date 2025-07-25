using System;
using UnityEngine;

public class RotationModelUI : MyMonoBehaviour
{
    [SerializeField]protected float speed = 30f;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.down, speed * Time.deltaTime);
    }
}
