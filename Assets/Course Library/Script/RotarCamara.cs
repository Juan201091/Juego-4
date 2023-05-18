using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarCamara : MonoBehaviour
{
    public float velocidadGiro = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * Time.deltaTime * velocidadGiro*movHorizontal);
    }
}
