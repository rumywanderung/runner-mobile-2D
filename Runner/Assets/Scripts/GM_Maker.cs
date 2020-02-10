using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Maker : MonoBehaviour
{
    GameObject gamemanager;

    private void Awake()
    {
        gamemanager = Instantiate(Resources.Load("GameManager"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        Debug.Log("GM-MAKER");
        Destroy(this.gameObject);
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
