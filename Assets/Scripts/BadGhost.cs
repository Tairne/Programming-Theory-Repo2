using UnityEngine;

public class BadGhost : Ghost
{
    [SerializeField] private int health = 3;
    [SerializeField] private float speed = 2f;

    void Start()
    {
        HP = health;
        Name = "Bad";
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
            playerScript.TakeDamage(2);
            Destroy(gameObject);
        }
    }
}
