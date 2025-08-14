using UnityEngine;

public class BadGhost : Ghost
{
    void Start()
    {
        SetLabel("Bad");
    }

    // Update is called once per frame
    void Update()
    {
        GoToPlayer();
    }
}
