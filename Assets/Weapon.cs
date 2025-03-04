using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //public GameObject SparksVFX;
    //public GameObject SparkPoint;
    [SerializeField] private float _damage;
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("NPC") )
        {
            Debug.Log("Hit");
            //Sparks();
            //SoundManager.Playsound(SoundType.SwordHit);
            Destructable destructable = col.GetComponent<Destructable>();

            if (destructable != null)
            {
                destructable.Health -= _damage;

            }

        }
    }
    //private void Sparks()
    //{
    //    Instantiate(SparksVFX, SparkPoint.transform.position, SparkPoint.transform.rotation);
    //}
}
