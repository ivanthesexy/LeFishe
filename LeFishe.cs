using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LeFishe
{
    internal class LeFishe : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        public LeFishe()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbCongrats = new System.Windows.Forms.Label();
            this.llAgony = new System.Windows.Forms.LinkLabel();
            this.pbFishe = new System.Windows.Forms.PictureBox();
            this.btCrime = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbFishe)).BeginInit();
            this.SuspendLayout();
            //
            // lbCongrats
            //
            this.lbCongrats.AutoSize = true;
            this.lbCongrats.Location = new System.Drawing.Point(12, 9);
            this.lbCongrats.Name = "lbCongrats";
            this.lbCongrats.Size = new System.Drawing.Size(204, 13);
            this.lbCongrats.TabIndex = 0;
            this.lbCongrats.Text = "Congratulations, you are our lucky winner!";
            //
            // llAgony
            //
            this.llAgony.AutoSize = true;
            this.llAgony.Location = new System.Drawing.Point(12, 199);
            this.llAgony.Name = "llAgony";
            this.llAgony.Size = new System.Drawing.Size(259, 13);
            this.llAgony.TabIndex = 1;
            this.llAgony.TabStop = true;
            this.llAgony.Text = "01100001 01100111 01101111 01101110 01111001";
            this.llAgony.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler((sender, e) => { System.Diagnostics.Process.Start("https://github.com/ivanthesexy/lefishe"); Close(); });
            //
            // pbFishe
            //
            this.pbFishe.BackColor = System.Drawing.Color.White;
            this.pbFishe.Image = global::LeFishe.Properties.Resources.lefishe;
            this.pbFishe.Location = new System.Drawing.Point(15, 25);
            this.pbFishe.Name = "pbFishe";
            this.pbFishe.Size = new System.Drawing.Size(256, 160);
            this.pbFishe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFishe.TabIndex = 2;
            this.pbFishe.TabStop = false;
            //
            // btCrime
            //
            this.btCrime.Location = new System.Drawing.Point(15, 235);
            this.btCrime.Name = "btCrime";
            this.btCrime.Size = new System.Drawing.Size(160, 23);
            this.btCrime.TabIndex = 3;
            this.btCrime.Text = "View Black Crime Statistics";
            this.btCrime.UseVisualStyleBackColor = true;
            this.btCrime.Click += new System.EventHandler((sender, e) =>
            {
                var funny = new string[] {
                "genshin impact free waifu hack 2022 no virus",
                "agony",
                "how to unshit pants",
                "scientific name of pig",
                "squirrel testicle size",
                "rumpleschnopskins" ,
                "big toilet" ,
                "shrek has swag" ,
                "mlg keanu reeves",
                "polybius rule 34",
                "porn",
                "how to leave Detroit",
                "snowman getting fresh cut",
                "where did my waifu go after taking my meds",
                "how do i write c# programs",
                "help my linux distro came without the sex tips",
                "templeos free crack no virus 2022",
                "is africa made out of chocolate",
                "hi hottie wanna marry",
                "nuclear bomb for arasaka hq best price",
                "half life 3 2001 demo full hd 4k dolby digital",
                "how to pass exams free download no virus no password no survey 2022",
                "pumped up kicks skrillex remix",
                "shush in turkish",
                "stop killing french people to make french fries",
                "stop killing trans people to make trans fat",
                "the effects of dementia",
                "where is republic of gamers",
                "there's a black man in a suit waiting outside of my house and hes glowing help",
                "mandela catalouge intruder trap rule 34",
                "racoon eating grapes"};
                System.Diagnostics.Process.Start("https://google.com/search?q=" + funny[new System.Random().Next(0, funny.Length)].Replace(" ", "%20"));
                Close();
            });
            //
            // btOK
            //
            this.btOK.Location = new System.Drawing.Point(181, 235);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 4;
            this.btOK.Text = "Ok";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler((sender, e) => { Close(); });
            //
            // LeFishe
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 265);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btCrime);
            this.Controls.Add(this.pbFishe);
            this.Controls.Add(this.llAgony);
            this.Controls.Add(this.lbCongrats);
            this.MaximumSize = new System.Drawing.Size(296, 304);
            this.MinimumSize = new System.Drawing.Size(296, 304);
            this.Name = "LeFishe";
            this.Text = "CONGRATULATIONS!";
            ((System.ComponentModel.ISupportInitialize)(this.pbFishe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion Windows Form Designer generated code

        private System.Windows.Forms.Label lbCongrats;
        private System.Windows.Forms.LinkLabel llAgony;
        private System.Windows.Forms.PictureBox pbFishe;
        private System.Windows.Forms.Button btCrime;
        private System.Windows.Forms.Button btOK;
    }
}