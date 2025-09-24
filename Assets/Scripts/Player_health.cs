using Cinemachine;
using Microsoft.Unity.VisualStudio.Editor;
using StarterAssets;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Player_health : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] int startingHealth = 5;
    [SerializeField] CinemachineVirtualCamera deathcamera;
    [SerializeField] UnityEngine.UI.Image[] shieldBars;
    [SerializeField] GameObject game_over_container;
    [SerializeField] GameObject hp;
    [SerializeField] GameObject ammo;
    [SerializeField] GameObject how_many_left_text;
    int currentHealth;


    void Awake()
    {
        currentHealth = startingHealth;
        adjustShieldUI();

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        adjustShieldUI();
        if (currentHealth <= 0)
        {
            deathcamera.Priority = 11;
            Die();
        }
    }

    
    public void Die()
    {
        StarterAssetsInputs input = FindFirstObjectByType<StarterAssetsInputs>();
        input.SetCursorState(false);
        game_over_container.SetActive(true);
        hp.SetActive(false);
        ammo.SetActive(false);
        how_many_left_text.SetActive(false);
        Destroy(gameObject);
    }

    public void win(GameObject you_win_text)
    {
        StarterAssetsInputs input = FindFirstObjectByType<StarterAssetsInputs>();
        input.SetCursorState(false);
        you_win_text.SetActive(true);
        hp.SetActive(false);
        ammo.SetActive(false);
        how_many_left_text.SetActive(false);
        Destroy(gameObject);
        deathcamera.Priority = 11;
    }
    
    void adjustShieldUI()
    {
        for (int i = 0; i < shieldBars.Length; i++)
        {
            if (i < currentHealth)
            {
                shieldBars[i].enabled = true;
            }
            else
            {
                shieldBars[i].enabled = false;
            }
        }
    }
}
