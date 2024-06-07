using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackP : MonoBehaviour
{
    public List<GameObject> collectedItems = new List<GameObject>();

    public void AddItem(GameObject item)
    {
        // Añadir el objeto a la lista
        collectedItems.Add(item);

        // Opcional: Imprimir para debug
        Debug.Log(item.name + " has been added to backpack.");
    }
}
