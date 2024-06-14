using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int vida = 3;
    public int puntos = 0;

    public GameObject defeatPanel;
    public GameObject panelVictoria;
    public TMP_Text pointsText;


    private void Awake()
    {

        print(panelVictoria.name);
    }
    void Start()
    {

        
        panelVictoria.gameObject.SetActive(false);
        
        defeatPanel.gameObject.SetActive(false);
        
        ActualizarPuntosTexto();
    }

    public int RecibirDanio()
    {
        vida--;
        if (vida <= 0)
        {
            SceneManager.LoadScene("Perdiste");
        }
        return vida;
    }

    public void AnadirPuntos(int cantidad)
    {
        puntos += cantidad;
        ActualizarPuntosTexto();
        if (puntos >= 1500)
        {
            SceneManager.LoadScene("Ganaste");
        }
    }

    void MostrardefeatPanel()
    {
        Time.timeScale = 0;
        defeatPanel.gameObject.SetActive(true);
    }

    void MostrarPanelVictoria()
    {
        Time.timeScale = 0;
        panelVictoria.gameObject.SetActive(true);
    }

    void ActualizarPuntosTexto()
    {
        pointsText.text = "Puntos: " + puntos.ToString();
    }
}
