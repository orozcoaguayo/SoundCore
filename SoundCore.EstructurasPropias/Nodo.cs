// ============================================================================
// Proyecto:     SoundCore Engine GUI - Reto Integral Unidad 2
// Archivo:      Nodo.cs
// Asignatura:   Estructura de Datos (3er Semestre) - TecNM Campus Monclova
// Integrantes:  [NOMBRE COMPLETO 1] - [NUMERO DE CONTROL 1]
//               [NOMBRE COMPLETO 2] - [NUMERO DE CONTROL 2]
// Fecha:        2026-09-17
// Version:      1.0.0
// ============================================================================

namespace SoundCore.EstructurasPropias
{
    /// <summary>
    /// Nodo genérico para la lista enlazada simple construida desde cero.
    /// Mantiene únicamente el valor almacenado y una referencia al siguiente
    /// nodo de la cadena (sin punteros a nodo anterior: es simplemente enlazada).
    /// </summary>
    public class Nodo<T>
    {
        public T Valor { get; set; }
        public Nodo<T>? Siguiente { get; set; }

        public Nodo(T valor)
        {
            Valor = valor;
            Siguiente = null;
        }
    }
}
