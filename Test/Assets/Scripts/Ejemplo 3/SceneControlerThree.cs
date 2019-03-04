using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneControlerThree : MonoBehaviour
{
    public Camera CamaraPrincipal;
    public SpriteRenderer Imagen;
    public Scrollbar bar;
    public float AlturaImagen = 116;

    public Vector3 PosicionOriginal;
    public Vector3 PosicionDestino;

    public float VelocidadSuavizado = 0.125f;
    public Vector3 ajuste;

    private float Altura;
    private float Anchura;

    // Start is called before the first frame update
    void Start()
    {
        Altura = Imagen.sprite.rect.height;
        Anchura = Imagen.sprite.rect.width;
        Debug.Log(Altura);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            bar.value -= VelocidadSuavizado;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            bar.value += VelocidadSuavizado;

        }

    }

    void FixedUpdate()
    {
        Vector3 PosicionDeseada = PosicionDestino + ajuste;
        Vector3 TrasladoPosicion = Vector3.Lerp(CamaraPrincipal.transform.position, PosicionDeseada, VelocidadSuavizado);
        CamaraPrincipal.transform.position = TrasladoPosicion;

    }


    public void CambiarPosicion()
    {
        PosicionDestino = new Vector3(PosicionOriginal.x, PosicionOriginal.y - (bar.value * AlturaImagen), PosicionOriginal.z);
    }

    public void CambiarPosicionMouse()
    {
        bar.value += Input.mouseScrollDelta.y;
    }
}
