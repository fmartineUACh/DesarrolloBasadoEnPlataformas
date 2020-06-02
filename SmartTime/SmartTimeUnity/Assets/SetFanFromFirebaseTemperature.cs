using System;
using Firebase.Database;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SetFanFromFirebaseTemperature : MonoBehaviour
{
    public float Speed = 10;
    private const string Temperature = "Temperature";
    private double _currentTemperature;
    private FirebaseDatabase _database;

    private void Start()
    {
        var events = ServiceLocator.Resolve<Events>();

        events.Register<FirebaseInitializedEvent>(@event =>
        {
            _database = FirebaseDatabase.DefaultInstance;
            _database.GetReference(Temperature).ValueChanged += OnTemperatureChanged;
        });
    }

    private void Update()
    {
        if (_currentTemperature > 25) 
            transform.RotateAround(transform.position, Vector3.up, Speed * Time.deltaTime);
    }

    private void OnTemperatureChanged(object sender, ValueChangedEventArgs valueChangedEventArgs)
    {
        var currentValue = valueChangedEventArgs.Snapshot.Value;
        if(currentValue is long intValue)
            _currentTemperature = intValue;
        else 
            _currentTemperature = (double) currentValue;
    }

    private void OnDestroy()
    {
        _database.GetReference(Temperature).ValueChanged -= OnTemperatureChanged;
    }
}