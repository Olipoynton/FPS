using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    


    public float health;
    public float maxHealth;
    public Image healthBar;
    public int Respawn;
    public GameObject player;
    public GameObject spawnpoint;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100f;
        health = maxHealth;
       
     
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

         if (health <= 0)
        {
            transform.position = spawnpoint.transform.position;

            
            
        }

        

    }

    private void FixedUpdate()
    {
        if(health <= 0)
        {
            health = maxHealth;
        }
       
    }





}
