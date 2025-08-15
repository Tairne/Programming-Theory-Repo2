using UnityEngine;

public class BadGhost : Ghost
{
    [SerializeField] private int health = 3;

    void Start()
    {
        HP = health;
        Name = "Bad";
        SetLabel();
    }

    // Update is called once per frame
    void Update()
    {
        GoToPlayer();
    }
}
