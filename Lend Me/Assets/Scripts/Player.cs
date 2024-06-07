using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int vida = 3;

    public void RecibirDanio()
    {
        vida--;
        if(vida <= 0)
        {
            print("GameOver");
        }
    }
}
