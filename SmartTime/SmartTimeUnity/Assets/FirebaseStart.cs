using System;
using Firebase;
using UnityEngine;

public class FirebaseStart : MonoBehaviour
{
    private void Start()
    {
        var events = ServiceLocator.Resolve<Events>();
        
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available) {
                events.Raise(new FirebaseInitializedEvent());
            } else {
                Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
            }
        });
    }
}