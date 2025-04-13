using DG.Tweening;
using NUnit.Framework;
using RootMotion.FinalIK;
using System.Collections.Generic;
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

    #region Variables    
    [SerializeField] TrapSelector trapSelector;

    PointsManager PM;


    public LayerMask wall;
    public LayerMask Ground;


    HeaderAttribute Traps;
    public GameObject SpinBladeLocation;
    public GameObject spikeLocation;



    public GameObject TrapSpawnLocation;
    public List<GameObject> TrapType = new List<GameObject>();
    public List<GameObject> TrapTypeLocation = new List<GameObject>();
    private int DetermineTrapType;

     private int PointCost;
    Vector3 newPosition;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private bool canPlace;
   private bool placeableSpot;
   
    RaycastHit hit;
    #endregion 
    void Start()
    {
        newPosition = transform.position;
        PM = GetComponent<PointsManager>();
    }

    // Update is called once per frame
    void Update()
    {
       PM.TrapCostUI.text = PointCost.ToString() + "Cost";
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
                TrapTypeLocation[DetermineTrapType].SetActive(true);

            placeableSpot = true;
            
            newPosition = hit.point;
            TrapSpawnLocation.transform.position = newPosition;
           
           }
          
        
           if (canPlace == true && placeableSpot == true && Input.GetMouseButtonDown(0))
           {
            Debug.Log("Can Place");
                
                Instantiate(TrapType[DetermineTrapType], TrapSpawnLocation.transform.position, TrapSpawnLocation.transform.rotation);
            PointsManager.instance.DeletePoints(PointCost);
                trapSelector = TrapSelector.NoTrap;
                
                TrapTypeLocation[DetermineTrapType].SetActive(false);
            }
        } else{Debug.Log("Cannot place trap"); }
        
            

    }

    
    public void SpikePlace()
    {
        canPlace = true;
        TrapTypeLocation[1].SetActive(false );
        trapSelector = TrapSelector.Spike;
        DetermineTrapType = 0;

        PointCost = 50;
        
    }
    public void SpinBladePlace()
    {
        canPlace = true;
        TrapTypeLocation[0].SetActive(false);
        trapSelector = TrapSelector.SpinBlade;
        DetermineTrapType = 1;
        PointCost = 150;
        

    }
}
