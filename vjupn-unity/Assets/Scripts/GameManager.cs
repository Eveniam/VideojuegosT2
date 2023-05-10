using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int Puntaje = 0;
    private int Muertes = 0;
    private int Llave = 0;
    private int Vidas = 3;
    // Start is called before the first frame update
    
    public void GanarPuntos() {
        Puntaje -= 1;
    }

    public void CantMuertes(){
        Muertes += 1;
    }

    public void CantLlave(){
        Llave += 1;
    }

    public void PerderVidas() {
        if(Vidas > 0)
            Vidas -= 1;
    }

    public int GetPuntaje() {
        return Puntaje;
    }
    public int GetAsesinatos() {
        return Muertes;
    }
    public int GetLlave() {
        return Llave;
    }

    public int GetVidas() {
        return Vidas;
    }
}
