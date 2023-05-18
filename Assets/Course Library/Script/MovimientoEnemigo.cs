using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{   
    private float limiteMaxY = -10f;
    private float velocidadEnemigo = 1F;
    private GameObject jugador;
    private Rigidbody rbEnemigo;
    private ControlJugador controlJugador;
    // Start is called before the first frame update
    void Start()
    {
        //Iniciamos la variable jugador buscando el componente por el nombre del objeto
        jugador = GameObject.Find("Jugador");
        controlJugador = GameObject.Find("Jugador").GetComponent<ControlJugador>();
        //accedemos al rigidBody del objeto que tiene este script
        rbEnemigo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoviEnemigo();
    }

    //Destruimos el objeto si su posicion en y es menor al limiteenY
    void PosicionEnemigoY()
    {
        if (transform.position.y < limiteMaxY)
        {
            Destroy(gameObject);
        }
    }

    void MoviEnemigo()
    {   
        
        if (controlJugador.gameOver == false)
        {
            // a mayor distancia entre posicion mayor va a ser la fuerza del enemigo para moverse
            //para que esto no ocurra normalizamos el vector para que nos devuelva siempre una distancia de 1 para que no sufra aceleraciones
            Vector3 distanciaAlJugador = (jugador.transform.position - transform.position).normalized;
            rbEnemigo.AddForce(distanciaAlJugador * velocidadEnemigo);
            PosicionEnemigoY();
        }
        else
        {
            rbEnemigo.AddForce(new Vector3(0,0,0) * velocidadEnemigo);
            
        }

    }
}
