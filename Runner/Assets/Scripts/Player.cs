using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    GameManager manager;
    Canvas canva;
    Transform ScoreText;

    int i;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        canva = FindObjectOfType<Canvas>();
        ScoreText = canva.transform.GetChild(1);
        i = 2;
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
            for (int j = 0; j <= 200; j++)
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
            ScoreText.GetComponent<Text>().text = "SCORE: " + manager.Points.ToString();
            collision.gameObject.transform.position = new Vector2(Random.Range(16, 100), Random.Range(0.22F, 2F));
        }

        #endregion
    }


    void Update()
    {
        
    }
}
