using UnityEngine;

public class GoodGhost : Ghost
{
    [SerializeField] private float speed = 2.0f;

    void Start()
    {
        SetLabel("Good");
    }

    // Update is called once per frame
    void Update()
    {
        GoToPlayer(speed);
    }
}
