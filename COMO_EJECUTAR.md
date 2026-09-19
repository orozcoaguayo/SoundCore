# Cómo abrir y ejecutar SoundCore Engine GUI

## Requisitos
- **Windows 10/11** (el proyecto usa Windows Forms, no corre en macOS/Linux).
- **Visual Studio 2022** (versión 17.10 o superior) con la carga de trabajo
  **".NET Desktop Development"** instalada.
- **.NET SDK 10.0** instalado (si tu Visual Studio aún no lo trae integrado,
  descárgalo desde https://dotnet.microsoft.com/download).

## Opción A — Abrir con Visual Studio (recomendado)
1. Descomprime el archivo `SoundCore.zip`.
2. Haz doble clic en `SoundCore.sln` para abrir la solución.
3. Asegúrate de que **`SoundCore.UI`** esté marcado como *proyecto de inicio*
   (clic derecho sobre `SoundCore.UI` → "Establecer como proyecto de inicio").
4. Presiona **F5** (o el botón ▶ "Iniciar") para compilar y ejecutar.

## Opción B — Compilar y ejecutar por línea de comandos
Abre una terminal (PowerShell) en la carpeta `SoundCore` y ejecuta:

```powershell
dotnet build
dotnet run --project SoundCore.UI
```

## Estructura de la solución
```
SoundCore/
├── SoundCore.sln
├── SoundCore.Modelos/                 # Capa de modelos (record Pista)
│   ├── SoundCore.Modelos.csproj
│   └── Pista.cs
├── SoundCore.EstructurasPropias/      # Lista enlazada simple hecha a mano
│   ├── SoundCore.EstructurasPropias.csproj
│   ├── Nodo.cs
│   └── ListaSimpleEnlazada.cs
└── SoundCore.UI/                      # GUI Windows Forms
    ├── SoundCore.UI.csproj
    ├── Program.cs
    ├── MainForm.cs                    # Lógica (code-behind)
    └── MainForm.Designer.cs           # Diseño de controles
```

## Qué hace la app al iniciar
Carga 3 pistas de ejemplo (Strobe, Midnight City, Animals) simultáneamente en
las tres estructuras (`ListaSimpleEnlazada<Pista>`, `LinkedList<Pista>` y
`List<Pista>`), para que puedas alternar el radio button y ver cómo cada
estructura refleja el mismo contenido con su propia implementación interna.

## 🎵 Reproducción de audio real (agregado)
La app ahora reproduce audio de verdad usando `System.Windows.Media.MediaPlayer`
(por eso `SoundCore.UI.csproj` tiene `<UseWPF>true</UseWPF>` además de WinForms;
no requiere ningún paquete NuGet adicional).

- **Formatos soportados:** `.mp3`, `.wav`, `.wma`, `.mp4`, `.m4a` (usa los
  códecs de Windows Media Foundation ya instalados en el sistema). Se
  recomienda `.mp3` por ser el más ligero y compatible.
- Antes de dar clic en **"Encolar al Final"** o **"Reproducir Siguiente"**,
  puedes usar el botón **"📂 Cargar Audio"** para asociarle un archivo a esa
  pista (opcional; si no seleccionas nada, la pista queda sin audio).
- Al presionar **"⏩ Avanzar Pista"**, si la pista que entra a sonar tiene un
  archivo asociado, se reproduce automáticamente.
- Los botones **"⏸ Pausar/▶ Reanudar"** y **"⏹ Detener"** aparecen junto al
  indicador "▶ Reproduciendo:" y controlan la reproducción en curso.

> **Nota importante:** esta característica va más allá de lo que pide el
> README original del reto (que es 100% sobre estructuras de datos, sin
> audio real). Si tu rúbrica exige que el modelo `Pista` tenga exactamente
> las 5 propiedades originales, avísame y quito el campo `RutaArchivo` antes
> de entregar — se agregó como parámetro opcional para no romper nada, pero
> técnicamente sí modifica el `record` del README.

## Antes de entregar (requisito del README del proyecto)
Reemplaza los marcadores `[NOMBRE COMPLETO]` y `[NUMERO DE CONTROL]` en el
encabezado de cada archivo `.cs` con los datos reales del equipo, y actualiza
la fecha/versión si corresponde.

## Notas de implementación
- **`ListaSimpleEnlazada<T>`** no usa arrays ni colecciones auxiliares en
  ninguno de sus 6 métodos (incluida la inversión, que es estrictamente
  in-place con 3 referencias `previo/actual/siguiente`).
- El **benchmark** corre en un hilo de fondo (`Task.Run`) para no congelar la
  ventana mientras se ejecutan decenas de miles de inserciones, y compara las
  3 estructuras (propia, `LinkedList<T>` y `List<T>`).
- Los campos `txtTitulo`/`txtArtista` tienen valores por defecto si se dejan
  vacíos, y `BPM`/`Duración` están acotados por los propios `NumericUpDown`
  (60–220 BPM, 1–7200 s) para evitar datos inválidos.
