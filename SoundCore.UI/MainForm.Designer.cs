namespace SoundCore.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer? components = null;

        // ---- Panel superior: registro de pista ----
        private System.Windows.Forms.GroupBox grpRegistro = null!;
        private System.Windows.Forms.Label lblTitulo = null!;
        private System.Windows.Forms.TextBox txtTitulo = null!;
        private System.Windows.Forms.Label lblArtista = null!;
        private System.Windows.Forms.TextBox txtArtista = null!;
        private System.Windows.Forms.Label lblBpm = null!;
        private System.Windows.Forms.NumericUpDown numBpm = null!;
        private System.Windows.Forms.Label lblDuracion = null!;
        private System.Windows.Forms.NumericUpDown numDuracion = null!;
        private System.Windows.Forms.Label lblModo = null!;
        private System.Windows.Forms.RadioButton rbPropia = null!;
        private System.Windows.Forms.RadioButton rbLinkedList = null!;
        private System.Windows.Forms.RadioButton rbList = null!;
        private System.Windows.Forms.Button btnCargarAudio = null!;
        private System.Windows.Forms.Label lblArchivoSeleccionado = null!;
        private System.Windows.Forms.OpenFileDialog openFileDialogAudio = null!;

        // ---- Panel central ----
        private System.Windows.Forms.Panel pnlMiddle = null!;

        // Acciones de cola
        private System.Windows.Forms.GroupBox grpAcciones = null!;
        private System.Windows.Forms.FlowLayoutPanel flpAcciones = null!;
        private System.Windows.Forms.Button btnEncolarFinal = null!;
        private System.Windows.Forms.Button btnReproducirSiguiente = null!;
        private System.Windows.Forms.Button btnAvanzar = null!;
        private System.Windows.Forms.Button btnInvertir = null!;
        private System.Windows.Forms.Button btnOrdenarBpm = null!;
        private System.Windows.Forms.Button btnPurgar = null!;

        // Playlist visual / cola en vivo
        private System.Windows.Forms.GroupBox grpPlaylist = null!;
        private System.Windows.Forms.Panel pnlNowPlaying = null!;
        private System.Windows.Forms.Label lblNowPlaying = null!;
        private System.Windows.Forms.FlowLayoutPanel flpControlesReproductor = null!;
        private System.Windows.Forms.Button btnPausarReanudar = null!;
        private System.Windows.Forms.Button btnDetener = null!;
        private System.Windows.Forms.DataGridView dgvCola = null!;
        private System.Windows.Forms.Label lblEstadisticas = null!;

        // ---- Panel inferior: benchmark y telemetría ----
        private System.Windows.Forms.GroupBox grpBenchmark = null!;
        private System.Windows.Forms.Panel pnlBenchmarkTop = null!;
        private System.Windows.Forms.Label lblCantidad = null!;
        private System.Windows.Forms.NumericUpDown numCantidadBenchmark = null!;
        private System.Windows.Forms.Button btnBenchmark = null!;
        private System.Windows.Forms.TextBox txtResultadosBenchmark = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.grpRegistro = new System.Windows.Forms.GroupBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblArtista = new System.Windows.Forms.Label();
            this.txtArtista = new System.Windows.Forms.TextBox();
            this.lblBpm = new System.Windows.Forms.Label();
            this.numBpm = new System.Windows.Forms.NumericUpDown();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.numDuracion = new System.Windows.Forms.NumericUpDown();
            this.lblModo = new System.Windows.Forms.Label();
            this.rbPropia = new System.Windows.Forms.RadioButton();
            this.rbLinkedList = new System.Windows.Forms.RadioButton();
            this.rbList = new System.Windows.Forms.RadioButton();
            this.btnCargarAudio = new System.Windows.Forms.Button();
            this.lblArchivoSeleccionado = new System.Windows.Forms.Label();
            this.openFileDialogAudio = new System.Windows.Forms.OpenFileDialog();

            this.pnlMiddle = new System.Windows.Forms.Panel();

            this.grpAcciones = new System.Windows.Forms.GroupBox();
            this.flpAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEncolarFinal = new System.Windows.Forms.Button();
            this.btnReproducirSiguiente = new System.Windows.Forms.Button();
            this.btnAvanzar = new System.Windows.Forms.Button();
            this.btnInvertir = new System.Windows.Forms.Button();
            this.btnOrdenarBpm = new System.Windows.Forms.Button();
            this.btnPurgar = new System.Windows.Forms.Button();

            this.grpPlaylist = new System.Windows.Forms.GroupBox();
            this.pnlNowPlaying = new System.Windows.Forms.Panel();
            this.lblNowPlaying = new System.Windows.Forms.Label();
            this.flpControlesReproductor = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPausarReanudar = new System.Windows.Forms.Button();
            this.btnDetener = new System.Windows.Forms.Button();
            this.dgvCola = new System.Windows.Forms.DataGridView();
            this.lblEstadisticas = new System.Windows.Forms.Label();

            this.grpBenchmark = new System.Windows.Forms.GroupBox();
            this.pnlBenchmarkTop = new System.Windows.Forms.Panel();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numCantidadBenchmark = new System.Windows.Forms.NumericUpDown();
            this.btnBenchmark = new System.Windows.Forms.Button();
            this.txtResultadosBenchmark = new System.Windows.Forms.TextBox();

            ((System.ComponentModel.ISupportInitialize)(this.numBpm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuracion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCola)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadBenchmark)).BeginInit();
            this.grpRegistro.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.grpAcciones.SuspendLayout();
            this.flpAcciones.SuspendLayout();
            this.grpPlaylist.SuspendLayout();
            this.pnlNowPlaying.SuspendLayout();
            this.flpControlesReproductor.SuspendLayout();
            this.grpBenchmark.SuspendLayout();
            this.pnlBenchmarkTop.SuspendLayout();
            this.SuspendLayout();

            // ================= grpRegistro =================
            this.grpRegistro.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRegistro.Height = 118;
            this.grpRegistro.Text = "Panel Superior: Registro de Pista";
            this.grpRegistro.Controls.Add(this.lblTitulo);
            this.grpRegistro.Controls.Add(this.txtTitulo);
            this.grpRegistro.Controls.Add(this.lblArtista);
            this.grpRegistro.Controls.Add(this.txtArtista);
            this.grpRegistro.Controls.Add(this.lblBpm);
            this.grpRegistro.Controls.Add(this.numBpm);
            this.grpRegistro.Controls.Add(this.lblDuracion);
            this.grpRegistro.Controls.Add(this.numDuracion);
            this.grpRegistro.Controls.Add(this.lblModo);
            this.grpRegistro.Controls.Add(this.rbPropia);
            this.grpRegistro.Controls.Add(this.rbLinkedList);
            this.grpRegistro.Controls.Add(this.rbList);
            this.grpRegistro.Controls.Add(this.btnCargarAudio);
            this.grpRegistro.Controls.Add(this.lblArchivoSeleccionado);

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(15, 32);
            this.lblTitulo.Text = "Título:";

            this.txtTitulo.Location = new System.Drawing.Point(70, 29);
            this.txtTitulo.Size = new System.Drawing.Size(180, 23);

            this.lblArtista.AutoSize = true;
            this.lblArtista.Location = new System.Drawing.Point(268, 32);
            this.lblArtista.Text = "Artista:";

            this.txtArtista.Location = new System.Drawing.Point(325, 29);
            this.txtArtista.Size = new System.Drawing.Size(180, 23);

            this.lblBpm.AutoSize = true;
            this.lblBpm.Location = new System.Drawing.Point(522, 32);
            this.lblBpm.Text = "BPM:";

            this.numBpm.Location = new System.Drawing.Point(562, 29);
            this.numBpm.Size = new System.Drawing.Size(65, 23);
            this.numBpm.Minimum = 60;
            this.numBpm.Maximum = 220;
            this.numBpm.Value = 124;
            this.numBpm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(642, 32);
            this.lblDuracion.Text = "Duración (s):";

            this.numDuracion.Location = new System.Drawing.Point(745, 29);
            this.numDuracion.Size = new System.Drawing.Size(75, 23);
            this.numDuracion.Minimum = 1;
            this.numDuracion.Maximum = 7200;
            this.numDuracion.Value = 210;
            this.numDuracion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            this.lblModo.AutoSize = true;
            this.lblModo.Location = new System.Drawing.Point(15, 72);
            this.lblModo.Text = "Modo de Estructura:";

            this.rbPropia.AutoSize = true;
            this.rbPropia.Checked = true;
            this.rbPropia.Location = new System.Drawing.Point(180, 70);
            this.rbPropia.TabStop = true;
            this.rbPropia.Text = "Lista Simple Propia (Nodos)";
            this.rbPropia.CheckedChanged += new System.EventHandler(this.EstructuraSeleccionada_CheckedChanged);

            this.rbLinkedList.AutoSize = true;
            this.rbLinkedList.Location = new System.Drawing.Point(400, 70);
            this.rbLinkedList.Text = ".NET LinkedList<T>";
            this.rbLinkedList.CheckedChanged += new System.EventHandler(this.EstructuraSeleccionada_CheckedChanged);

            this.rbList.AutoSize = true;
            this.rbList.Location = new System.Drawing.Point(570, 70);
            this.rbList.Text = ".NET List<T>";
            this.rbList.CheckedChanged += new System.EventHandler(this.EstructuraSeleccionada_CheckedChanged);

            this.btnCargarAudio.Location = new System.Drawing.Point(835, 27);
            this.btnCargarAudio.Size = new System.Drawing.Size(150, 25);
            this.btnCargarAudio.Text = "📂 Cargar Audio";
            this.btnCargarAudio.UseVisualStyleBackColor = true;
            this.btnCargarAudio.Click += new System.EventHandler(this.btnCargarAudio_Click);

            this.lblArchivoSeleccionado.AutoSize = false;
            this.lblArchivoSeleccionado.Location = new System.Drawing.Point(835, 68);
            this.lblArchivoSeleccionado.Size = new System.Drawing.Size(280, 32);
            this.lblArchivoSeleccionado.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblArchivoSeleccionado.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblArchivoSeleccionado.Text = "(sin archivo de audio seleccionado)";

            this.openFileDialogAudio.Filter = "Archivos de audio (*.mp3;*.wav;*.wma;*.mp4;*.m4a)|*.mp3;*.wav;*.wma;*.mp4;*.m4a|Todos los archivos (*.*)|*.*";
            this.openFileDialogAudio.Title = "Selecciona un archivo de audio para la pista";

            // ================= grpAcciones =================
            this.grpAcciones.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpAcciones.Width = 235;
            this.grpAcciones.Text = "Acciones de Cola";
            this.grpAcciones.Controls.Add(this.flpAcciones);

            this.flpAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAcciones.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAcciones.WrapContents = false;
            this.flpAcciones.Padding = new System.Windows.Forms.Padding(10);
            this.flpAcciones.Controls.Add(this.btnEncolarFinal);
            this.flpAcciones.Controls.Add(this.btnReproducirSiguiente);
            this.flpAcciones.Controls.Add(this.btnAvanzar);
            this.flpAcciones.Controls.Add(this.btnInvertir);
            this.flpAcciones.Controls.Add(this.btnOrdenarBpm);
            this.flpAcciones.Controls.Add(this.btnPurgar);

            this.btnEncolarFinal.Text = "➕ Encolar al Final";
            this.btnReproducirSiguiente.Text = "⏭ Reproducir Siguiente";
            this.btnAvanzar.Text = "⏩ Avanzar Pista";
            this.btnInvertir.Text = "⇅ Invertir Lista (In-Place)";
            this.btnOrdenarBpm.Text = "⚡ Ordenar por Curva BPM";
            this.btnPurgar.Text = "🧹 Purgar Duplicados";

            foreach (var boton in new[] { this.btnEncolarFinal, this.btnReproducirSiguiente, this.btnAvanzar,
                                           this.btnInvertir, this.btnOrdenarBpm, this.btnPurgar })
            {
                boton.Size = new System.Drawing.Size(200, 42);
                boton.Margin = new System.Windows.Forms.Padding(4);
                boton.UseVisualStyleBackColor = true;
            }

            this.btnEncolarFinal.Click += new System.EventHandler(this.btnEncolarFinal_Click);
            this.btnReproducirSiguiente.Click += new System.EventHandler(this.btnReproducirSiguiente_Click);
            this.btnAvanzar.Click += new System.EventHandler(this.btnAvanzar_Click);
            this.btnInvertir.Click += new System.EventHandler(this.btnInvertir_Click);
            this.btnOrdenarBpm.Click += new System.EventHandler(this.btnOrdenarBpm_Click);
            this.btnPurgar.Click += new System.EventHandler(this.btnPurgar_Click);

            // ================= grpPlaylist =================
            this.grpPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPlaylist.Text = "Playlist Visual / Cola en Vivo";
            this.grpPlaylist.Controls.Add(this.dgvCola);
            this.grpPlaylist.Controls.Add(this.lblEstadisticas);
            this.grpPlaylist.Controls.Add(this.pnlNowPlaying);

            this.pnlNowPlaying.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNowPlaying.Height = 40;
            this.pnlNowPlaying.Controls.Add(this.lblNowPlaying);
            this.pnlNowPlaying.Controls.Add(this.flpControlesReproductor);

            this.lblNowPlaying.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNowPlaying.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNowPlaying.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblNowPlaying.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNowPlaying.Text = "▶ Reproduciendo: (ninguna pista en curso)";

            this.flpControlesReproductor.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpControlesReproductor.Width = 240;
            this.flpControlesReproductor.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpControlesReproductor.Controls.Add(this.btnDetener);
            this.flpControlesReproductor.Controls.Add(this.btnPausarReanudar);

            this.btnDetener.Size = new System.Drawing.Size(90, 30);
            this.btnDetener.Margin = new System.Windows.Forms.Padding(3, 5, 6, 3);
            this.btnDetener.Text = "⏹ Detener";
            this.btnDetener.Enabled = false;
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);

            this.btnPausarReanudar.Size = new System.Drawing.Size(110, 30);
            this.btnPausarReanudar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btnPausarReanudar.Text = "⏸ Pausar";
            this.btnPausarReanudar.Enabled = false;
            this.btnPausarReanudar.UseVisualStyleBackColor = true;
            this.btnPausarReanudar.Click += new System.EventHandler(this.btnPausarReanudar_Click);

            this.dgvCola.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCola.AllowUserToAddRows = false;
            this.dgvCola.AllowUserToDeleteRows = false;
            this.dgvCola.AllowUserToResizeRows = false;
            this.dgvCola.ReadOnly = true;
            this.dgvCola.RowHeadersVisible = false;
            this.dgvCola.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCola.MultiSelect = false;
            this.dgvCola.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCola.BackgroundColor = System.Drawing.SystemColors.Window;

            this.lblEstadisticas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblEstadisticas.Height = 26;
            this.lblEstadisticas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEstadisticas.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblEstadisticas.Text = "Total en cola: 0 | Tiempo total: 00:00";

            // ================= pnlMiddle =================
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Controls.Add(this.grpPlaylist);
            this.pnlMiddle.Controls.Add(this.grpAcciones);

            // ================= grpBenchmark =================
            this.grpBenchmark.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpBenchmark.Height = 210;
            this.grpBenchmark.Text = "Panel de Benchmark y Telemetría";
            this.grpBenchmark.Controls.Add(this.txtResultadosBenchmark);
            this.grpBenchmark.Controls.Add(this.pnlBenchmarkTop);

            this.pnlBenchmarkTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBenchmarkTop.Height = 44;
            this.pnlBenchmarkTop.Controls.Add(this.lblCantidad);
            this.pnlBenchmarkTop.Controls.Add(this.numCantidadBenchmark);
            this.pnlBenchmarkTop.Controls.Add(this.btnBenchmark);

            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(12, 14);
            this.lblCantidad.Text = "Cantidad de pistas para test de estrés:";

            this.numCantidadBenchmark.Location = new System.Drawing.Point(300, 11);
            this.numCantidadBenchmark.Size = new System.Drawing.Size(100, 23);
            this.numCantidadBenchmark.Minimum = 100;
            this.numCantidadBenchmark.Maximum = 1000000;
            this.numCantidadBenchmark.Increment = 1000;
            this.numCantidadBenchmark.ThousandsSeparator = true;
            this.numCantidadBenchmark.Value = 25000;
            this.numCantidadBenchmark.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            this.btnBenchmark.Location = new System.Drawing.Point(415, 8);
            this.btnBenchmark.Size = new System.Drawing.Size(250, 30);
            this.btnBenchmark.Text = "🚀 Iniciar Prueba de Rendimiento";
            this.btnBenchmark.UseVisualStyleBackColor = true;
            this.btnBenchmark.Click += new System.EventHandler(this.btnBenchmark_Click);

            this.txtResultadosBenchmark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResultadosBenchmark.Multiline = true;
            this.txtResultadosBenchmark.ReadOnly = true;
            this.txtResultadosBenchmark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultadosBenchmark.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtResultadosBenchmark.BackColor = System.Drawing.SystemColors.Window;

            // ================= MainForm =================
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1150, 760);
            this.MinimumSize = new System.Drawing.Size(1050, 680);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SoundCore Engine v2.0 - DJ Set Controller [TecNM Monclova]";
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.grpBenchmark);
            this.Controls.Add(this.grpRegistro);

            ((System.ComponentModel.ISupportInitialize)(this.numBpm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuracion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCola)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadBenchmark)).EndInit();
            this.grpRegistro.ResumeLayout(false);
            this.grpRegistro.PerformLayout();
            this.flpAcciones.ResumeLayout(false);
            this.grpAcciones.ResumeLayout(false);
            this.flpControlesReproductor.ResumeLayout(false);
            this.pnlNowPlaying.ResumeLayout(false);
            this.grpPlaylist.ResumeLayout(false);
            this.pnlBenchmarkTop.ResumeLayout(false);
            this.pnlBenchmarkTop.PerformLayout();
            this.grpBenchmark.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
