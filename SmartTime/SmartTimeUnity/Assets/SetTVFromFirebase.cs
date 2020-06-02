using System;
using Firebase.Database;
using UnityEngine;

public class SetTVFromFirebase : MonoBehaviour
{
    private const string TVStatus = "TVStatus";
    private FirebaseDatabase _database;

    private void Start()
    {
        var events = ServiceLocator.Resolve<Events>();

        events.Register<FirebaseInitializedEvent>(@event =>
        {
            _database = FirebaseDatabase.DefaultInstance;
            _database.GetReference(TVStatus).ValueChanged += OnTVStatusChanged;
        });
    }

    private void OnTVStatusChanged(object sender, ValueChangedEventArgs valueChangedEventArgs)
    {
        if (this == null)
            return;
        
        var status = (string) valueChangedEventArgs.Snapshot.Value;
        GetComponent<MeshRenderer>().enabled = status != "Off";
    }

    private void OnDestroy()
    {
        _database.GetReference(TVStatus).ValueChanged -= OnTVStatusChanged;
    }
}