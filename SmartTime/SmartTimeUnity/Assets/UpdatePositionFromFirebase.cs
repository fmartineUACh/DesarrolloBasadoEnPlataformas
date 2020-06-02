using System;
using Firebase;
using Firebase.Database;
using UnityEngine;

public class UpdatePositionFromFirebase : MonoBehaviour
{
    private FirebaseApp _app;
    private FirebaseDatabase _database;
    private Events _events;
    private Vector3 _startingPosition;
    private double _startingLatitude = double.NaN;
    private double _startingLongitude = double.NaN;
    private Vector3 _deltaVector;
    private const string Latitude = "Latitude";
    private const string Longitude = "Longitude";

    private void Awake()
    {
        ServiceLocator.Register(this);
    }

    private void Start()
    {
        _startingPosition = transform.position;
        _events = ServiceLocator.Resolve<Events>();

        _events.Register<FirebaseInitializedEvent>(@event =>
        {
            _database = FirebaseDatabase.DefaultInstance;
            _database.GetReference(Latitude).ValueChanged += OnLatitudeChanged;
            _database.GetReference(Longitude).ValueChanged += OnLongitudeChanged;
        });
    }

    private void Update()
    {
        var newPosition = _startingPosition + _deltaVector;
        transform.position = newPosition;
    }

    private void OnLatitudeChanged(object sender, ValueChangedEventArgs args)
    {
        RaisePositionChangedEvent(args, Latitude);
    }

    private void OnLongitudeChanged(object sender, ValueChangedEventArgs args)
    {
        RaisePositionChangedEvent(args, Longitude);
    }

    private void OnDestroy()
    {
        if (_database != null)
        {
            _database.GetReference(Latitude).ValueChanged -= OnLatitudeChanged;
            _database.GetReference(Longitude).ValueChanged -= OnLongitudeChanged;
        }
    }

    private void RaisePositionChangedEvent(ValueChangedEventArgs args, string nameOfValueThatChanged)
    {
        var value = (double) args.Snapshot.Value;

        if (nameOfValueThatChanged == Latitude && double.IsNaN(_startingLatitude))
        {
            _startingLatitude = value;
            return; 
        }

        if (nameOfValueThatChanged == Longitude && double.IsNaN(_startingLongitude))
        {
            _startingLongitude = value;
            return;
        }
        
        _deltaVector = Vector3.zero;

        if (nameOfValueThatChanged == Latitude)
        {
            _deltaVector.z = (float) (value - _startingLatitude);
        }
        else
        {
            _deltaVector.x = (float) (value - _startingLongitude);
        }

        _deltaVector *= 100000;
    }
}