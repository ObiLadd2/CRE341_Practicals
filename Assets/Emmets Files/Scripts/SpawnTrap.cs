using DG.Tweening;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.InputSystem;

public enum TrapSelector
{
    NoTrap,
    Spike,
    SpinBlade
}
public class SpawnTrap : MonoBehaviour
{

    TrapSelector trapSelector;
    private int trapCost;


    public LayerMask wall;
    public LayerMask Ground;
    public GameObject SpikesPrefab;
    public GameObject spinBladePrefab;

    HeaderAttribute Traps;
    public GameObject SpinBladeLocation;
    public GameObject spikeLocation;



    public GameObject TrapSpawnLocation;


   
    [SerializeField] private int PointCost = 100;
    Vector3 newPosition;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   [SerializeField] private bool canPlace;
   [SerializeField]  private bool placeableSpot;
    //[SerializeField] private bool ExceedCost;
    RaycastHit hit;
    void Start()
    {
        newPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
      if(PointsManager.instance.score <= PointCost)
        {
            canPlace = false;
        }
       
        if (trapSelector != TrapSelector.NoTrap) 
        { 

           if (Input.GetKeyDown(KeyCode.E)) 
            {
            TrapSpawnLocation.transform.Rotate(0, +45, 0);
            }
       
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

           if (Physics.Raycast(ray, out hit, Mathf.Infinity,wall))
           {
            placeableSpot = false;
          
            Debug.Log("Hit");
           } else if (Physics.Raycast(ray, out hit, Mathf.Infinity, Ground))
           {

            placeableSpot = true;
            
            newPosition = hit.point;
            TrapSpawnLocation.transform.position = newPosition;
           
           }
        
           if (canPlace == true && placeableSpot == true && Input.GetMouseButtonDown(0))
           {
            Debug.Log("Can Place");
            Instantiate(SpikesPrefab, TrapSpawnLocation.transform.position, TrapSpawnLocation.transform.rotation);
            PointsManager.instance.DeletePoints(PointCost);
                trapSelector = TrapSelector.NoTrap;
           }
        } else{Debug.Log("Cannot place trap"); }
        
            

    }

    
    public void SpikePlace()
    {
        canPlace = true;
        spikeLocation.SetActive(true);
        trapSelector = TrapSelector.Spike;
        
    }
    public void SpinBladePlace()
    {
        canPlace = true;
        trapSelector = TrapSelector.SpinBlade;

    }
}
