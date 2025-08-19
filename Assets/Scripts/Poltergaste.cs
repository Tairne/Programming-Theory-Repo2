using UnityEngine;

public class Poltergaste : Ghost
{
    [SerializeField] private float speed = 2f;
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

            if (shield == 0)
            {
                Transform shieldTransform = transform.Find("Shield");
                if (shieldTransform != null)
                {
                    Destroy(shieldTransform.gameObject);
                }
            }
        }
        else if (HP > 1)
        {
            HP--;
            SetLabel();
            AudioManager.Instance.PlaySFX(hurtSound);
        }
        else
        {
            PlayExplosion();
            AudioManager.Instance.PlaySFX(deathSound);
            Destroy(gameObject);   
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
