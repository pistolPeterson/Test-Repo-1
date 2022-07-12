using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), FindObjectOfType<HeroKnight>().GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") )
        {
            Debug.Log("truting");
            collision.gameObject.transform.position = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player?");
            
        }
    }
}
