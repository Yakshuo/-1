namespace Prelims
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            richTextBox1 = new RichTextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripSeparator();
            exitToolStripMenuItem1 = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem1 = new ToolStripMenuItem();
            dToolStripMenuItem = new ToolStripSeparator();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            dateTimeToolStripMenuItem = new ToolStripMenuItem();
            formatToolStripMenuItem = new ToolStripMenuItem();
            fontToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            undoToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            cutToolStripMenuItem1 = new ToolStripMenuItem();
            copyToolStripMenuItem1 = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            selectAllToolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(0, 24);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(800, 426);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            richTextBox1.MouseDown += richTextBox1_MouseDown;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, formatToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveAsToolStripMenuItem, exitToolStripMenuItem, exitToolStripMenuItem1 });
            fileToolStripMenuItem.ImageTransparentColor = Color.Transparent;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(184, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(184, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(184, 22);
            saveAsToolStripMenuItem.Text = "Save as";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(181, 6);
            // 
            // exitToolStripMenuItem1
            // 
            exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            exitToolStripMenuItem1.Size = new Size(184, 22);
            exitToolStripMenuItem1.Text = "Exit";
            exitToolStripMenuItem1.Click += exitToolStripMenuItem1_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, toolStripMenuItem1, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, deleteToolStripMenuItem1, dToolStripMenuItem, selectAllToolStripMenuItem, dateTimeToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(164, 22);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(161, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(164, 22);
            cutToolStripMenuItem.Text = "Cut";
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(164, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(164, 22);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem1
            // 
            deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            deleteToolStripMenuItem1.Size = new Size(164, 22);
            deleteToolStripMenuItem1.Text = "Delete";
            deleteToolStripMenuItem1.Click += deleteToolStripMenuItem1_Click;
            // 
            // dToolStripMenuItem
            // 
            dToolStripMenuItem.Name = "dToolStripMenuItem";
            dToolStripMenuItem.Size = new Size(161, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            selectAllToolStripMenuItem.Size = new Size(164, 22);
            selectAllToolStripMenuItem.Text = "Select All";
            selectAllToolStripMenuItem.Click += selectAllToolStripMenuItem_Click;
            // 
            // dateTimeToolStripMenuItem
            // 
            dateTimeToolStripMenuItem.Name = "dateTimeToolStripMenuItem";
            dateTimeToolStripMenuItem.ShortcutKeys = Keys.F5;
            dateTimeToolStripMenuItem.Size = new Size(164, 22);
            dateTimeToolStripMenuItem.Text = "Date/Time";
            dateTimeToolStripMenuItem.Click += dateTimeToolStripMenuItem_Click;
            // 
            // formatToolStripMenuItem
            // 
            formatToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fontToolStripMenuItem });
            formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            formatToolStripMenuItem.Size = new Size(57, 20);
            formatToolStripMenuItem.Text = "Format";
            // 
            // fontToolStripMenuItem
            // 
            fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            fontToolStripMenuItem.Size = new Size(98, 22);
            fontToolStripMenuItem.Text = "Font";
            fontToolStripMenuItem.Click += fontToolStripMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { undoToolStripMenuItem1, toolStripMenuItem2, cutToolStripMenuItem1, copyToolStripMenuItem1, deleteToolStripMenuItem, toolStripMenuItem3, selectAllToolStripMenuItem1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 148);
            // 
            // undoToolStripMenuItem1
            // 
            undoToolStripMenuItem1.Name = "undoToolStripMenuItem1";
            undoToolStripMenuItem1.Size = new Size(180, 22);
            undoToolStripMenuItem1.Text = "Undo";
            undoToolStripMenuItem1.Click += undoToolStripMenuItem1_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(177, 6);
            // 
            // cutToolStripMenuItem1
            // 
            cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
            cutToolStripMenuItem1.Size = new Size(180, 22);
            cutToolStripMenuItem1.Text = "Cut";
            cutToolStripMenuItem1.Click += cutToolStripMenuItem1_Click;
            // 
            // copyToolStripMenuItem1
            // 
            copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            copyToolStripMenuItem1.Size = new Size(180, 22);
            copyToolStripMenuItem1.Text = "Copy";
            copyToolStripMenuItem1.Click += copyToolStripMenuItem1_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(180, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(177, 6);
            // 
            // selectAllToolStripMenuItem1
            // 
            selectAllToolStripMenuItem1.Name = "selectAllToolStripMenuItem1";
            selectAllToolStripMenuItem1.Size = new Size(180, 22);
            selectAllToolStripMenuItem1.Text = "Select All";
            selectAllToolStripMenuItem1.Click += selectAllToolStripMenuItem1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Brown;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(menuStrip1);
            HelpButton = true;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Notepad";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem formatToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator exitToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator dToolStripMenuItem;
        private ToolStripMenuItem dateTimeToolStripMenuItem;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem fontToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem undoToolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem cutToolStripMenuItem1;
        private ToolStripMenuItem copyToolStripMenuItem1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem selectAllToolStripMenuItem1;
        private ToolStripMenuItem deleteToolStripMenuItem1;
    }
}
