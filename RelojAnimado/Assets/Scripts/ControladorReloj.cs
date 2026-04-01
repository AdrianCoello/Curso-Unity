using System;
using UnityEngine;

public class ControladorReloj : MonoBehaviour
{
    [Header("Asigna aquí los Pivotes")]
    public Transform pivotHoras;
    public Transform pivotMinutos;
    public Transform pivotSegundos;

    // Constantes de los grados que avanza cada manecilla
    private const float gradosPorHora = 30f;    // 360 grados / 12 horas
    private const float gradosPorMinuto = 6f;   // 360 grados / 60 minutos
    private const float gradosPorSegundo = 6f;  // 360 grados / 60 segundos

    void Update()
    {
        // Obtener la hora actual del sistema
        DateTime tiempoActual = DateTime.Now;

        // Calculamos la rotación. 
        // Añadimos las fracciones para que la manecilla de las horas se mueva gradualmente entre hora y hora.
        float rotacionHoras = (tiempoActual.Hour % 12 + tiempoActual.Minute / 60f) * gradosPorHora;
        float rotacionMinutos = (tiempoActual.Minute + tiempoActual.Second / 60f) * gradosPorMinuto;
        float rotacionSegundos = tiempoActual.Second * gradosPorSegundo;

        // Aplicamos la rotación en el eje Z (multiplicamos por -1 para que gire en sentido horario)
        pivotHoras.localRotation = Quaternion.Euler(0f, 0f, -rotacionHoras);
        pivotMinutos.localRotation = Quaternion.Euler(0f, 0f, -rotacionMinutos);
        pivotSegundos.localRotation = Quaternion.Euler(0f, 0f, -rotacionSegundos);
    }
}