using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BP_Contact : MonoBehaviour
{
    public int puntos = 100; // Puedes ajustar este valor según el objeto

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Backpack"))
        {
            other.GetComponent<BackP>().AddItem(this.gameObject);

            // Notificar al jugador para añadir puntos
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.GetComponent<Player>().AnadirPuntos(puntos);
            }

            gameObject.SetActive(false);
        }
    }
}
