using UnityEngine;
using UnityEngine.PlayerLoop;

public class Missile : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float lifeTime = 5f;
    [SerializeField] GameObject missile_hit;
    Rigidbody rb;
    private int damage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void Initialization(int damage)
    { 
        this.damage = damage;
    }
    void OnTriggerEnter(Collider other)
    {
        Player_health playerHealth = other.GetComponent<Player_health>();
        playerHealth?.TakeDamage(damage);
        Instantiate(missile_hit, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
