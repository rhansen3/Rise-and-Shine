using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    int lives = 3;
    public Image health1;
    public Image health2;
    public Image health3;
    
    // Start is called before the first frame update
    void Start()
    {
           health1.enabled = true;
           health2.enabled = true;
           health3.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(){
        lives -= 1;
        if(lives == 2){
            health3.enabled = false;
        } else if(lives == 1){
            health2.enabled = false;
        }
        if(lives == 0){
            health1.enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
