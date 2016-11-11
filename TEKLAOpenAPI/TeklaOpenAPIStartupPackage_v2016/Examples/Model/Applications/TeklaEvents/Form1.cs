﻿using System;
using System.Windows.Forms;

using Tekla.Structures.Model;

namespace TeklaEvents
{
    public partial class Form1 : Form
    {
        private Events ModelEvents { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ModelEvents = new Events();
                ModelEvents.SelectionChange += this.ModelEvents_SelectionChanged;
                ModelEvents.ModelSave += this.ModelEvents_ModelSave;
                ModelEvents.TeklaStructuresExit += this.ModelEvents_TeklaExit;

                ModelEvents.Register();
                MessageBox.Show("Events activated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ModelEvents_SelectionChanged()
        {
            MessageBox.Show("SelectionChanged");
        }

        private void ModelEvents_ModelSave()
        {
            MessageBox.Show("ModelSave");
        }

        private void ModelEvents_TeklaExit()
        {
            ModelEvents.UnRegister();
            Application.Exit();
        }

        private void buttonDeactivate_Click(object sender, EventArgs e)
        {
            try
            {
                ModelEvents.UnRegister();
                MessageBox.Show("Events deactivated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ModelEvents.UnRegister();
        }   
    }
}
