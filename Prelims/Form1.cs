
namespace Prelims
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open";
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
            this.Text = openFileDialog.FileName;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save";
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
            this.Text = saveFileDialog.FileName;
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = string.Empty;
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string currentDateTime = DateTime.Now.ToString();

            int cursorPosition = richTextBox1.SelectionStart;
            richTextBox1.Text = richTextBox1.Text.Insert(cursorPosition, currentDateTime);

            richTextBox1.SelectionStart = cursorPosition + currentDateTime.Length;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font;
            }
        }

        //Context menu
        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(richTextBox1, e.Location);
            }
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = string.Empty;         
        }        
    }
}
