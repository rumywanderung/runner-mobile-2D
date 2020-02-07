using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform Tiles;
    public GameObject heart;
    public GameObject heart2;
    public GameObject heart3;

    public GameObject fruit1;
    public GameObject fruit2;
    public GameObject fruit3;
    public GameObject fruit4;
    public GameObject fruit5;
    public GameObject fruit6;

    public GameObject screen;

    public Text score;
    public int Points = 0;
    public int HighPoints = 0;
    public GameObject highscore = null;

    public bool Overed = false;

    int i = 3;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(score);
        DontDestroyOnLoad(score.gameObject);
    }

    void Start()
    {
        heart = Instantiate((Resources.Load("HEARTOBJECT")), new Vector2(7.98F, 5.88F), Quaternion.identity) as GameObject;
        heart2 = Instantiate((Resources.Load("HEARTOBJECT")), new Vector2(8.62F, 5.88F), Quaternion.identity) as GameObject;
        heart3 = Instantiate((Resources.Load("HEARTOBJECT")), new Vector2(9.27F, 5.88F), Quaternion.identity) as GameObject;

        fruit1 = Instantiate((Resources.Load("fruit1")), new Vector2(Random.Range(16, 100), Random.Range(0.22F, 2F)), Quaternion.identity) as GameObject;
        fruit2 = Instantiate((Resources.Load("fruit2")), new Vector2(Random.Range(16, 100), Random.Range(0.22F, 2F)), Quaternion.identity) as GameObject;
        fruit3 = Instantiate((Resources.Load("fruit3")), new Vector2(Random.Range(16, 100), Random.Range(0.22F, 2F)), Quaternion.identity) as GameObject;
        fruit4 = Instantiate((Resources.Load("fruit4")), new Vector2(Random.Range(16, 100), Random.Range(0.22F, 2F)), Quaternion.identity) as GameObject;
        fruit5 = Instantiate((Resources.Load("fruit5")), new Vector2(Random.Range(16, 100), Random.Range(0.22F, 2F)), Quaternion.identity) as GameObject;
        fruit6 = Instantiate((Resources.Load("fruit6")), new Vector2(Random.Range(16, 100), Random.Range(0.22F, 2F)), Quaternion.identity) as GameObject;

        fruit1.transform.SetParent(Tiles);
        fruit2.transform.SetParent(Tiles);
        fruit3.transform.SetParent(Tiles);
        fruit4.transform.SetParent(Tiles);
        fruit5.transform.SetParent(Tiles);
        fruit6.transform.SetParent(Tiles);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            if (Overed == false)
            {
                Debug.Log("gameover");
                highscore = Instantiate((Resources.Load("highscore") as GameObject), new Vector2(-194.1F, -23.8F), Quaternion.identity);
                Canvas canva = FindObjectOfType<Canvas>();
                highscore.transform.SetParent(canva.transform);
                score.transform.SetParent(canva.transform);

                if (Points > HighPoints)
                {
                    score.text = "YOUR SCORE: " + Points.ToString();
                    highscore.GetComponent<Text>().text = "BEST SCORE: " + Points.ToString();
                    return;
                }
                else if (Points < HighPoints)
                {
                    score.text = "YOUR SCORE: " + Points.ToString();
                    return;
                }

                Overed = true;
            }
        }
    }
}
