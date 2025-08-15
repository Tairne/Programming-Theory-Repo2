using UnityEngine;

public class Ghost : MonoBehaviour
{
    private GameObject player;
    protected int HP { get; set; } = 1;
    protected string Name { get; set; } = "Ghost";

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected void GoToPlayer(float speed = 3f)
    {
        transform.LookAt(player.transform);
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        transform.Translate(lookDirection * Time.deltaTime * speed, Space.World);
    }

    protected void SetLabel ()
    {
        string label = $"{Name} {HP}";
        GetComponent<WorldSpaceLabel>().SetLabel(label);
    }

    public virtual void ReceiveDamage()
    {
        if (HP > 1)
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
