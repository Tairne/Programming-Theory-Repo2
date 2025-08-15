using UnityEngine;

public class GoodGhost : Ghost
{
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private int health = 1;

    void Start()
    {
        HP = health;
        Name = "Good";
        SetLabel();
    }

    // Update is called once per frame
    void Update()
    {
        GoToPlayer(speed);
    }
}
