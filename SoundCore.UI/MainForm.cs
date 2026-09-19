// ============================================================================
// Proyecto:     SoundCore Engine GUI - Reto Integral Unidad 2
// Archivo:      MainForm.cs
// Asignatura:   Estructura de Datos (3er Semestre) - TecNM Campus Monclova
// Integrantes:  [NOMBRE COMPLETO 1] - [NUMERO DE CONTROL 1]
//               [NOMBRE COMPLETO 2] - [NUMERO DE CONTROL 2]
// Fecha:        2026-09-17
// Version:      1.0.0
//
// Sincronización reactiva entre la GUI y las 3 estructuras de datos:
//   - ListaSimpleEnlazada<Pista>  (implementación propia, con nodos)
//   - LinkedList<Pista>           (colección nativa .NET)
//   - List<Pista>                 (arreglo dinámico nativo .NET)
// ============================================================================

using System.Diagnostics;
using System.IO;
using SoundCore.EstructurasPropias;
using SoundCore.Modelos;

namespace SoundCore.UI
{
    public partial class MainForm : Form
    {
        // Estructuras paralelas: siempre contienen el mismo contenido lógico,
        // pero cada una lo administra con su propia implementación interna.
        private readonly ListaSimpleEnlazada<Pista> _colaPropia = new();
        private readonly LinkedList<Pista> _colaLinkedList = new();
        private readonly List<Pista> _colaList = new();

        private int _contadorId = 1;
        private Pista? _pistaSonando;

        // Reproductor real de audio. Se usa el tipo totalmente calificado
        // (System.Windows.Media.MediaPlayer) para no arrastrar "using System.Windows"
        // y evitar choques de nombres con System.Windows.Forms (Application, MessageBox, etc.).
        private readonly System.Windows.Media.MediaPlayer _reproductor = new();
        private string? _rutaArchivoSeleccionado;
        private bool _audioPausado;

        public MainForm()
        {
            InitializeComponent();
            ConfigurarColumnasGrid();
            CargarDatosSemilla();
            RefrescarVista();

            _reproductor.MediaFailed += Reproductor_MediaFailed;
        }

        private void ConfigurarColumnasGrid()
        {
            dgvCola.ColumnCount = 5;
            dgvCola.Columns[0].Name = "Pos";
            dgvCola.Columns[1].Name = "ID";
            dgvCola.Columns[2].Name = "Título / Artista";
            dgvCola.Columns[3].Name = "BPM";
            dgvCola.Columns[4].Name = "Duración";
            dgvCola.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDatosSemilla()
        {
            var demo = new[]
            {
                new Pista(_contadorId++, "Strobe", "deadmau5", 128, 634),
                new Pista(_contadorId++, "Midnight City", "M83", 105, 243),
                new Pista(_contadorId++, "Animals", "Martin Garrix", 130, 304)
            };

            foreach (var p in demo)
            {
                _colaPropia.AgregarAlFinal(p);
                _colaLinkedList.AddLast(p);
                _colaList.Add(p);
            }
        }

        // Valida y normaliza los datos capturados en el panel superior.
        // Los NumericUpDown ya acotan BPM (60-220) y Duración (1-7200s),
        // así que aquí solo se cubren los campos de texto libres.
        private Pista CrearPistaDesdeFormulario()
        {
            string titulo = string.IsNullOrWhiteSpace(txtTitulo.Text) ? $"Pista {_contadorId}" : txtTitulo.Text.Trim();
            string artista = string.IsNullOrWhiteSpace(txtArtista.Text) ? "DJ Desconocido" : txtArtista.Text.Trim();
            int bpm = (int)numBpm.Value;
            int duracion = (int)numDuracion.Value;
            string? rutaAudio = _rutaArchivoSeleccionado;

            // Se limpia la selección para que la siguiente pista no reutilice
            // el mismo archivo por accidente si el usuario olvida cambiarlo.
            _rutaArchivoSeleccionado = null;
            lblArchivoSeleccionado.Text = "(sin archivo de audio seleccionado)";

            return new Pista(_contadorId++, titulo, artista, bpm, duracion, rutaAudio);
        }

        private void btnCargarAudio_Click(object? sender, EventArgs e)
        {
            if (openFileDialogAudio.ShowDialog(this) == DialogResult.OK)
            {
                _rutaArchivoSeleccionado = openFileDialogAudio.FileName;
                lblArchivoSeleccionado.Text = "🎵 " + Path.GetFileName(_rutaArchivoSeleccionado);
                lblArchivoSeleccionado.ForeColor = Color.DarkGreen;
            }
        }

        private void EstructuraSeleccionada_CheckedChanged(object? sender, EventArgs e)
        {
            // CheckedChanged se dispara dos veces por cada cambio de RadioButton
            // (uno se desmarca, otro se marca); solo refrescamos con el que quedó activo.
            if (sender is RadioButton { Checked: true })
            {
                RefrescarVista();
            }
        }

        private void btnEncolarFinal_Click(object? sender, EventArgs e)
        {
            var pista = CrearPistaDesdeFormulario();

            if (rbPropia.Checked) _colaPropia.AgregarAlFinal(pista);
            else if (rbLinkedList.Checked) _colaLinkedList.AddLast(pista);
            else _colaList.Add(pista);

            RefrescarVista();
        }

        private void btnReproducirSiguiente_Click(object? sender, EventArgs e)
        {
            var pista = CrearPistaDesdeFormulario();

            if (rbPropia.Checked)
            {
                _colaPropia.ReproducirSiguiente(pista);
            }
            else if (rbLinkedList.Checked)
            {
                if (_colaLinkedList.First == null)
                    _colaLinkedList.AddFirst(pista);
                else
                    _colaLinkedList.AddAfter(_colaLinkedList.First, pista);
            }
            else
            {
                if (_colaList.Count <= 1) _colaList.Add(pista);
                else _colaList.Insert(1, pista);
            }

            RefrescarVista();
        }

        private void btnAvanzar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (rbPropia.Checked)
                {
                    _pistaSonando = _colaPropia.AvanzarPista();
                }
                else if (rbLinkedList.Checked)
                {
                    if (_colaLinkedList.First == null) throw new InvalidOperationException();
                    _pistaSonando = _colaLinkedList.First.Value;
                    _colaLinkedList.RemoveFirst();
                }
                else
                {
                    if (_colaList.Count == 0) throw new InvalidOperationException();
                    _pistaSonando = _colaList[0];
                    _colaList.RemoveAt(0);
                }

                lblNowPlaying.Text = $"▶ Reproduciendo: {_pistaSonando.Titulo} - {_pistaSonando.Artista} ({_pistaSonando.Bpm} BPM)";
                lblNowPlaying.ForeColor = Color.DarkGreen;
                ReproducirAudioDe(_pistaSonando);
                RefrescarVista();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(this, "No hay pistas pendientes en la cola.", "Fin del Setlist",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnInvertir_Click(object? sender, EventArgs e)
        {
            if (rbPropia.Checked)
            {
                _colaPropia.Invertir();
            }
            else if (rbLinkedList.Checked)
            {
                var listaTemporal = new List<Pista>(_colaLinkedList);
                listaTemporal.Reverse();
                _colaLinkedList.Clear();
                foreach (var item in listaTemporal) _colaLinkedList.AddLast(item);
            }
            else
            {
                _colaList.Reverse();
            }

            RefrescarVista();
        }

        private void btnOrdenarBpm_Click(object? sender, EventArgs e)
        {
            if (rbPropia.Checked)
            {
                var temporal = new ListaSimpleEnlazada<Pista>();
                foreach (var pista in _colaPropia)
                {
                    temporal.InsertarOrdenado(pista, (a, b) => a.Bpm.CompareTo(b.Bpm));
                }
                _colaPropia.Limpiar();
                foreach (var p in temporal) _colaPropia.AgregarAlFinal(p);
            }
            else if (rbLinkedList.Checked)
            {
                var ordenadas = _colaLinkedList.OrderBy(p => p.Bpm).ToList();
                _colaLinkedList.Clear();
                foreach (var p in ordenadas) _colaLinkedList.AddLast(p);
            }
            else
            {
                _colaList.Sort((a, b) => a.Bpm.CompareTo(b.Bpm));
            }

            RefrescarVista();
        }

        private void btnPurgar_Click(object? sender, EventArgs e)
        {
            if (rbPropia.Checked)
            {
                _colaPropia.DepurarDuplicados((a, b) => a.Titulo.Equals(b.Titulo, StringComparison.OrdinalIgnoreCase));
            }
            else if (rbLinkedList.Checked)
            {
                var unicos = _colaLinkedList.DistinctBy(p => p.Titulo).ToList();
                _colaLinkedList.Clear();
                foreach (var p in unicos) _colaLinkedList.AddLast(p);
            }
            else
            {
                var unicos = _colaList.DistinctBy(p => p.Titulo).ToList();
                _colaList.Clear();
                _colaList.AddRange(unicos);
            }

            RefrescarVista();
        }

        // Abre y reproduce el archivo de audio asociado a la pista, si tiene uno.
        private void ReproducirAudioDe(Pista pista)
        {
            _reproductor.Stop();

            if (string.IsNullOrWhiteSpace(pista.RutaArchivo) || !File.Exists(pista.RutaArchivo))
            {
                btnPausarReanudar.Enabled = false;
                btnDetener.Enabled = false;
                return;
            }

            _reproductor.Open(new Uri(pista.RutaArchivo));
            _reproductor.Play();
            _audioPausado = false;
            btnPausarReanudar.Text = "⏸ Pausar";
            btnPausarReanudar.Enabled = true;
            btnDetener.Enabled = true;
        }

        private void btnPausarReanudar_Click(object? sender, EventArgs e)
        {
            if (_audioPausado)
            {
                _reproductor.Play();
                btnPausarReanudar.Text = "⏸ Pausar";
            }
            else
            {
                _reproductor.Pause();
                btnPausarReanudar.Text = "▶ Reanudar";
            }
            _audioPausado = !_audioPausado;
        }

        private void btnDetener_Click(object? sender, EventArgs e)
        {
            _reproductor.Stop();
            _audioPausado = false;
            btnPausarReanudar.Text = "⏸ Pausar";
            btnPausarReanudar.Enabled = false;
            btnDetener.Enabled = false;
        }

        private void Reproductor_MediaFailed(object? sender, System.Windows.Media.ExceptionEventArgs e)
        {
            MessageBox.Show(this,
                "No se pudo reproducir el archivo de audio seleccionado. Verifica que el formato sea compatible (mp3, wav, wma, mp4).",
                "Error de reproducción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            btnPausarReanudar.Enabled = false;
            btnDetener.Enabled = false;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _reproductor.Close();
            base.OnFormClosed(e);
        }

        private void RefrescarVista()
        {
            dgvCola.Rows.Clear();
            IEnumerable<Pista> coleccion = rbPropia.Checked ? _colaPropia :
                                           rbLinkedList.Checked ? _colaLinkedList : _colaList;

            int index = 1;
            int duracionTotal = 0;

            foreach (var p in coleccion)
            {
                dgvCola.Rows.Add(index++, p.Id, $"{p.Titulo} — {p.Artista}", $"{p.Bpm} BPM", $"{p.DuracionSegundos}s");
                duracionTotal += p.DuracionSegundos;
            }

            lblEstadisticas.Text = $"Total en cola: {index - 1} | Tiempo total: {TimeSpan.FromSeconds(duracionTotal):mm\\:ss}";
        }

        // El benchmark corre en un hilo de fondo (Task.Run) para no congelar
        // la interfaz mientras se ejecutan miles de inserciones intermedias.
        private async void btnBenchmark_Click(object? sender, EventArgs e)
        {
            int n = (int)numCantidadBenchmark.Value;

            btnBenchmark.Enabled = false;
            txtResultadosBenchmark.Text = $"Ejecutando prueba de estrés con {n:N0} inserciones intermedias, por favor espere...";

            try
            {
                var (tiempoPropia, tiempoLinkedList, tiempoList) = await Task.Run(() => EjecutarBenchmark(n));

                txtResultadosBenchmark.Text =
                    $"=== RESULTADOS DE ESTRÉS ({n:N0} INSERCIONES INTERMEDIAS) ===\r\n" +
                    $"• Lista Enlazada Propia (Nodos):     {tiempoPropia,6} ms  [Operación O(1) por reconexión de punteros]\r\n" +
                    $"• .NET LinkedList<T>:                {tiempoLinkedList,6} ms  [Operación O(1) con AddAfter/LinkedListNode]\r\n" +
                    $"• .NET List<T> (Arreglo Dinámico):    {tiempoList,6} ms  [Operación O(n) por Array.Copy en Insert(idx)]\r\n\r\n" +
                    "Conclusión Técnica: en inserciones intermedias frecuentes, tanto la lista enlazada propia como " +
                    "LinkedList<T> superan a List<T>, porque no requieren desplazar el resto de los elementos en " +
                    "memoria contigua (Array.Copy) ni redimensionar el búfer interno.";
            }
            finally
            {
                btnBenchmark.Enabled = true;
            }
        }

        // Cálculo puro, sin tocar controles de UI: seguro para ejecutar en Task.Run.
        private static (long tiempoPropia, long tiempoLinkedList, long tiempoList) EjecutarBenchmark(int n)
        {
            var random = new Random(42);
            var sw = new Stopwatch();

            // 1. Lista propia: inserción tras la cabeza (Up Next), O(1) por operación
            var testPropia = new ListaSimpleEnlazada<Pista>();
            testPropia.AgregarAlFinal(new Pista(0, "Head", "DJ", 120, 200));
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                testPropia.ReproducirSiguiente(new Pista(i, $"Pista {i}", "DJ", random.Next(100, 150), 180));
            }
            sw.Stop();
            long tiempoPropia = sw.ElapsedMilliseconds;

            // 2. LinkedList<T> nativa: inserción tras el primer nodo, O(1) por operación
            var testLinkedList = new LinkedList<Pista>();
            testLinkedList.AddLast(new Pista(0, "Head", "DJ", 120, 200));
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                testLinkedList.AddAfter(testLinkedList.First!, new Pista(i, $"Pista {i}", "DJ", random.Next(100, 150), 180));
            }
            sw.Stop();
            long tiempoLinkedList = sw.ElapsedMilliseconds;

            // 3. List<T> (arreglo dinámico): Insert(1, ...) exige desplazar todo el arreglo
            var testList = new List<Pista> { new Pista(0, "Head", "DJ", 120, 200) };
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                testList.Insert(1, new Pista(i, $"Pista {i}", "DJ", random.Next(100, 150), 180));
            }
            sw.Stop();
            long tiempoList = sw.ElapsedMilliseconds;

            return (tiempoPropia, tiempoLinkedList, tiempoList);
        }
    }
}
