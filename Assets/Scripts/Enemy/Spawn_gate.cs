using System.Collections;
using UnityEngine;

public class Spawn_gate : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawn_timer = 5f;
    [SerializeField] Transform spawn_point;
    Game_manager game_Manager;
    Player_health playerHealth;
    private int gate_terminate = 0;


    void Start()
    {
        playerHealth = FindFirstObjectByType<Player_health>();
        StartCoroutine(SpawnRoutine());
        game_Manager = FindFirstObjectByType<Game_manager>();
        StartCoroutine(delayedStart(0.1f));

    }
    IEnumerator delayedStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        game_Manager.adjustEnemiesLeft(-1);  
    }
    IEnumerator SpawnRoutine()
    {
        while (playerHealth != null)
        {
            Instantiate(enemyPrefab, spawn_point.position, transform.rotation);
            yield return new WaitForSeconds(spawn_timer);
        }
        
    }
}
