using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    //public GameObject SparksVFX;
    //public GameObject SparkPoint;
     public float damage;
    
    public void OnCollisionEnter(Collision col)
    {
       Destroy(col.gameObject);
        PointsManager.instance.AddPoints();
    }


}
