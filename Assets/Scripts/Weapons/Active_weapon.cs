using UnityEngine;
using StarterAssets;
using TMPro;

public class Active_weapon : MonoBehaviour
{

    [SerializeField] Gun_SO default_gunSO;

    [SerializeField] Cinemachine.CinemachineVirtualCamera PlayerCamera;
    [SerializeField] GameObject zoom_vignette;
    [SerializeField] TMP_Text ammo_text;
    Animator animator;
    StarterAssetsInputs StarterAssetsInputs;
    FirstPersonController firstPersonController;

    Gun current_weapon;
    float defaultFOV;
    private Gun_SO gunSO;
    float timesinceshoot = 0f;
    float defaultRotationSpeed;

    float current_ammo;
    void Awake()
    {
        StarterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        animator = GetComponent<Animator>();
        defaultFOV = PlayerCamera.m_Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }

    void Start()
    {
        SwitchWeapon(default_gunSO);
        ChangeAmmoAmount(default_gunSO.MagazineSize, default_gunSO);
    }

    // Update is called once per frame
    void Update()
    {
        timesinceshoot += Time.deltaTime;
        if (StarterAssetsInputs.shoot)
        {
            if (timesinceshoot >= gunSO.FireRate && current_ammo > 0)
            {
                current_weapon.shoot(gunSO);
                animator.Play("Shoot", 0, 0f);
                timesinceshoot = 0f;
                ChangeAmmoAmount(-1, gunSO);
            }

            if (!gunSO.isAutomatic)
            {
                StarterAssetsInputs.ShootInput(false);
            }
        }
        handlezoom();
    }

    public void ChangeAmmoAmount(int amount, Gun_SO gunSO)
    {
        current_ammo += amount;
        if (current_ammo > gunSO.MagazineSize)
        {
            current_ammo = gunSO.MagazineSize;
        }
        ammo_text.text = current_ammo.ToString();
    }

    public void Reload(int amount)
    {
        current_ammo += amount;
        if (current_ammo > gunSO.MagazineSize)
        {
            current_ammo = gunSO.MagazineSize;
        }
        ammo_text.text = current_ammo.ToString();
    }

    public void SwitchWeapon(Gun_SO gun_so)
    {
        if (current_weapon != null)
        {
            Destroy(current_weapon.gameObject);
        }
        Gun gun = Instantiate(gun_so.prefab, transform).GetComponent<Gun>();
        current_weapon = gun;
        ChangeAmmoAmount(gun_so.MagazineSize, gun_so);
        this.gunSO = gun_so;
    }
    public void DropWeapon()
    {
        if (current_weapon != null)
        {
            current_weapon.transform.parent = null;
            Rigidbody rb = current_weapon.gameObject.AddComponent<Rigidbody>();
            rb.mass = 1f;
            rb.AddForce(Camera.main.transform.forward * 2f, ForceMode.Impulse);
            current_weapon = null;
            gunSO = null;
        }
    }

    public void handlezoom()
    {
        if (!gunSO.canzoom) { return; }
        if (StarterAssetsInputs.zoom)
        {
            PlayerCamera.m_Lens.FieldOfView = gunSO.zoomFOV;
            zoom_vignette.SetActive(true);
            firstPersonController.ChangeRotationSpeed(gunSO.zoomSpeed);
        }
        else
        {
            PlayerCamera.m_Lens.FieldOfView = defaultFOV;
            zoom_vignette.SetActive(false);
            firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);
        }

    }
}