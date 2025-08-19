using UnityEngine;

public class GoodGhost : Ghost
{
    [SerializeField] private float speed = 4.0f;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript.Heal(1);
            Destroy(gameObject);
        }
    }
}
