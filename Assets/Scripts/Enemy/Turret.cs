using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject missile_prefab;
    [SerializeField] Transform turretHead;
    [SerializeField] Transform target;
    [SerializeField] Transform shoot_spawn_Point;
    [SerializeField] float fireRate = 2f;
    [SerializeField] int damage = 2;


    Player_health player;


    void Start()
    {
        player = FindFirstObjectByType<Player_health>();
        StartCoroutine(FireRoutine());
    }
    void Update()
    {
        turretHead.LookAt(target.position);
    }
    IEnumerator FireRoutine()
    {
        while (player)
        {
            yield return new WaitForSeconds(fireRate);
            Missile missile = Instantiate(missile_prefab, shoot_spawn_Point.position, turretHead.rotation).GetComponent<Missile>();
            missile.transform.LookAt(target.position);
            missile.Initialization(damage);
        }
    }
}
