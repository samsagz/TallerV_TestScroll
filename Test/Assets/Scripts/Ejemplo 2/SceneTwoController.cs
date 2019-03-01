using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTwoController : MonoBehaviour
{
    public List<Vector3> PosicionesCamara;
    public Camera CamaraPrincipal;

    public Vector3 PosicionDestino;

    public float VelocidadSuavizado = 0.125f;
    public Vector3 ajuste;


    public int PosicionActual = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (PosicionesCamara.Count != 0)
            PosicionDestino = PosicionesCamara[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            CuadroAnterior();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            SiguienteCuadro();
    }

    void FixedUpdate()
    {
            Vector3 PosicionDeseada = PosicionDestino + ajuste;
            Vector3 TrasladoPosicion = Vector3.Lerp(CamaraPrincipal.transform.position, PosicionDeseada, VelocidadSuavizado);
            CamaraPrincipal.transform.position = TrasladoPosicion;

    }


    public void SiguienteCuadro()
    {
        PosicionActual++;
        PosicionActual = PosicionActual % PosicionesCamara.Count;

        PosicionDestino = PosicionesCamara[PosicionActual];

    }

    public void CuadroAnterior()
    {
        PosicionActual--;
        PosicionActual = PosicionActual < 0 ? PosicionesCamara.Count-1: PosicionActual;
        PosicionActual = PosicionActual % PosicionesCamara.Count;

        PosicionDestino = PosicionesCamara[PosicionActual];
    }
}
