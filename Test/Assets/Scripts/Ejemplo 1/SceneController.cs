using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public Camera CamaraPrincipal;

    public Vector3 PosicionDestino;
    public Vector3 PosicionDestino2;

    public float VelocidadSuavizado = 0.125f;
    public Vector3 ajuste;

    private bool ActivarMovimiento = false;

    public bool posActual = false;

    // Start is called before the first frame update
    void Start()
    {
            StartCoroutine(Contador());
    }

    private IEnumerator Contador()
    {
        while (true)
        {
            ActivarMovimiento = true;
            yield return new WaitForSeconds(2f);
            ActivarMovimiento = false;
            posActual = !posActual;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ActivarMovimiento)
        {
            Debug.Log("Actualizando");
            Vector3 PosicionDeseada = (posActual ? PosicionDestino : PosicionDestino2) + ajuste;
            Vector3 TrasladoPosicion = Vector3.Lerp(CamaraPrincipal.transform.position, PosicionDeseada, VelocidadSuavizado);
            CamaraPrincipal.transform.position = TrasladoPosicion;

        }

    }
    private void Update()
    {
    }
}
