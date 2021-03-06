using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonsterSpawner : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private int secondsPerEnemy = 1;
    [SerializeField] private bool isSpawning = false;
    [SerializeField] private int maxPerRound = 5; 

   
    private float time; 

    private int currentAmt = 0;

    private void Start()
    {
        time = 0; 
    }

    private void Update()
    {
        if (!isSpawning || currentAmt > maxPerRound ) return; 

        time += Time.deltaTime;

        if (time > secondsPerEnemy)
        {
           var go= Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], Random.insideUnitCircle.normalized * radius, Quaternion.identity);
            go.transform.parent = transform;
            time =0;
            currentAmt++;
        }
       



    }
    private void ResetRound()
    {
        currentAmt = 0;
        Debug.Log("night Time!"); 
        //extra logic here. 
    }

    private void OnEnable()
    {
       
        DayNight.beginNight += ResetRound;
    }

    private void OnDisable()
    {
        //accomadate for "death". death = disbale 
      
        DayNight.beginNight -= ResetRound;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Color col = new Color(1.5f, 0.6f, 0.5f, 0.33f);
        Gizmos.color = col;
       
        Gizmos.DrawSphere(transform.position, radius);
    }
}
