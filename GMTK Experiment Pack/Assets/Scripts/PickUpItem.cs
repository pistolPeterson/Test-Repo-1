using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    [SerializeField] private ItemType type;
    [SerializeField] private int amt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Inventory>().Add( type); 
            Destroy(this.gameObject);
        }
    }
}

public enum ItemType
{
    NONE, 
    THORNY_BRANCH, 
    BROKEN_BEAR_TRAP,
    ROPE, 
    VINE
}
