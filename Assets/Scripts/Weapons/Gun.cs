using UnityEngine;
using Enemy;
using Cinemachine;

public class Gun : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactionsLayer;
    EnemyInput enemyInput;
    public void shoot(Gun_SO gunSO)
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionsLayer, QueryTriggerInteraction.Ignore))
        {
            Instantiate(gunSO.hit_vfx, hit.point, Quaternion.identity); 
            enemyInput = hit.collider.GetComponentInParent<EnemyInput>();
            enemyInput?.TakeDamage(gunSO.Damage);
        }
    }
}
