using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 90.0f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    private float maxRotation = 90f; // half range (90° left, 90° right)
    private float startYRotation; // starting angle
    private int currentHealth;

    public GameObject projectilePrefab;
    public int maxHealth = 10;

    void Start()
    {
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
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;

        healthBar.SetHealth(currentHealth, maxHealth);

        SetHPText();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        healthBar.SetHealth(currentHealth, maxHealth);

        SetHPText();
    }

    private void SetHPText()
    {
        healthText.text = $"HP {currentHealth} / {maxHealth}";
    }
}
