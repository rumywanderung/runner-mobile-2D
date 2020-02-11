using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform Tiles;
    public GameObject TilesObject;
    public GameObject heart;
    public GameObject heart2;
    public GameObject heart3;

    public GameObject fruit1;
    public GameObject fruit2;
    public GameObject fruit3;
    public GameObject fruit4;
    public GameObject fruit5;
    public GameObject fruit6;

    public Text score;
    public Text highscore;
    public int Points;
    public int HighPoints;

    public bool Overed;
    public bool otherTry = false;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        HighPoints = 0;
    }

    public void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }

    public void Update()
    {

        if ((SceneManager.GetActiveScene().name == "GameBis" || SceneManager.GetActiveScene().name == "Game") && otherTry == false)
        {
            Points = 0;
            Overed = false;
            otherTry = true;
            TilesObject = Instantiate((Resources.Load("Tiles")), new Vector2(0, 0), Quaternion.identity) as GameObject;
            score = FindObjectOfType<Canvas>().transform.GetChild(1).GetComponent<Text>();

            heart = Instantiate((Resources.Load("HEARTOBJECT")), new Vector2(7.98F, 5.88F), Quaternion.identity) as GameObject;
            heart2 = Instantiate((Resources.Load("HEARTOBJECT")), new Vector2(8.62F, 5.88F), Quaternion.identity) as GameObject;
            heart3 = Instantiate((Resources.Load("HEARTOBJECT")), new Vector2(9.27F, 5.88F), Quaternion.identity) as GameObject;

            fruit1 = Instantiate((Resources.Load("fruit1")), new Vector2(Random.Range(16, 100), Random.Range(0.22F, 2F)), Quaternion.identity) as GameObject;
            fruit2 = Instantiate((Resources.Load("fruit2")), new Vector2(Random.Range(16, 100), Random.Range(0.22F, 2F)), Quaternion.identity) as GameObject;
            fruit3 = Instantiate((Resources.Load("fruit3")), new Vector2(Random.Range(16, 100), Random.Range(0.22F, 2F)), Quaternion.identity) as GameObject;
            fruit4 = Instantiate((Resources.Load("fruit4")), new Vector2(Random.Range(16, 100), Random.Range(0.22F, 2F)), Quaternion.identity) as GameObject;
            fruit5 = Instantiate((Resources.Load("fruit5")), new Vector2(Random.Range(16, 100), Random.Range(0.22F, 2F)), Quaternion.identity) as GameObject;
            fruit6 = Instantiate((Resources.Load("fruit6")), new Vector2(Random.Range(16, 100), Random.Range(0.22F, 2F)), Quaternion.identity) as GameObject;

            fruit1.transform.SetParent(TilesObject.transform);
            fruit2.transform.SetParent(TilesObject.transform);
            fruit3.transform.SetParent(TilesObject.transform);
            fruit4.transform.SetParent(TilesObject.transform);
            fruit5.transform.SetParent(TilesObject.transform);
            fruit6.transform.SetParent(TilesObject.transform);
        }

        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            Transform GOScore;
            Transform GOHighscore;

            if (Overed == false)
            {
                Debug.Log("gameover");
                //highscore = Instantiate((Resources.Load("highscore") as GameObject), new Vector2(-194.1F, -23.8F), Quaternion.identity);
                Canvas canva = FindObjectOfType<Canvas>();
                GOScore = canva.transform.GetChild(1);
                GOHighscore = canva.transform.GetChild(2);
                //highscore.transform.SetParent(canva.transform);
                //score.transform.SetParent(canva.transform);

                if (Points > HighPoints)
                {
                    GOScore.GetComponent<Text>().text = "YOUR SCORE: " + Points.ToString();
                    GOHighscore.GetComponent<Text>().text = "BEST: " + Points.ToString();
                    HighPoints = Points;
                    Overed = true;
                    otherTry = false;
                    return;
                }
                else if (Points < HighPoints)
                {
                    GOScore.GetComponent<Text>().text = "YOUR SCORE: " + Points.ToString();
                    GOHighscore.GetComponent<Text>().text = "BEST: " + HighPoints.ToString();
                    Overed = true;
                    otherTry = false;
                    return;
                }

               
                //DontDestroyOnLoad(GOHighscore);
            }
        }
    }
}
