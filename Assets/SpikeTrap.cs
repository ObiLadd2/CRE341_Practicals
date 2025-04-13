using Unity.VisualScripting;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float _damage;
   [SerializeField] private int remaining = 10;
    
    private void Update()
    {
        if (remaining <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            Debug.Log("Hit Something");
            if (other.gameObject.CompareTag("NPC"))
            {
                Debug.Log("Enemy Hit");

                remaining -= 1;
                Destructable destructable = other.GetComponent<Destructable>();

                if (destructable != null)
                {
                    destructable.Health -= _damage;

                }
            }
        }


    }
}
