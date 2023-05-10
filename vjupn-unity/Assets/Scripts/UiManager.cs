using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text PuntajeText;
    public Text AsesisantoText;
    public Text LlaveText;

    public void PrintPuntaje(int puntos) {
        PuntajeText.text = "Vida: " + puntos;
    }
    public void PrintAsesinatos(int muertes){
        AsesisantoText.text = "Asesinatos: " + muertes;
    }
    public void PrintText(int llave){
        if(llave == 1) LlaveText.text = "CONGRATULATIONS";
    }
}
