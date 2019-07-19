using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{

    public int lives;
    public int maxNumberOfLives = 3;

    private GameObject[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        lives = maxNumberOfLives;

        hearts = new GameObject[maxNumberOfLives];

        for(int i = 0; i<maxNumberOfLives; i++)
        {
            hearts[i] = transform.GetChild(i).gameObject;
        }
    }

    public void AddLife() 
    {
        lives++;

        if(lives > maxNumberOfLives)
        {
            lives = maxNumberOfLives;
        }
        UpdateGraphics();
    }

    public void RemoveLife()
    {
        lives --;
        if(lives <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("level1");
        }
        UpdateGraphics();
    }

    public void UpdateGraphics()
    {
        for(int i= 0; i<maxNumberOfLives; i++)
        {
            if(i >= lives)
            {
                hearts[i].SetActive(false);
            }
            else{
                 hearts[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
