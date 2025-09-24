using UnityEngine;

[CreateAssetMenu(fileName = "Gun_SO", menuName = "Scriptable Objects/Gun_SO")]
public class Gun_SO : ScriptableObject
{
    public string weaponName;
    public GameObject prefab;
    public int Damage = 1;
    public float FireRate = 0.5f;
    public int MagazineSize = 10;
    public bool isAutomatic = false;
    public GameObject hit_vfx;
    public bool canzoom = false;
    public float zoomFOV = 10f;
    public float zoomSpeed = .3f;
}
