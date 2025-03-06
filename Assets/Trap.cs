using UnityEngine;

public class Trap : MonoBehaviour
{
    public float catchDistance = 0.5f;
    private GameObject player;
    public GameObject enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, enemy.transform.position);
        if (distance <= catchDistance)
        {
            Debug.Log("Player is caught! Triggering Game Over!");
            Destroy(enemy);
            
            // aiAnim.ResetTrigger("walk");
            //  aiAnim.ResetTrigger("idle");
            //  aiAnim.ResetTrigger("sprint");
            //  aiAnim.SetTrigger("jumpscare");

        }
    }
}
