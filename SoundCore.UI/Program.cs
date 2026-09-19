// ============================================================================
// Proyecto:     SoundCore Engine GUI - Reto Integral Unidad 2
// Archivo:      Program.cs
// Asignatura:   Estructura de Datos (3er Semestre) - TecNM Campus Monclova
// Integrantes:  [NOMBRE COMPLETO 1] - [NUMERO DE CONTROL 1]
//               [NOMBRE COMPLETO 2] - [NUMERO DE CONTROL 2]
// Fecha:        2026-09-17
// Version:      1.0.0
// ============================================================================

namespace SoundCore.UI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal de la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
