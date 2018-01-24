namespace Fusion_fichiers
{
    partial class FormAccueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccueil));
            this.dataGridFiles = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnParcourir = new System.Windows.Forms.Button();
            this.flowLayoutPanelComplet = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSource = new System.Windows.Forms.Panel();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowNom = new System.Windows.Forms.FlowLayoutPanel();
            this.flowPanelOrdre = new System.Windows.Forms.FlowLayoutPanel();
            this.panelBoutons = new System.Windows.Forms.Panel();
            this.btnChoisir = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFiles)).BeginInit();
            this.flowLayoutPanelComplet.SuspendLayout();
            this.panelSource.SuspendLayout();
            this.panelGrid.SuspendLayout();
            this.panelBoutons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridFiles
            // 
            this.dataGridFiles.AllowUserToAddRows = false;
            this.dataGridFiles.AllowUserToDeleteRows = false;
            this.dataGridFiles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFiles.Location = new System.Drawing.Point(3, 3);
            this.dataGridFiles.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridFiles.Name = "dataGridFiles";
            this.dataGridFiles.RowHeadersVisible = false;
            this.dataGridFiles.Size = new System.Drawing.Size(270, 208);
            this.dataGridFiles.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Veuillez sélectionner les fichiers source :";
            // 
            // btnParcourir
            // 
            this.btnParcourir.AutoSize = true;
            this.btnParcourir.Location = new System.Drawing.Point(205, 5);
            this.btnParcourir.Name = "btnParcourir";
            this.btnParcourir.Size = new System.Drawing.Size(68, 24);
            this.btnParcourir.TabIndex = 1;
            this.btnParcourir.Text = "Parcourir...";
            this.btnParcourir.UseVisualStyleBackColor = true;
            this.btnParcourir.Click += new System.EventHandler(this.BtnParcourir_Click);
            // 
            // flowLayoutPanelComplet
            // 
            this.flowLayoutPanelComplet.AutoSize = true;
            this.flowLayoutPanelComplet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelComplet.Controls.Add(this.panelSource);
            this.flowLayoutPanelComplet.Controls.Add(this.panelGrid);
            this.flowLayoutPanelComplet.Controls.Add(this.panel2);
            this.flowLayoutPanelComplet.Controls.Add(this.flowNom);
            this.flowLayoutPanelComplet.Controls.Add(this.flowPanelOrdre);
            this.flowLayoutPanelComplet.Controls.Add(this.panelBoutons);
            this.flowLayoutPanelComplet.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelComplet.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanelComplet.Name = "flowLayoutPanelComplet";
            this.flowLayoutPanelComplet.Size = new System.Drawing.Size(282, 346);
            this.flowLayoutPanelComplet.TabIndex = 3;
            // 
            // panelSource
            // 
            this.panelSource.AutoSize = true;
            this.panelSource.Controls.Add(this.label1);
            this.panelSource.Controls.Add(this.btnParcourir);
            this.panelSource.Location = new System.Drawing.Point(3, 3);
            this.panelSource.Name = "panelSource";
            this.panelSource.Size = new System.Drawing.Size(276, 32);
            this.panelSource.TabIndex = 0;
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.dataGridFiles);
            this.panelGrid.Location = new System.Drawing.Point(3, 41);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(276, 212);
            this.panelGrid.TabIndex = 1;
            this.panelGrid.Visible = false;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Location = new System.Drawing.Point(3, 259);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 0);
            this.panel2.TabIndex = 2;
            // 
            // flowNom
            // 
            this.flowNom.AutoSize = true;
            this.flowNom.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowNom.Location = new System.Drawing.Point(3, 265);
            this.flowNom.Name = "flowNom";
            this.flowNom.Size = new System.Drawing.Size(0, 0);
            this.flowNom.TabIndex = 4;
            // 
            // flowPanelOrdre
            // 
            this.flowPanelOrdre.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelOrdre.Location = new System.Drawing.Point(3, 271);
            this.flowPanelOrdre.Name = "flowPanelOrdre";
            this.flowPanelOrdre.Size = new System.Drawing.Size(273, 29);
            this.flowPanelOrdre.TabIndex = 4;
            // 
            // panelBoutons
            // 
            this.panelBoutons.Controls.Add(this.btnChoisir);
            this.panelBoutons.Controls.Add(this.btnQuitter);
            this.panelBoutons.Location = new System.Drawing.Point(3, 306);
            this.panelBoutons.Name = "panelBoutons";
            this.panelBoutons.Size = new System.Drawing.Size(256, 37);
            this.panelBoutons.TabIndex = 3;
            // 
            // btnChoisir
            // 
            this.btnChoisir.Location = new System.Drawing.Point(3, 4);
            this.btnChoisir.Name = "btnChoisir";
            this.btnChoisir.Size = new System.Drawing.Size(76, 29);
            this.btnChoisir.TabIndex = 0;
            this.btnChoisir.Text = "Choisir";
            this.btnChoisir.UseVisualStyleBackColor = true;
            this.btnChoisir.Visible = false;
            this.btnChoisir.Click += new System.EventHandler(this.BtnChoisir_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.Location = new System.Drawing.Point(177, 4);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(76, 30);
            this.btnQuitter.TabIndex = 1;
            this.btnQuitter.Text = "&Quitter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.BtnQuitter_Click);
            // 
            // FormAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(297, 367);
            this.Controls.Add(this.flowLayoutPanelComplet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAccueil";
            this.Text = "Grouper des fichiers de données";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFiles)).EndInit();
            this.flowLayoutPanelComplet.ResumeLayout(false);
            this.flowLayoutPanelComplet.PerformLayout();
            this.panelSource.ResumeLayout(false);
            this.panelSource.PerformLayout();
            this.panelGrid.ResumeLayout(false);
            this.panelBoutons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnParcourir;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelComplet;
        private System.Windows.Forms.Panel panelSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelBoutons;
        private System.Windows.Forms.Button btnChoisir;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.FlowLayoutPanel flowPanelOrdre;
        public System.Windows.Forms.DataGridView dataGridFiles;
        public System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.FlowLayoutPanel flowNom;
    }
}

