using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        BaseHealth.OnDeath += DeathAnimation; 
    }

    private void OnDisable()
    {
        BaseHealth.OnDeath -= DeathAnimation;
    }

    private void DeathAnimation()
    {
        animator.SetTrigger("Death");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
