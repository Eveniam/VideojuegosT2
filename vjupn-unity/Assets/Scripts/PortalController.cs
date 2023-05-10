using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject player;

    void OnCollisionEnter2D(Collision2D other){
        gameManager = GameObject.Find("GameManager");
        var gm = gameManager.GetComponent<GameManager>();
        
        if(other.gameObject.tag == "Player" && gm.GetLlave() == 1){
            
            SceneManager.LoadScene("Scene2");
        }
    }
}
