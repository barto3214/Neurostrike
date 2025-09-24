using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Active_weapon activeWeapon = other.GetComponentInChildren<Active_weapon>();
            OnPickup(activeWeapon);
            Destroy(this.gameObject);
        }
    }

    protected virtual void OnPickup(Active_weapon activeWeapon)
    {
        // Default pickup behavior (can be overridden)
    }
}
