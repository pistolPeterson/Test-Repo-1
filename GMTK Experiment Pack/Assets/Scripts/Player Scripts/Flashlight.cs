using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    [SerializeField] [Range(1.01f, 10.01f)]private float flashlightDrainRate;
    [SerializeField] Text flashlightText; 
    private bool isOn;
    private float flashlightPower = 100;
    private float time;
    private float flashLightRechargeRate;
    private DayNightStateMachine dnsm; 
    private void Start()
    {
        flashlight.SetActive(false);
        isOn = false;
        time = 0;
        flashlightPower = 100;
        flashLightRechargeRate = flashlightDrainRate / 2;
        dnsm = FindObjectOfType<DayNightStateMachine>();
    }

    private void Update()
    {
        time += Time.deltaTime;

        


        if (time > 0.5f )
        {
            Debug.Log("inside timer? ");
            if (dnsm.GetDayNightState() == DayNightEnum.DAY)
            {
                //Debug.Log("its day time my dudes " + flashlightPower);
                flashlightPower += 1.75f;
                if (flashlightPower >= 100)
                    flashlightPower = 100;
            }

          

            if (flashlightPower > 0 && isOn)
            {
                Debug.Log("We stay draining");
                flashlightPower -= (1.0f * flashlightDrainRate);
            }
           

            time = 0; 
        }
        flashlightText.text = "FlashLight Power: " + flashlightPower  + "% ";

        if (flashlightPower <= 0)
        {
            flashlight.SetActive(false);
            flashlightText.text = "FlashLight Power: 0% ";
        }
        flashlightText.text = "FlashLight Power: " + flashlightPower + "% ";

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))
        {          
            ToggleFlashlight();
        }
    }

    public void ToggleFlashlight()
    {
        isOn = !isOn;
        flashlight.SetActive(isOn);
    }

}
