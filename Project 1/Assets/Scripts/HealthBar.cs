using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private gameManager gameManager;
    public GameObject Heart1, Heart2, Heart3;

    
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive == true)
        {
            DestroyHearts();
        }
        else if (gameManager.isGameActive == false)
        {
            DestroyAllHearts();
        }
    }

    public void DestroyHearts()
    {
        
        if(gameManager.health==3){
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
        }

        if (gameManager.health==2)
        {
            Heart1.SetActive(false);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
        }
        if (gameManager.health==1)
        {
            Heart1.SetActive(false);
            Heart2.SetActive(false);
            Heart3.SetActive(true);
        }
        if (gameManager.health<=0 )
        {
            Heart1.SetActive(false);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
        }

        
    }

    public void DestroyAllHearts()
    {
        Heart1.SetActive(false);
        Heart2.SetActive(false);
        Heart3.SetActive(false);
    }

}
