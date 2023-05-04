using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public AudioClip[] audios;
    public GameObject gameManager;
    public GameObject bala;

    
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private AudioSource audioSource;
    private Transform balaTransform;

    private bool MoverA = false;
    

    private bool balaExiste = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        //SceneManager.LoadScene("Scene2");

    }

    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)) {
          rb.velocity = new Vector2(10, rb.velocity.y);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
          MoverIzquierda();
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow)) {
          Detenerse();
        }



        Saltar();
        Disparar();
        DividirDisparo();
    }


    public void MoverArriba(){
      if(MoverA) rb.velocity = new Vector2(rb.velocity.x, 10);

    }
    public void MoverIzquierda() {
      Changeface(-1);
      rb.velocity = new Vector2(-10, rb.velocity.y);
    }
    public void MoverDerecha() {
      Changeface(1);
      rb.velocity = new Vector2(10, rb.velocity.y);
    }
    public void Detenerse() {
      rb.velocity = new Vector2(0, 0);
    }

    private void Changeface(int direccion){
      if(direccion == -1) sp.flipX = true;
      else sp.flipX = false;
    }

    private void Saltar() {
      if(Input.GetKeyUp(KeyCode.Space)) {
        ReproducirSonidoSalto();
      }
    }

    void OnCollisionEnter2D(Collision2D other){
      Debug.Log(tag);
      if(other.gameObject.tag == "Piso") MoverA = true;
      if(other.gameObject.tag == "Enemy") Destroy(gameObject);
    }

    void OnCollisionExit2D(Collision2D other){
      Debug.Log(tag);
      MoverA = false;
    }

    public void ReproducirSonidoSalto() {
      audioSource.PlayOneShot(audios[0]);
    }

    public void DispararBoton(){
      balaExiste = true;
      var position = transform.position;
      var x = position.x + 1;
      var newPosition = new Vector3(x, position.y, position.z);
      GameObject balaGenerada = Instantiate(bala, newPosition, Quaternion.identity);
      balaTransform = balaGenerada.transform;
      GanarPuntos();
    }

    public void DividirDisparoBoton(){
      if(balaExiste) {

        var position = balaTransform.position;
        var positionBala2 = new Vector3(position.x + 1, position.y + 1, position.z); 
        var positionBala3 = new Vector3(position.x + 1, position.y - 1, position.z); 

        GameObject balaGenerada2 = Instantiate(bala, positionBala2, Quaternion.identity);

        (balaGenerada2.GetComponent<BalaController>()).velocityY = 1;

        GameObject balaGenerada3 = Instantiate(bala, positionBala3, Quaternion.identity);

        (balaGenerada3.GetComponent<BalaController>()).velocityY = -1;
      }
    }

    private void Disparar() {

      if(Input.GetKeyUp(KeyCode.X)) {
        balaExiste = true;
        var position = transform.position;
        var x = position.x + 1;
        var newPosition = new Vector3(x, position.y, position.z);
        
        GameObject balaGenerada = Instantiate(bala, newPosition, Quaternion.identity);
        balaTransform = balaGenerada.transform;
        GanarPuntos();
      }
    }

    private void DividirDisparo() {
      // solo se divide si la bala existe y presiono C
      //transform.position
      if(balaExiste && Input.GetKeyUp(KeyCode.Y)) {

        var position = balaTransform.position;
        var positionBala2 = new Vector3(position.x + 1, position.y + 1, position.z); 
        var positionBala3 = new Vector3(position.x + 1, position.y - 1, position.z); 

        GameObject balaGenerada2 = Instantiate(bala, positionBala2, Quaternion.identity);

        (balaGenerada2.GetComponent<BalaController>()).velocityY = 1;

        GameObject balaGenerada3 = Instantiate(bala, positionBala3, Quaternion.identity);

        (balaGenerada3.GetComponent<BalaController>()).velocityY = -1;
      }
    }

    private void GanarPuntos() {
      // var gm = gameManager.GetComponent<GameManager>();
      // var uim = gameManager.GetComponent<UiManager>();

      // gm.GanarPuntos();
      // uim.PrintPuntaje(gm.GetPuntaje());
    }
}
