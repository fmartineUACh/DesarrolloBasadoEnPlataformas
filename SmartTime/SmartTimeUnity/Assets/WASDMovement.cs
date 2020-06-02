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
        var direction = transform.rotation * moveInput.normalized * speed * Time.deltaTime;
        direction.y = 0;
        

        if (!Physics.Raycast(transform.position, direction, direction.magnitude * 3))
        {
            transform.position += direction;
        }
    }
}