using DG.Tweening;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnTrap : MonoBehaviour
{
    public LayerMask wall;
    public LayerMask Ground;
    public GameObject SpikesPrefab;
    public GameObject spikePlaceLocation;

    //PointsManager pm;

    //[SerializeField] private int PointCost = 100;
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
            spikePlaceLocation.transform.Rotate(spikePlaceLocation.transform.rotation.x, spikePlaceLocation.transform.rotation.y,+45f);
        }
        //if(pm.score <= PointCost)
        //{
        //    ExceedCost = true;
        //}
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity,wall))
        {
            placeableSpot = false;
          
            Debug.Log("Hit");
           // spikePlaceLocation.SetActive(false);
           
        } else if (Physics.Raycast(ray, out hit, Mathf.Infinity, Ground)){

            placeableSpot = true;
           // spikePlaceLocation.SetActive(true);
            newPosition = hit.point;
            spikePlaceLocation.transform.position = newPosition;
        }
        if (canPlace == true && placeableSpot == true && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Can Place");
           Instantiate(SpikesPrefab, spikePlaceLocation.transform.position, spikePlaceLocation.transform.rotation);
        }
    }

    
    public void SpikePlace()
    {
        canPlace = true;
        spikePlaceLocation.SetActive(true);
    }
}
