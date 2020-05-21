using System;
using TMPro;
using UnityEngine;

public class ChangeInputMethodFromNumber : MonoBehaviour
{
    private WASDMovement _wasdMovement;
    private UpdatePositionFromFirebase _gpsMovement;
    private TextMeshProUGUI _text;

    private void Start()
    {
        _wasdMovement = ServiceLocator.Resolve<WASDMovement>();
        _gpsMovement = ServiceLocator.Resolve<UpdatePositionFromFirebase>();
        _text = GetComponent<TextMeshProUGUI>();
        
        _wasdMovement.enabled = false;
        _gpsMovement.enabled = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1))
        {
            _wasdMovement.enabled = false;
            _gpsMovement.enabled = true;
            _text.text = "GPS";
        }
        else if(Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2))
        {
            _wasdMovement.enabled = true;
            _gpsMovement.enabled = false;
            _text.text = "WASD";
        }
    }
}