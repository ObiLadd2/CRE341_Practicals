using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class NPCmanager : MonoBehaviour
{
    [SerializeField] private int npcAmount;
    [SerializeField] private int npcMaxAmount;
    [SerializeField] public  GameObject NPCprefab;
   
    [SerializeField] private float timer;
    [SerializeField] private float coolDown;
    [SerializeField] private bool canSpawn;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Spawn();
      // Debug.Log(npcAmount);
      if (canSpawn == true) 
        {
            npcAmount += 1;
        }
    }
    public void Spawn()
    {
        if (npcMaxAmount > npcAmount) //checks the amount of spawned objects compare tha max amount.

            if (timer >= coolDown)
            {
                timer = coolDown;
            }
        if (timer == coolDown)
        {
            canSpawn = true;
        }

        if (canSpawn == true)
        {
            Instantiate(NPCprefab, transform.position, transform.rotation);
            
            timer = 0;
        }

        if (timer == 0) //resets the tiemr for the spawner
        {
            canSpawn = false;
        }

        if(npcAmount == npcMaxAmount)
        {
            canSpawn = false ;
        }

        npcAmount += 1;
       
    }

}
