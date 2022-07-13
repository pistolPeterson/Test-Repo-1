using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera cvc;
    private float timer; 
    private void Start()
    {
        cvc = FindObjectOfType<CinemachineVirtualCamera>();
       
        ShakeCamera(1f, 1.5f);
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f; 

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;

    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cbmp = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cbmp.m_AmplitudeGain = 0f;
            }
        }
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cbmp = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); 
        cbmp.m_AmplitudeGain = intensity;
        timer = time;


    }
}
