using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int vida = 3;
    public int puntos = 0;

    public GameObject panelDerrota;
    public GameObject panelVictoria;

    void Start()
    {
        panelDerrota.SetActive(false);
        panelVictoria.SetActive(false);
    }

    public void RecibirDanio()
    {
        vida--;
        if (vida <= 0)
        {
            print("GameOver");
            MostrarPanelDerrota();
        }
    }

    public void AñadirPuntos(int cantidad)
    {
        puntos += cantidad;
        if (puntos >= 5000)
        {
            print("Victoria");
            MostrarPanelVictoria();
        }
    }

    void MostrarPanelDerrota()
    {
        Time.timeScale = 0;
        panelDerrota.SetActive(true);
    }

    void MostrarPanelVictoria()
    {
        Time.timeScale = 0;
        panelVictoria.SetActive(true);
    }
}