using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject playerToFollow; 
    // Start is called before the first frame update
    void Start()
    {
        playerToFollow = FindObjectOfType<HeroKnight>().gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player = playerToFollow.transform.position; 
        transform.position = new Vector3(player.x, player.y, this.gameObject.transform.position.z);
        
    }
}
