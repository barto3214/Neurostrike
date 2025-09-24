using UnityEngine;

public class Ammo_pickup : Pickup
{
    [SerializeField] private int ammoAmount = 100;
    protected virtual void OnTriggerEnter(Collider other)
    {
        Active_weapon activeWeapon = other.GetComponentInChildren<Active_weapon>();
        if (other.CompareTag("Player"))
        {
            if (activeWeapon != null)
            {
                activeWeapon.Reload(ammoAmount);
                Destroy(this.gameObject);
            }
        }   

    }
}
