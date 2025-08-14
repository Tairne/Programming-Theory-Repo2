using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] private float speed = 45f;
    private float topBound = 30;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);

        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ghost"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
