using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    private float LimiteMaxY = -10f;
    public GameObject indicadorPowerUp;
    public bool powerUp;
    private GameObject puntoEnfoque; 
    private Rigidbody rb;
    public float velocidad = 5f;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {//Movemos la poscion de la esfera en base al punto de enfoque y no por una posicion global
        //sino que lo hacemos en base a al posicion dle punto de enfoque

        puntoEnfoque = GameObject.Find("Enfoque");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PosicionJugadory();
        MovJugador();
    }

    IEnumerator RutinaTemporizadorPowerUp()
    {
        yield return new WaitForSeconds(7);
        powerUp = false;
        indicadorPowerUp.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && powerUp&&!gameOver)
        {
            float fuerzaPowerUp = 15f;
            Rigidbody rbEnemigo = collision.gameObject.GetComponent<Rigidbody>();
            //Vector de fuerza que separa al jugador del enemigo distancia
            Vector3 lanzarEnemigo = collision.gameObject.transform.position - transform.position;
            rbEnemigo.AddForce(lanzarEnemigo*fuerzaPowerUp, ForceMode.Impulse);
            StartCoroutine(RutinaTemporizadorPowerUp());
        }
    }

    void PosicionJugadory()
    {
        if(transform.position.y < LimiteMaxY)
        {
            Destroy(gameObject);
            gameOver = true;
            Debug.Log("GameOver");
        }
    }

    void MovJugador()
    {
        float movimientoVertical = Input.GetAxis("Vertical");
        rb.AddForce(puntoEnfoque.transform.forward * movimientoVertical * velocidad);
        //Igualamos la posicion del powerup con la del jugador xq si fuese hijo tbm aplicarria rotaciones
        //si queresmo darle otra posiciones sumamos un vector sería la dsitancia 
        indicadorPowerUp.transform.position = transform.position;
    }
}
