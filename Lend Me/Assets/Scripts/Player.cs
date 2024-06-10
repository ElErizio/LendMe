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
    public Text pointsText; 

    void Start()
    {
        panelDerrota.SetActive(false);
        panelVictoria.SetActive(false);
        ActualizarPuntosTexto(); 
    }

    public void RecibirDanio()
    {
        vida--;
        if (vida <= 0)
        {
            MostrarPanelDerrota();
        }
    }

    public void AnadirPuntos(int cantidad)
    {
        puntos += cantidad;
        ActualizarPuntosTexto();
        if (puntos >= 5000)
        {
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

    void ActualizarPuntosTexto()
    {
        pointsText.text = "Puntos: " + puntos.ToString();
    }
}
