using UnityEngine;

public class Root : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.Register(new Events());
    }
}