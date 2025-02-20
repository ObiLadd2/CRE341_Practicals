using System;

using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class SpawnRay : MonoBehaviour
{

    public LayerMask wall;
    public LayerMask Ground;
    public GameObject Spawnpoint;
    //float maxDistance = 20f;
    private float spawnAmount;
    private float MaxSpawnAmount= 10f;

    public float coolDown = 0.5f;
    public  float timer;
    private bool canSpawn = false;
   
     RaycastHit hit ;   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
private void Update()
    {
        timer += Time.deltaTime;
       
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, wall))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            Debug.Log("hits walls");
            timer = 0;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, Ground))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            Debug.Log("hits Ground");


            Spawn();

        }
       

    }



    private void Spawn()
    {
        if (MaxSpawnAmount > spawnAmount) 
            
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
                Instantiate(Spawnpoint, hit.point, transform.rotation);
            spawnAmount += 1;
                timer = 0;
            }

        if (timer == 0)
        {
            canSpawn = false;
        }
        
       
            
            
            Debug.Log(spawnAmount);
    }


    




       
        
    
}
