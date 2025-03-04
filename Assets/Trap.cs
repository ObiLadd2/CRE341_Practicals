using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(enemy.player.position, enemy.ai.transform.position);
        if (distance <= catchDistance)
        {
            Debug.Log("Player is caught! Triggering Game Over!");
            enemy.alivePlayer.gameObject.SetActive(false);
            enemy.deathSchene();
            // aiAnim.ResetTrigger("walk");
            //  aiAnim.ResetTrigger("idle");
            //  aiAnim.ResetTrigger("sprint");
            //  aiAnim.SetTrigger("jumpscare");

        }
    }
}
