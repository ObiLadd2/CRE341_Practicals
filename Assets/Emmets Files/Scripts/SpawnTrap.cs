using DG.Tweening;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnTrap : MonoBehaviour
{
    public LayerMask wall;
    public LayerMask Ground;
    public GameObject SpikesPrefab;
    public GameObject spikeLocation;
    public GameObject spikeSpawnLocation;

   
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
      
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            spikeLocation.transform.Rotate(0, +45, 0);
        }
    
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity,wall))
        {
            placeableSpot = false;
          
            Debug.Log("Hit");
            
           
        } else if (Physics.Raycast(ray, out hit, Mathf.Infinity, Ground)){

            placeableSpot = true;
            
            newPosition = hit.point;
            spikeLocation.transform.position = newPosition;
           
        }
        if(PointsManager.instance.score <= 0)
        {
            canPlace = false;
        }
        if (canPlace == true && placeableSpot == true && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Can Place");
           Instantiate(SpikesPrefab, spikeSpawnLocation.transform.position, spikeSpawnLocation.transform.rotation);
            PointsManager.instance.DeletePoints(PointCost);
        }
    }

    
    public void SpikePlace()
    {
        canPlace = true;
        spikeLocation.SetActive(true);
        
    }
}
