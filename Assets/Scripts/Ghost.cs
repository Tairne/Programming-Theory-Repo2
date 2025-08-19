using UnityEngine;

public class Ghost : MonoBehaviour
{
    protected GameObject player;
    protected Player playerScript;
    [SerializeField] protected ParticleSystem explosionEffect;
    [SerializeField] protected AudioClip hurtSound;
    [SerializeField] protected AudioClip deathSound;
    protected int HP { get; set; } = 1;
    protected string Name { get; set; } = "Ghost";

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    protected void GoToPlayer(float speed = 3f)
    {
        transform.LookAt(player.transform);
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        transform.Translate(lookDirection * Time.deltaTime * speed, Space.World);
    }

    protected void SetLabel ()
    {
        string label = $"{Name} HP: {HP}";
        GetComponent<WorldSpaceLabel>().SetLabel(label);
    }

    protected void PlayExplosion()
    {
        if (explosionEffect != null)
        {
            explosionEffect.transform.SetParent(null);
            explosionEffect.Play();
            Destroy(explosionEffect.gameObject, explosionEffect.main.duration);
        }
    }

    public virtual void ReceiveDamage()
    {
        if (HP > 1)
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
}
