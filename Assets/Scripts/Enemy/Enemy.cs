using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyInput : MonoBehaviour
    {
        FirstPersonController player;
        NavMeshAgent agent;
        [SerializeField] float health = 5f;
        [SerializeField] GameObject robot_explosion;
        [SerializeField] bool is_this_gate = false;

        Game_manager game_manager;

        // This method is called when the enemy takes damage
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                selfDestruct();
            }

        }
        // Awake is called when the script instance is being loaded
        void Awake()
        {
            if (is_this_gate == false)
            {
                agent = GetComponent<NavMeshAgent>();
                if (agent == null)
                {
                    Debug.LogError("NavMeshAgent component is missing from this GameObject.(nie ma go)");
                }
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            player = FindAnyObjectByType<FirstPersonController>();
            game_manager = FindFirstObjectByType<Game_manager>();
            if (is_this_gate == false)
            {
                game_manager.adjustEnemiesLeft(1);
            }
           
        }

        // Update is called once per frame
        void Update()
        {
            if (!is_this_gate)
            {
                agent.SetDestination(player.transform.position);
            }

        }

        
        public void selfDestruct()
        {
            Instantiate(robot_explosion, transform.position, Quaternion.identity);
            if (is_this_gate == false)
            {
                game_manager.adjustEnemiesLeft(-1);
            }
            Destroy(gameObject);
        }

        void OnTriggerEnter(Collider other)
        {
            if (is_this_gate == false)
            {
                if (other.CompareTag("Player"))
                {
                    selfDestruct();
                }
            }

        }
    }
}