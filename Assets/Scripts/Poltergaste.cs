using UnityEngine;

public class Poltergaste : Ghost
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int health = 3;
    [SerializeField] private int shield = 1;

    void Start()
    {
        HP = health;
        Name = "Poltergaste";
        SetLabel();
    }

    void Update()
    {
        GoToPlayer(speed);
    }

    public override void ReceiveDamage()
    {
        if (shield > 0)
        {
            shield--;
        }
        else if (HP > 1)
        {
            HP--;
            SetLabel();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
