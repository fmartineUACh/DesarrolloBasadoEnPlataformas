using System;
using UnityEngine;

public class TurnOffLightsDependingOnPositionService : MonoBehaviour
{
    private Room[] _rooms;

    private void Awake()
    {
        _rooms = FindObjectsOfType<Room>();
    }
    
    private void Update()
    {
        foreach (var room in _rooms)
        {
            if(room.IsPointInsideRoom(transform.position)) 
                room.TurnOnLights();
            else 
                room.TurnOffLights();
        }
    }
}