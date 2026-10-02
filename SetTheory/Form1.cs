using Main;

namespace SetTheory
{
    public partial class Form1 : Form
    {
        // ---------- Campos ----------
        private readonly GestionConjuntos gestion = new GestionConjuntos();
        private readonly GestionOperadores operadores = new GestionOperadores();
        private readonly DiagramaVenn diagrama = new DiagramaVenn();
        private Conjunto conjuntoActual;          // el conjunto (o universo) seleccionado
        private bool diagramaGenerado = false;

        public Form1()
        {
            InitializeComponent();

            // Botones de operaciones
            btnUnion.Click += (s, e) => Aplicar(operadores.OperadorUnion);
            btnInterseccion.Click += (s, e) => Aplicar(operadores.OperadorInterseccion);
            btnDiff1.Click += (s, e) => Aplicar(operadores.OperadorDiferenciaAB);
            btnDiff2.Click += (s, e) => Aplicar(operadores.OperadorDiferenciaBA);
            btnDiffSim.Click += (s, e) => Aplicar(operadores.OperadorDiferenciaSimetrica);
            btnClean.Click += (s, e) => Aplicar(operadores.Limpiar);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            formsPlot1.Plot.HideAxesAndGrid();
            formsPlot1.Refresh();

            CrearRadio(gestion.AddNewSet());   // A
            CrearRadio(gestion.AddNewSet());   // B
            CrearRadio(gestion.Universo);      // Universo

            // Marcar el primero dispara Radio_CheckedChanged (elementos + color)
            ((RadioButton)flpanel1.Controls[0]).Checked = true;
        }

        // ---------- Radios ----------
        private void CrearRadio(Conjunto conjunto)
        {
            RadioButton rb = new RadioButton();
            rb.Text = conjunto.Nombre;
            rb.AutoSize = true;
            rb.Tag = conjunto;
            rb.CheckedChanged += Radio_CheckedChanged;
            flpanel1.Controls.Add(rb);
        }

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (!rb.Checked) return;

            conjuntoActual = (Conjunto)rb.Tag;
            MostrarElementos();
            MostrarColor();
        }

        // Borra todos los radios y los recrea desde gestion
        private void RehacerRadios()
        {
            foreach (RadioButton rb in flpanel1.Controls.OfType<RadioButton>().ToList())
                rb.Dispose();
            flpanel1.Controls.Clear();
            conjuntoActual = null;

            foreach (Conjunto c in gestion.Conjuntos)
                CrearRadio(c);
            CrearRadio(gestion.Universo);

            ((RadioButton)flpanel1.Controls[0]).Checked = true;
        }

        // ---------- Elementos ----------
        // Único lugar que escribe en el ListBox
        private void MostrarElementos()
        {
            lbElements.Items.Clear();
            foreach (string el in conjuntoActual.Elementos)
                lbElements.Items.Add(el);

            ActualizarElementos();
        }

        public void ActualizarElementos()
        {
            if (conjuntoActual == null) return;
            lblElemento.Text = $"Elementos del {conjuntoActual.Nombre}: {conjuntoActual.Elementos.Count}";
        }

        private void MostrarColor()
        {
            if (conjuntoActual == null) return;

            ColorA.BackColor = conjuntoActual.Color;
        }

        // Redibuja el diagrama solo si ya se había generado
        private void RedibujarSiHaceFalta()
        {
            if (!diagramaGenerado) return;
            diagrama.Dibujar(formsPlot1.Plot, gestion.Conjuntos, gestion.Universo, operadores.Actual);
            formsPlot1.Refresh();
        }

        // ---------- Operaciones ----------
        // Selecciona la operación y redibuja con el resaltado
        private void Aplicar(Action seleccionar)
        {
            if (!diagramaGenerado)
            {
                MessageBox.Show("Primero genera el diagrama.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            seleccionar();
            RedibujarSiHaceFalta();
        }

        // ---------- Botones ----------
        // "+" junto al cuadro de texto
        private void btnAddElement_Click(object sender, EventArgs e)
        {
            if (conjuntoActual == null) return;

            if (conjuntoActual.AgregarElemento(txtElemento.Text))
            {
                txtElemento.Clear();
                MostrarElementos();
            }
            else
            {
                MessageBox.Show("El elemento está vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // "X": elimina el elemento seleccionado en el ListBox
        private void btnDeleteElemento_Click(object sender, EventArgs e)
        {
            if (conjuntoActual == null) return;
            if (lbElements.SelectedItem == null) return;

            conjuntoActual.EliminarElemento(lbElements.SelectedItem.ToString());
            MostrarElementos();
        }

        // "Agregar" conjunto nuevo
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Conjunto nuevo = gestion.AddNewSet();
            if (nuevo == null)
            {
                MessageBox.Show("Alcanzaste el máximo de 4 conjuntos.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // El universo debe quedar siempre al final: rehago los radios
            RehacerRadios();
            RedibujarSiHaceFalta();
        }

        // "Eliminar" conjunto
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (conjuntoActual == null) return;

            if (conjuntoActual == gestion.Universo)
            {
                MessageBox.Show("El universo no se puede eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var respuesta = MessageBox.Show(
                $"¿Eliminar {conjuntoActual.Nombre} y todos sus elementos?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            if (!gestion.DeleteSet(conjuntoActual))
            {
                MessageBox.Show("Debe haber al menos 2 conjuntos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RehacerRadios();
            RedibujarSiHaceFalta();
        }

        // "Color"
        private void btnColor_Click(object sender, EventArgs e)
        {
            if (conjuntoActual == null) return;

            using var dialogo = new ColorDialog();
            dialogo.Color = conjuntoActual.Color;

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                gestion.SetColor(conjuntoActual, dialogo.Color);
                MostrarColor();
                RedibujarSiHaceFalta();
            }
        }

        // "Generar Diagrama"
        private void btnDiagram_Click(object sender, EventArgs e)
        {
            if (gestion.Conjuntos.Count < 2)
            {
                MessageBox.Show("Necesitas al menos 2 conjuntos para generar el diagrama.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            formsPlot1.Visible = true;
            diagramaGenerado = true;
            RedibujarSiHaceFalta();
        }

        // "Exportar PNG"
        private void btnPng_Click(object sender, EventArgs e)
        {
            if (!diagramaGenerado)
            {
                MessageBox.Show("Primero genera el diagrama.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dialogo = new SaveFileDialog();
            dialogo.Filter = "Imagen PNG (*.png)|*.png";
            dialogo.FileName = "diagrama_venn.png";

            if (dialogo.ShowDialog() != DialogResult.OK) return;

            try
            {
                formsPlot1.Plot.SavePng(dialogo.FileName, 1200, 900);
                MessageBox.Show("Diagrama exportado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la imagen:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}