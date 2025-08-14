using UnityEngine;

public class Poltergaste : Ghost
{
    [SerializeField] private float speed = 5f;

    void Start()
    {
        SetLabel("Poltergaste");
    }

    void Update()
    {
        GoToPlayer(speed);
    }
}
