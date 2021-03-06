﻿using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        // Конструктор
        public Form1()
        {
            InitializeComponent();
            try
            {
                // RegistryKey - Инициализация объекта для работы с веткой LocalMachine.
                RegistryKey regKey = Registry.LocalMachine;

                regKey = regKey.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                string Temp = (string)regKey.GetValue("CyberBionicTestStart", "");

                if (Temp != "")
                    label3.Text = "программа стоит в автозагрузке";
            }
            catch (Exception ex)
            {
                label3.Text = "программа не стоит в автозагрузке";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey regKey = Registry.LocalMachine;
                regKey = regKey.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");

                // Путь к данному приложению.
                regKey.SetValue("CyberBionicTestStart", Application.StartupPath + "\\WindowsFormsApplication2.exe");
                label3.Text = "программа стоит в автозагрузке";
            }
            catch (Exception ex)
            {
                label3.Text = "программа не стоит в автозагрузке";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Удаление программы из автозагрузки.
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey regKey = Registry.LocalMachine;
                regKey = regKey.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                regKey.DeleteValue("CyberBionicTestStart");
                label3.Text = "программа не стоит в автозагрузке";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
