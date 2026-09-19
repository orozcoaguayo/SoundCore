# SoundCore Engine GUI — DJ Set Queue Controller

**Asignatura:** Estructura de Datos (3er Semestre) — TecNM Campus Monclova  
**Fecha:** Septiembre de 2026  
**Tecnología:** .NET 10 (C# / WinForms / WPF Media)

---

## 📋 Descripción del Proyecto

**SoundCore Engine GUI** es un sistema de gestión de colas de reproducción (*setlists*) diseñado para DJs y reproductores musicales. El propósito principal de la aplicación es demostrar la eficiencia algorítmica y la manipulación directa de memoria mediante **listas enlazadas simples con referencias/punteros (`Nodo<T>`)**, comparando su comportamiento en tiempo real con colecciones nativas del ecosistema .NET.

El proyecto incorpora un módulo de **telemetría y benchmark** para evaluar el rendimiento de inserciones intermedias en grandes volúmenes de datos, así como un **reproductor multimedia integrado**.

---

## 🚀 Características Clave

1. **Estructura de Datos Propia desde Cero (`ListaSimpleEnlazada<T>`):**
   * Implementada **sin arreglos internos ni listas nativas auxiliares**.
   * Control directo de referencias `Siguiente` en memoria.
   * Implementa `IEnumerable<T>` para vinculación de datos e iteración por `foreach`.

2. **Comparativa Paratela de Estructuras (.NET 10):**
   * Permite conmutar la ejecución en vivo entre tres estructuras de datos:
     1. `ListaSimpleEnlazada<Pista>` (Implementación propia basada en nodos).
     2. `System.Collections.Generic.LinkedList<Pista>` (Lista doblemente enlazada de .NET).
     3. `System.Collections.Generic.List<Pista>` (Arreglo dinámico continuo de .NET).

3. **Módulo de Benchmark Asíncrono:**
   * Prueba de estrés ejecutable en segundo plano (`Task.Run`) para no congelar la interfaz gráfica.
   * Mide diferencias de rendimiento entre reconexión de punteros ($O(1)$) y reasignación en bloques contiguos de memoria / `Array.Copy` ($O(n)$).

4. **Reproducción Multimedia Real:**
   * Soporte nativo para reproducir, pausar, reanudar y detener archivos audio (`.mp3`, `.wav`, `.wma`, `.mp4`) mediante `System.Windows.Media.MediaPlayer`.

---

## 🛠️ Métodos Algorítmicos Implementados

| Método en `ListaSimpleEnlazada<T>` | Complejidad | Descripción Algorítmica |
| :--- | :---: | :--- |
| **`AgregarAlFinal(T valor)`** | $O(n)$ | Recorre la lista hasta el último nodo accesible y conecta el nuevo `Nodo<T>`. |
| **`ReproducirSiguiente(T valor)`** | $O(1)$ | Inserta la pista inmediatamente después del nodo `Cabeza` (Up Next) reconectando sus punteros. |
| **`AvanzarPista()`** | $O(1)$ | Desencola el primer elemento desplazando `Cabeza` hacia `Cabeza.Siguiente`. |
| **`Invertir()`** | $O(n)$ | **Inversión In-Place estricta.** Reorienta los punteros `Siguiente` en memoria con 3 referencias auxiliares (`previo`, `actual`, `siguiente`) sin duplicar nodos ni usar estructuras secundarias ($O(1)$ espacio). |
| **`InsertarOrdenado(T, Comparison<T>)`** | $O(n)$ | Busca la posición exacta según el criterio (ej. BPM) e inserta reconectando referencias. |
| **`DepurarDuplicados(Func<T, T, bool>)`** | $O(n^2)$ | Limpia pistas duplicadas omitiendo nodos en la cadena sin usar `HashSet` ni listas auxiliares. |

---

## 📁 Arquitectura del Proyecto

```text
SoundCore/
├── SoundCore.sln                           # Solución de C# / Visual Studio
├── SoundCore.Modelos/                      # Capa de Modelo
│   └── Pista.cs                            # Record que representa la pista musical
├── SoundCore.EstructurasPropias/           # Capa de Estructuras de Datos
│   ├── Nodo.cs                             # Nodo genérico autoreferenciado
│   └── ListaSimpleEnlazada.cs               # Lista simple implementada con punteros
└── SoundCore.UI/                           # Capa de Presentación (WinForms + WPF Media)
    ├── Program.cs                          # Punto de entrada de la aplicación
    ├── MainForm.cs                         # Lógica del formulario y benchmark
    └── MainForm.Designer.cs                # Maquetado y componentes de UI
