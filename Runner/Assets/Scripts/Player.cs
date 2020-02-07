using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    GameManager manager;

    int i = 2;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        #region Collision obstacles

        if (collision.gameObject.tag == "enemy")
        {
           switch (i)
           {
                case 2:
                    Destroy(manager.heart3.gameObject);
                    break;
                case 1:
                    Destroy(manager.heart2.gameObject);
                    break;
                case 0:
                    Destroy(manager.heart.gameObject);
                    SceneManager.LoadScene("GameOver");
                    break;
           }
            for (int i = 0; i <= 200; i++)
            {
                Debug.Log("Waiting");
            }
            i--;
        }

        #endregion

        #region Collision fruits

        if (collision.gameObject.tag == "fruit")
        {
            manager.Points += 1;
            manager.score.text = "SCORE: " + manager.Points.ToString();
            collision.gameObject.transform.position = new Vector2(Random.Range(16, 100), Random.Range(0.22F, 2F));
        }

        #endregion
    }


    void Update()
    {
        
    }
}
