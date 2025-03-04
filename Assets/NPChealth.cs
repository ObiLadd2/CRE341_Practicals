using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class NPChealth : MonoBehaviour
{

    

    public float health = 100;

    


    public float Health
    {
        set
        {
            health = value;

            if (health <= 0)
            {
                breakObject();
            }
        }
        get
        {
            return health;
        }
    }
   public void breakObject()
    {
        Destroy(gameObject);
    }
}
