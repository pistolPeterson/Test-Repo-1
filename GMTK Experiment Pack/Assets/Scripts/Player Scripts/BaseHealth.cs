using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class BaseHealth : MonoBehaviour
{
    [SerializeField] protected int health;
    public bool isAlive = true;
    public static event Action OnDeath;

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
        if (!isAlive) return;

        health -= dmg;
        
        if (health <= 0 )
        {
            health = 0;
            OnDeath?.Invoke(); 
            isAlive = false;
                   //show death animation, stop player from moving, show stats with button to restart            
        }
    }

    public void GetEnemyPositionAndSendToUI(Vector3 enemyPos)
    {
        var playerPos = transform.position;
        Debug.Log(Vector3.Angle(playerPos.normalized, enemyPos.normalized));

        FindObjectOfType<GameplayUI>().DetermineDirection(enemyPos - playerPos);
    }

    public int GetHealth()
    {
        return health;
    }
}
