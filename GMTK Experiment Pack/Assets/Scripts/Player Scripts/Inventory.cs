using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("these fields are for debugging, do not touch!")]
    [SerializeField] private int ropes; 
    [SerializeField] private int thornyBranches;
    [SerializeField] private int vines;
    [SerializeField] private int brokenBearTrap;

    [Header("the trap prefabs")]
    public GameObject branchSpikeTrap;
    public GameObject ropeTrap;
    public GameObject harpoonTrap;
    public GameObject fixBearTrap;


    //4 prefabs of the trap items 

    private void Start()
    {
        ropes = 0;
        thornyBranches = 0;
        brokenBearTrap = 0;
        vines = 0;
    }

    private void Update()
    {
        // if input && hasbranchspikeTrap 
            //place (instantiate) a bear trap
            if(Input.GetKeyDown(KeyCode.H) && HasBranchSpikeTrap())
            {
            Debug.Log("gimme a Branch spike trap now");
            //spawn branch spike trap here
            Instantiate(branchSpikeTrap, this.gameObject.transform.position, Quaternion.identity);
            thornyBranches--;
            vines--;
            }


        if (Input.GetKeyDown(KeyCode.J) && HasFixedBearTrap())
        {
            Debug.Log("gimme a fixed bear trap now");
            //spawn branch spike trap here
            Instantiate(fixBearTrap, this.gameObject.transform.position, Quaternion.identity);
            thornyBranches--;
            brokenBearTrap--;
        }

        if (Input.GetKeyDown(KeyCode.K) && HasHarpoonTrap())
        {
            Debug.Log("gimme a harpoon trap now");
            //spawn branch spike trap here
            Instantiate(harpoonTrap, this.gameObject.transform.position, Quaternion.identity);
            thornyBranches--;
            ropes--;
            vines--;
        }

        if (Input.GetKeyDown(KeyCode.L) && HasRopeTrap())
        {
            Debug.Log("gimme a rope trap now");
            //spawn branch spike trap here
            Instantiate(ropeTrap, this.gameObject.transform.position, Quaternion.identity);
            ropes--;
            vines--;
        }
    }

    public bool HasBranchSpikeTrap() //refactor: you can use scriptable objects to make "recipes" for the traps
    {
        if (thornyBranches < 1)
            return false;
        if (ropes < 0)
            return false;
        if (vines < 1)
            return false;
        if (brokenBearTrap < 0)
            return false;

        return true;
    }

    public bool HasFixedBearTrap() //refactor: you can use scriptable objects to make "recipes" for the traps
    {
        if (thornyBranches < 1)
            return false;
        if (ropes < 0)
            return false;
        if (vines < 0)
            return false;
        if (brokenBearTrap < 1)
            return false;

        return true;
    }

    public bool HasHarpoonTrap() //refactor: you can use scriptable objects to make "recipes" for the traps
    {
        if (thornyBranches < 1)
            return false;
        if (ropes < 1)
            return false;
        if (vines < 1)
            return false;
        if (brokenBearTrap < 0)
            return false;

        return true;
    }

    public bool HasRopeTrap() //refactor: you can use scriptable objects to make "recipes" for the traps
    {
        if (thornyBranches < 0)
            return false;
        if (ropes < 1)
            return false;
        if (vines < 1)
            return false;
        if (brokenBearTrap < 0)
            return false;

        return true;
    }

    public void Add( ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.VINE:
                vines++;
                break;
            case ItemType.BROKEN_BEAR_TRAP:
                brokenBearTrap++;
                break;
            case ItemType.THORNY_BRANCH:
                thornyBranches++;
                break;
            case ItemType.ROPE:
                ropes++;
                break; 
                default:
                Debug.LogWarning("Brother why is this being called");
                break;        
        }    

    }
}
