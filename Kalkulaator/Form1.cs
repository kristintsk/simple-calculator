using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulaator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void KT_btnArvuta_Click(object sender, EventArgs e)
        {            
            double esimeneArv; 
            double teineArv; 

            if (double.TryParse(KT_txtArv1.Text, out esimeneArv))
            {
                if (double.TryParse(KT_txtArv2.Text, out teineArv))
                {
                    if (KT_rbLiida.Checked)
                        KT_txtVastus.Text = (esimeneArv + teineArv).ToString();
                    else if (KT_rbLahuta.Checked)
                        KT_txtVastus.Text = (esimeneArv - teineArv).ToString();
                    else if (KT_rbKorruta.Checked)
                        KT_txtVastus.Text = (esimeneArv * teineArv).ToString();
                    else if (KT_rbJaga.Checked)
                        if (teineArv == 0)
                        {
                            // jagamistehte korral tuleb teade selle kohta, et teine arv on 0
                            MessageBox.Show("Nulliga ei saa jagada!");
                            KT_txtArv2.Text = "";
                            KT_txtArv2.Focus();
                        }
                        else
                            KT_txtVastus.Text = (esimeneArv / teineArv).ToString();
                    else
                        MessageBox.Show("Vali tehe!");  // teade, et tehet ei ole valitud                    
                }
                // juhul, kui Parse ei õnnestu (arvu asemel on sisestatud täht, 
                // komaarvus on koma asemel punkt või arv on sisestamata), tuleb selle kohta teade
                else
                {
                    KT_txtArv2.Text = "";
                    KT_txtArv2.Focus();
                    MessageBox.Show("Sisesta korrektne arv (ära kasuta tähti, komakohad eralda koma, mitte punktiga)!");
                }
            }
            else
            {
                KT_txtArv1.Text = "";
                KT_txtArv1.Focus();
                MessageBox.Show("Sisesta korrektne arv (ära kasuta tähti, komakohad eralda koma, mitte punktiga)!");
            }
            }

            // Nupp, mis tühjendab kõik väljad ja valikud, viib kursori esimese arvu sisestamise kasti
            private void KT_btnTyhjenda_Click(object sender, EventArgs e)
            {
                KT_rbLiida.Checked = false;
                KT_rbLahuta.Checked = false;
                KT_rbKorruta.Checked = false;
                KT_rbJaga.Checked = false;
                KT_txtVastus.Text = "";
                KT_txtArv2.Text = "";
                KT_txtArv1.Text = "";
                KT_txtArv1.Focus();
            }

            // Nupp, millega saab ümardada komakohaga vastuse täisarvuks
            private void KT_btnYmarda_Click(object sender, EventArgs e)
            {
                double vastus = double.Parse(KT_txtVastus.Text);
                double ymarVastus = Math.Round(vastus);
                KT_txtVastus.Text = ymarVastus.ToString();
            }
        }
    }
