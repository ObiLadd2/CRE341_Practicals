using RootMotion.Demos;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public int Damage;
    public HealthBar healthbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Application.Quit();
            Debug.Log("GameOver");
        }
    }
   
    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        TakeDamage(Damage);
        GameStateManager.instance.npcAmount -= 1; // decreased the npc amount value when they reach the centre.
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
    }
}
