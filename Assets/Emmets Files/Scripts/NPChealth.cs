using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class NPChealth : MonoBehaviour
{



    [SerializeField] private float health;

    


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
