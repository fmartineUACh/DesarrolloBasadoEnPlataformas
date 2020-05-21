using System;
using System.Linq;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Light[] lights;
    public BoxCollider[] boxColliders;

    private void Awake()
    {
        lights = gameObject.GetComponentsInChildren<Light>();
        boxColliders = gameObject.GetComponentsInChildren<BoxCollider>();
    }

    public bool IsPointInsideRoom(Vector3 point)
    {
        return boxColliders.Any(boxCollider => boxCollider.bounds.Contains(point));
    }

    public void TurnOffLights()
    {
        foreach (var pointLight in lights) 
            pointLight.enabled = false;
    }
    
    public void TurnOnLights()
    {
        foreach (var pointLight in lights) 
            pointLight.enabled = true;
    }
}