using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BP_Contact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Asumimos que la mochila tiene una etiqueta llamada "Backpack"
        if (other.CompareTag("Backpack"))
        {
            // Notificar a la mochila que el objeto ha sido recogido
            other.GetComponent<BackP>().AddItem(this.gameObject);

            // Desactivar el objeto para "recogerlo"
            gameObject.SetActive(false);
        }
    }
}
