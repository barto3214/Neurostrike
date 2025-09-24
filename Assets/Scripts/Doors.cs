using UnityEngine;

public class Doors : MonoBehaviour
{
    Animator animator;
    Game_manager game_Manager;
    
    void Awake()
    { 
        game_Manager = FindFirstObjectByType<Game_manager>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (game_Manager.enemies_to_kill >= 3) {
            animator.Play("Opening_doors",0,0f);
        }
    }
}
