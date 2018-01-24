using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Fusion_fichiers
{
    public partial class FormAccueil : Form
    {
        public FormAccueil()
        {
            InitializeComponent();
        }
        // Déclaration des variables:
        FolderBrowserDialog FB = new FolderBrowserDialog();
        int ligneFichierFinal;
        FileInfo Folder;
        StringCollection collection = new StringCollection();
        StringCollection SC;

        /// <summary>
        /// Evenement appelé au clic sur le bouton parcourir.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnParcourir_Click(object sender, EventArgs e)
        {
            //Déclaration du dossier source de la boite de dialogue de sélection de dossier
            FB.RootFolder = Environment.SpecialFolder.Desktop;

            ///Apres validation de la boite de dialogue
            if (FB.ShowDialog() == DialogResult.OK)
            {
                //Nettoyage de la datagrid (utile lors du second passage
                if (dataGridFiles.Columns.Count != 0)
                {
                    dataGridFiles.Columns.Clear();
                }

                //Récupération des informations de dossier
                Folder = new FileInfo(FB.SelectedPath);
                SC = new StringCollection();
                string workFolder = Folder.FullName;
                SC = ListAllFiles(SC, workFolder, false);

                //Vérification du nombre de fichiers trouvés
                if (SC.Count==0)
                {
                    MessageBox.Show("aucun fichier correspondant dans le dossier sélectionné" + "\n" + "Rappel les fichiers utilisables sont .txt et .csv", "Erreur fichier", MessageBoxButtons.OK, MessageBoxIcon.Error) ;                
                    return;
                    
                }

                //création de la collection contenant le texte
                StringCollection lineCollection = new StringCollection();

                //création de la DataTable et ajout des colonnes
                DataTable DT = new DataTable();
                DT.Columns.Add(new DataColumn("Fichier", typeof(string)));
                DT.Columns.Add(new DataColumn("Nb lignes", typeof(string)));
                DataRow DR = null;

                //Création de la colonne contenant la case de sélection
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                {
                    Name = "colSel",
                    HeaderText = "Choisir",
                    Width = 30,
                    ReadOnly = false,
                    FillWeight = 10
                };

                //Déclaration des variables de largeur des colonnes
                int largColFichier = 0;
                int largColLignes = 0;

                //Parcourt des lignes pour adapter la taille de la dataGrid
                foreach (string fichier in SC)
                {
                    //contrôle de la présence de texte dans la ligne
                    if (fichier != "")
                    {
                        //récupération du nombre de ligne à écrire
                        int lineNb = LineCount(fichier);
                        DR = DT.NewRow();

                        //découpe de la chaine pour éviter les noms de dossiers trop long
                        int coupe = FB.SelectedPath.Length;

                        //remplissage des cellules
                        DR[0] = fichier.Substring(coupe + 1);
                        DR[1] = lineNb;

                        //Récupération de chaines les plus longues pour le nom de fichier et nombre de lignes
                        if (Convert.ToInt32(TextRenderer.MeasureText(fichier + lineNb.ToString(), SystemFonts.DefaultFont).Width) > largColFichier)
                        {
                            largColFichier = Convert.ToInt32(TextRenderer.MeasureText(fichier + lineNb.ToString(), SystemFonts.DefaultFont).Width);
                        }
                        if (Convert.ToInt32(TextRenderer.MeasureText(lineNb.ToString(), SystemFonts.DefaultFont).Width) > largColLignes)
                        {
                            largColLignes = Convert.ToInt32(TextRenderer.MeasureText( lineNb.ToString(), SystemFonts.DefaultFont).Width);
                        }
                    }
                    DT.Rows.Add(DR);
                }
                //Affichage de la grid et du bouton 
                panelGrid.Visible = true;
                btnChoisir.Visible = true;
                dataGridFiles.Columns.Add(checkColumn);
                dataGridFiles.DataSource = DT;
                dataGridFiles.Columns["Fichier"].Width = (largColFichier-50 );
                dataGridFiles.Columns["Nb lignes"].Width = largColLignes+10;

                int colWidth = 0;

                //parcourt des colonnes pour adapter la taille
                foreach (DataGridViewColumn item in dataGridFiles.Columns)
                {
                    colWidth += item.Width;
                }

                int rowHeight = dataGridFiles.ColumnHeadersHeight;

                foreach (DataGridViewRow item in dataGridFiles.Rows)
                {
                    rowHeight += item.Height;
                }
                dataGridFiles.Width = colWidth + 11;

                panelGrid.Width = colWidth;
                //adaptation de la taille de la DT si le nombre n'est pas trop important
                if (dataGridFiles.Rows.Count<30)
                {
                    dataGridFiles.Height = rowHeight + 5;
                    panelGrid.Height = rowHeight + 5;
                }
                else // au dela adaptation du form à la taille disponible a l'écran
                {
                    this.Top = 0;             
                    int size = Screen.GetWorkingArea(new Point(0,0)).Height;
                    this.AutoSize = false;
                    this.Height = size;
                    panelGrid.Height = size - 200;
                    dataGridFiles.Height = size - 220;
                }

                btnChoisir.Visible = true;

                //Création du tableau de chaine de sortie
                string[] output = new string[lineCollection.Count];
                //remplissage du tableau
                for (int i = 0; i < lineCollection.Count; i++)
                {
                    output[i] = lineCollection[i];
                }
                this.Top = 0;
            }
        }

        /// <summary>
        /// Evenement appelé au clic sur le bouton quitter ferme la fenêtre.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evenement appelé au clic sur le bouton choisir .
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnChoisir_Click(object sender, EventArgs e)
        {
            
            this.AutoSize = true;
            int nbLignes = 0;
            //nettoyage du panel 
            flowPanelOrdre.Controls.Clear();
            //parcourt de la DataGrid ligne par ligne
            foreach (DataGridViewRow row in dataGridFiles.Rows)
            {
                //récupération de la cellule de sélection
                DataGridViewCheckBoxCell cell = row.Cells["colSel"] as DataGridViewCheckBoxCell;
                //récupération des éléments sélectionnés
                if (cell.Value is true)
                {
                    collection.Add(row.Cells["Fichier"].Value.ToString());
                    nbLignes = nbLignes + Convert.ToInt32(row.Cells["Nb lignes"].Value);
                }
            }

            //récupération du nombre de ligne total pour contrôle
            ligneFichierFinal = nbLignes;

            //Vérification du nombre d'éléments
            if (collection.Count<2)
            {
                MessageBox.Show("Erreur merci de sélectionner au moins 2 fichiers","Erreur sélection",MessageBoxButtons.OK,MessageBoxIcon.Error);
                collection.Clear();
                return;
            }

            //Création de la collection contenant le fichier de sortie
            StringCollection sortie = new StringCollection();

            //déclaration et attribution des variables de nom et dossier
            string lesNoms = "";
            string folder = FB.SelectedPath + "\\";

            //parcourt de la collection
            foreach (string item in collection)
            {
                //ajout des nom a la chaine
                lesNoms += item + "\n";
                //remplissage du fichier de sortie
                foreach (string str in File.ReadAllLines(folder + item))
                {
                    if (str != string.Empty)
                    {
                        sortie.Add(str);
                    }
                }
            }
            PanelCreate(folder);
            btnChoisir.Visible = false;
            panelGrid.Visible = false;            
        }

        /// <summary>
        /// Gets the combo.
        /// </summary>
        /// <returns>retourne la liste des comboBox</returns>
        List<string> GetCombo()
        {
            //Création de la liste de chaines
            List<string> laListe = new List<string>();
            //récupération des controls
            var controls = this.Controls;
            //parcourt des comboBox et ajout en liste
            foreach (ComboBox item in flowPanelOrdre.Controls)
            {
                laListe.Add(item.Name);
            }
            return laListe;
        }

        /// <summary>
        /// creation du panel contenant les combobox.
        /// </summary>
        /// <param name="folder">The folder.</param>
        private void PanelCreate(string folder)
        {
            //creation des panel et label
            Panel panelNom = new Panel();
            Label labelNom = new Label
            {
                Text = "Veuillez entrer un nom pour votre fichier :",
                Top = 0,
                AutoSize = true
            };
            this.flowNom.Controls.Add(labelNom);

            //creation de la textbox pour l'entrée du nom
            TextBox textNom = new TextBox
            {
                Top = labelNom.Bottom + 10,
                Name = "tBx_Nom"
            };

            this.flowNom.Controls.Add(textNom);

            //parcourt de la collection pour création des comboBox
            for (int i = 0; i < collection.Count; i++)
            {
                //Création d'un flowLayoutPanel pour placer les éléments
                FlowLayoutPanel flowBox = new FlowLayoutPanel
                {
                    Name = "flowBox",
                    FlowDirection = FlowDirection.TopDown,
                    AutoSize = true
                };
                //création des label pour la position
                Label labelOrdre = new Label
                {
                    Text = (i + 1).ToString(),
                    Name = "label-" + i,
                    Width = 20
                };
                flowBox.Controls.Add(labelOrdre);
                //création des combobox contenant les fichiers
                ComboBox laBox = new ComboBox
                {
                    Name = "box-" + i
                };
                flowBox.Controls.Add(laBox);
                //ajout des élément a la comboBox
                for (int j = 0; j < collection.Count; j++)
                {
                    laBox.BindingContext = new BindingContext();
                    laBox.DataSource = collection;
                }
                flowPanelOrdre.Controls.Add(flowBox);

            }

            //Création du bouton valider
            Button btn = new Button
            {
                Text = "Valider",
                Name = "btnValider"
            };

            this.flowPanelOrdre.Controls.Add(btn);
            this.flowPanelOrdre.AutoSize = true;
           
            //création de l'évenement au click
            btn.Click += new EventHandler(Valider_Click);
        }


        /// <summary>
        /// Evenement au clic sur le bouton valider.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Valider_Click(object sender, EventArgs e)
        {
            //affichage d'un message si le nom est vide
            if (this.Controls.Find("tBx_Nom",true)[0].Text==string.Empty)
            {
                MessageBox.Show("Erreur le nom de fichier ne peut être vide","Erreur nom de fichier",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            //déclaration des variables 
            int nb = collection.Count;
            string sortie = "";
            string[] ctrl = new string[nb];
            
            //récupération du tableau de controles
            Control[] leControl = flowPanelOrdre.Controls.Find("flowbox",true);

            //parcourt du tableau
            for (int k = 0; k < leControl.Count(); k++)
            {
                for (int l = 0; l < leControl[k].Controls.Count; l++)
                {
                    //vérification de l'élément
                    if (leControl[k].Controls[l] is ComboBox)
                    {
                        //récupération de l'index de la comboBox
                        int leNb =Convert.ToInt32( leControl[k].Controls[l].Name.Substring(4,1));
                        ComboBox item = (ComboBox)leControl[k].Controls[l];
                        //attribution a la position de la comboBox de l'élément contenu dans celle ci
                        ctrl[leNb] = item.SelectedItem.ToString();
                    }

                }

            }

           
        
            //boucle de vérification des éléments choisi en comboBox
            for (int x = 0; x < nb; x++)
            {
                for (int y = 0; y < nb; y++)
                {
                    //en cas d'égalité affichage d'un message demandant de modifier la sélection
                    if (ctrl[x] == ctrl[y] && x != y)
                    {
                        MessageBox.Show("Merci de sélectionner des fichiers différents dans chacune des liste déroulantes !", "Erreur de sélection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            }

            //Parcourt de la collection
            for (int x = 0; x < collection.Count; x++)
            {
                //récupération de la comboBox
                Control laBox = this.Controls.Find("box-"+x, true)[0];
                //récupération du premier élément
                if (x==0)
                {
                    sortie = (laBox as ComboBox).SelectedItem.ToString();
                }
                else
                {
                    sortie+=";"+ (laBox as ComboBox).SelectedItem.ToString();
                }
            }
            //récupération des info de l'élément
            FileInfo FI = new FileInfo(collection[0]);
            //récupértion du nom entrée dans la textBox
            string nom = this.Controls.Find("tBx_Nom",true)[0].Text;
            //Appel de l'outil d'écriture et formatage du fichier de sortie
            if (EcritFichiers(sortie, nb, FB.SelectedPath, nom))
            {
                //création de la chaine d'affichage de confirmation
                string texte = "Fichier enregistré :" + "\n" + FB.SelectedPath + "\\" + nom + FI.Extension + "\n" + "Avez-vous d'autres fichiers à fusionner?";
                //demande si terminé
                if (MessageBox.Show(texte, "Traitement terminé", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    collection.Clear();
                    FB.Dispose();
                    flowPanelOrdre.Controls.Clear();
                    flowPanelOrdre.Refresh();

                }
                else this.Close(); 
            }
        }

        /// <summary>
        /// Ecrits the fichiers.
        /// </summary>
        /// <param name="lesFichiers">les fichiers à assembler.</param>
        /// <param name="nb">la quantité de fichier (pour contrôle).</param>
        /// <param name="folder">le dossier d'origine.</param>
        /// <param name="nom">le nom entré.</param>
        /// <returns>Vrai ou faux en fonction de la réussite de l'écriture du fichier</returns>
        bool EcritFichiers(string lesFichiers,int nb,string folder,string nom)
        {
            string[] noms = lesFichiers.Split(';');
            if (noms.Count()!=nb)
            {
                MessageBox.Show("Erreur de quantité de fichiers importés","Erreur d'importation",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            else
            {
                string ext = noms[0].Substring(noms[0].Length - 4);
                StreamWriter SW = new StreamWriter(folder+"\\"+nom+ext, true);
                string[] output = new string[ligneFichierFinal];
                foreach (string item in noms)
                {
                    string adress = folder + "\\" + item ;
                    
                    FileInfo FI = new FileInfo(item);
                    string[] sortie=File.ReadAllLines(adress);
                    for (int i = 0; i < sortie.Count(); i++)
                    {
                        SW.Write(sortie[i]);
                        SW.WriteLine();
                    }
                }
                SW.Close();
                return true;
            }
        }


        public static StringCollection ListAllFiles(StringCollection allFiles, string path, bool scanDirOk)
        {
            // listFilesCurrDir : Tableau contenant  la liste des fichiers du dossier 'path'
            var listFilesCurrDir = Directory.GetFiles(path, "*.*").Where(s => s.EndsWith(".txt") || s.EndsWith(".csv"));

            // On lit le tableau 'listFilesCurrDir' 
            foreach (string rowFile in listFilesCurrDir)
            {
                // Si le fichier n'est pas deja dans la liste 'allFiles'
                if (allFiles.Contains(rowFile) == false)
                {
                    // On ajoute le fichier (du moins son adresse) a 'allFiles'
                    allFiles.Add(rowFile);
                }
            }
            // Vide la table 'listFilesCurrDir'pour la prochaine liste de sous-dossiers
            listFilesCurrDir = null;

            // Si on autorise la lecture des sous-dossiers
            if (scanDirOk)
            {
                // On liste tous les sous-dossiers présents dans le 'path'
                string[] listDirCurrDir = Directory.GetDirectories(path);

                // Si il existe des sous-dossiers (si la liste n'est pas vide)
                if (listDirCurrDir.Length != 0)
                {
                    // On lit le tableau 'listDirCurrDir'
                    foreach (string rowDir in listDirCurrDir)
                    {
                        // On relance la procédure pour qu'elle scanne chaque sous-dossier
                        ListAllFiles(allFiles, rowDir, scanDirOk);
                    }
                }
                // Vide la table 'listDirCurrDir'pour la prochaine liste de sous-dossiers
                listDirCurrDir = null;

            }
            // On retourne 'allFiles'
            return allFiles;
        }

        int LineCount(string filePath)
        {
            StringCollection collection = new StringCollection();
            int nb = File.ReadAllLines(filePath).Count();
            foreach (string item in File.ReadAllLines(filePath))
            {
                if (item == "")
                {
                    nb--;
                }
            }
            return nb;
        }
    }
}
