using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Destructable : MonoBehaviour
{
    //public  GameObject broken;
   
    public float health = 100;
    [SerializeField]  private int pointsGainOnDeath;

    //private Transform brokenObject;
    public void Start()
    {
        
    }

    public float Health
    {
        set
        {
            health = value;

            if(health <= 0)
            {
                breakObject();
            }
        }
        get
        {
            return health;
        }
    }
    // When the destuctable object looses all its health the object is detroyed and a broken version of the object is instaciated.
  public void breakObject()
    {  
        PointsManager.instance.AddPoints(pointsGainOnDeath);
        GameStateManager.instance.npcAmount -= 1;
        Destroy(gameObject);
      
       
    }
}
