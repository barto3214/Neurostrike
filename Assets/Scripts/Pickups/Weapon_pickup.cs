using UnityEngine;
public class Weapon_pickup : Pickup
{
    [SerializeField] Gun_SO gunSO;

    protected override void OnPickup(Active_weapon activeWeapon)
    {
        activeWeapon.SwitchWeapon(gunSO);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Active_weapon activeWeapon = other.GetComponentInChildren<Active_weapon>();
            activeWeapon.SwitchWeapon(gunSO);
            Destroy(this.gameObject);
        }
    }
}
