using System;
using UnityEngine;

public class WASDMovement : MonoBehaviour
{
    public float speed = 2;

    private void Awake()
    {
        ServiceLocator.Register(this);
    }

    private void Update()
    {
        var moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        transform.position += transform.rotation * moveInput.normalized * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, 2, transform.position.z);
    }
}