// ============================================================================
// Proyecto:     SoundCore Engine GUI - Reto Integral Unidad 2
// Archivo:      Pista.cs
// Asignatura:   Estructura de Datos (3er Semestre) - TecNM Campus Monclova
// Integrantes:  [NOMBRE COMPLETO 1] - [NUMERO DE CONTROL 1]
//               [NOMBRE COMPLETO 2] - [NUMERO DE CONTROL 2]
// Fecha:        2026-09-17
// Version:      1.0.0
// ============================================================================

namespace SoundCore.Modelos
{
    /// <summary>
    /// Representa una pista musical dentro de la cola de reproducción del DJ.
    /// Se define como record para obtener igualdad por valor e inmutabilidad
    /// de forma gratuita, sin necesidad de estructuras auxiliares.
    /// </summary>
    public record Pista(int Id, string Titulo, string Artista, int Bpm, int DuracionSegundos, string? RutaArchivo = null)
    {
        public override string ToString() =>
            $"[ID: {Id:D3}] {Titulo} - {Artista} | {Bpm} BPM ({DuracionSegundos}s)";
    }
}
