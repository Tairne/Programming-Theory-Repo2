using UnityEngine;

public class Ghost : MonoBehaviour
{
    private GameObject player;

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

    protected void SetLabel (string label = "Ghost")
    {
        GetComponent<WorldSpaceLabel>().SetLabel(label);
    }
}
