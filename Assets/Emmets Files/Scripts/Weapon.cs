using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject SparksVFX;
    public GameObject SparkPoint;
    public float _damage;


    public void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            Debug.Log("Hit Something");
            if (other.gameObject.CompareTag("NPC"))
            {
                Debug.Log("Enemy Hit");
                

                Destructable destructable = other.GetComponent<Destructable>();

                if (destructable != null)
                {
                    destructable.Health -= _damage;

                }
            }
        }


    }

}
