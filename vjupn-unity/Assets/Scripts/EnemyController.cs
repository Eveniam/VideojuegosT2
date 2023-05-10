using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject gameManager;

    private int cantMorir = 2;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-5, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Bala"){
            cantMorir -= 1;
            if(cantMorir < 1) 
            {
                Destroy(gameObject);
                var gm = gameManager.GetComponent<GameManager>();
                var uim = gameManager.GetComponent<UiManager>();
                gm.CantMuertes();
                uim.PrintAsesinatos(gm.GetAsesinatos());
                if(gm.GetAsesinatos() == 3){
                    gm.CantLlave();
                    uim.PrintText(gm.GetLlave());
                }
            }
        }
    }
}
