using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneracionEnemigos : MonoBehaviour
{
    //Variables de campo
    private float rangoGeneracion = 9f;
    public GameObject enemigoPrefab;
    public GameObject PowerUpPrefab;
    private int numeroEnemigos;
    private byte numeroOleada = 1;
    // Start is called before the first frame update
    void Start()
    {
        //Primera Generacion de enemigos
        GenerarEnemigos(numeroOleada);
       
    }

    // Update is called once per frame
    void Update()
    {
        //Obtenemos el total de objetos que contienen este script
        numeroEnemigos = FindObjectsOfType<MovimientoEnemigo>().Length;
        //Si el numero de enemigos es menor a 0 
        if (numeroEnemigos <= 0)
        {
            numeroOleada++;
            GenerarEnemigos(numeroOleada);
            GenerarPowerUp();
        }
    }

    //Generacion de enemigos según la oleada
    void GenerarEnemigos(int enemigosAGenerar)
    {
        for (int i = 0; i < enemigosAGenerar; i++)
        {
            //posiciones random en el mapa para iniciar u nuevo vector en esas coordenadas

            float posx = Random.Range(-rangoGeneracion, rangoGeneracion);
            float posz = Random.Range(-rangoGeneracion, rangoGeneracion);
            Vector3 posRamdom = new Vector3(posx, 0, posz);
            Instantiate(enemigoPrefab, posRamdom, enemigoPrefab.transform.rotation);
        }
    }
    void GenerarPowerUp()
    {
        //Genracion ramdom de power up
        float posx = Random.Range(-rangoGeneracion, rangoGeneracion);
        float posz = Random.Range(-rangoGeneracion, rangoGeneracion);
        Vector3 posRamdom = new Vector3(posx, 0, posz);
        Instantiate(PowerUpPrefab, posRamdom, PowerUpPrefab.transform.rotation);
    }
}
