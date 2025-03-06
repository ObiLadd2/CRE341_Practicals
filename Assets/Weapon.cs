using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //public GameObject SparksVFX;
    //public GameObject SparkPoint;
     public float damage;
    
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("broke"))
        {
            Debug.Log(col.name );
           
            Destructable destructable = col.GetComponent<Destructable>();

            if (destructable != null)
            {
                destructable.health -= damage;

            }

        }
    }
    

}
