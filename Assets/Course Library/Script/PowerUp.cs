using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private ControlJugador jugador;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("Jugador").GetComponent<ControlJugador>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            jugador.powerUp = true;
            jugador.indicadorPowerUp.SetActive(true);
            Destroy(gameObject);
        }
    
    }
}
