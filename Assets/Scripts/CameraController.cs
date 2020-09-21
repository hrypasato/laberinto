using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 posicionInicial;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = this.transform.position - player.transform.position;//vector de distancia entre ambos puntos
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position + posicionInicial;//mover
    }
}
