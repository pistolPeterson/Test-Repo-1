using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] protected int health; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void TakeDamage(int dmg)
    {
        health -= dmg; 
        if (health <= 0)
        {
            health = 0;
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
