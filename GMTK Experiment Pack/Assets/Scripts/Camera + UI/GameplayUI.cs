using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private float secondsBeforeReloadScene;
    private Vector3 playerPos;
    private Vector3 enemyPos;
    public GameObject restartButton; 
    // Start is called before the first frame update
    void Start()
    {
        restartButton.SetActive(false);
        playerPos = FindObjectOfType<HeroKnight>().gameObject.transform.position;
    }
    private void OnEnable()
    {
        BaseHealth.OnDeath += ShowRestartButton;
    }

    private void OnDisable()
    {
        BaseHealth.OnDeath -= ShowRestartButton;
    }

    public void DetermineDirection(Vector3 direction)
    {
        var x = direction.x;
        var y = direction.y;

        if(x > 0 && x <0.5f)
        {
            if(y > -0.5f && y < 0.5f)
            {
                Debug.Log("Attack from East Direction"); 
            }
        }



    }


    public void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartGame()
    {
        StartCoroutine(RestartGame());
    }
    public IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(secondsBeforeReloadScene);
        SceneManager.LoadSceneAsync(0); 
    }
}
