using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 90.0f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip healSound;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip deathSound;

    private float maxRotation = 90f; // half range (90° left, 90° right)
    private float startYRotation; // starting angle
    private int currentHealth;
    private Animator animator;
    private AudioSource playerAudio;

    public GameObject projectilePrefab;
    public int maxHealth = 10;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        startYRotation = transform.eulerAngles.y;
        GetComponent<WorldSpaceLabel>().SetLabel(MenuHandler.PlayerName);
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth);
        SetHPText();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the new angle
        float newYRotation = transform.eulerAngles.y + horizontalInput * turnSpeed * Time.deltaTime;

        // Translating into the range -180..180 for the correct Clamp
        float delta = Mathf.DeltaAngle(startYRotation, newYRotation);

        // Limiting the range
        delta = Mathf.Clamp(delta, -maxRotation, maxRotation);

        // Apply the angle
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            startYRotation + delta,
            transform.eulerAngles.z
        );

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameManager.isGameActive)
            {
                animator.SetTrigger("Attack01");
            }
        }
    }

    public void ShootProjectile()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        playerAudio.PlayOneShot(shootSound, 2.0f);
    }

    public void TakeDamage(int amount)
    {
        if (!gameManager.isGameActive)
            return;

        currentHealth -= amount;

        if (currentHealth < 0) currentHealth = 0;

        healthBar.SetHealth(currentHealth, maxHealth);
        SetHPText();
        playerAudio.PlayOneShot(damageSound);

        if (currentHealth == 0)
        {
            animator.SetTrigger("Die");
            playerAudio.PlayOneShot(deathSound);
            gameManager.GameOver();    
        }
    }

    public void Heal(int amount)
    {
        if (!gameManager.isGameActive)
            return;

        currentHealth += amount;

        if (currentHealth > maxHealth) currentHealth = maxHealth;

        healthBar.SetHealth(currentHealth, maxHealth);
        SetHPText();
        playerAudio.PlayOneShot(healSound);
    }

    private void SetHPText()
    {
        healthText.text = $"HP {currentHealth} / {maxHealth}";
    }
}
