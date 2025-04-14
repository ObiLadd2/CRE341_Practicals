using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Destructable : MonoBehaviour
{
   
   
    public float health = 100;
    [SerializeField]  private int pointsGainOnDeath;

   
   

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
        GameStateManager.instance.curentAmount -= 1;
        Destroy(gameObject);
      
       
    }
}
