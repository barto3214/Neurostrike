using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 1.5f;

    void Start()
    {
        Explode();
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                Player_health playerHealth = collider.GetComponent<Player_health>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(2);
                }
            }
        }
    }
}
