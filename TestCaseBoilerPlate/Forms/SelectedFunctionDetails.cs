using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TestCaseBoilerplate.Models;

namespace TestCaseBoilerplate.Forms
{
    public partial class SelectedFunctionDetails : Form
    {
        public OutputConfig outputConfig = new OutputConfig();
        public SelectedFunctionDetails()
        {
            InitializeComponent();
        }

        private readonly FunctionEditor FunctionEditorForm = new FunctionEditor();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dataGridView1.ReadOnly = true;
            dataGridView1.CellMouseDoubleClick += OnGridDoubleClick;
        }

        private void OnGridDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FunctionEditorForm.ShowDialog(((List<FunctionModel>)dataGridView1.DataSource)[e.RowIndex], this);
        }

        public event EventHandler OnSaveClicked;

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            outputConfig.OutputFileFullName = file_txt.Text;
            outputConfig.AllPublic = all_public_chkbx.Checked;
            outputConfig.AllPrivate = all_private_chkbx.Checked;
            Cursor = Cursors.WaitCursor;
            OnSaveClicked(this, EventArgs.Empty);
            Cursor = Cursors.Arrow;
            Close();
        }

        public void ShowDialog(List<FunctionModel> models)
        {
            dataGridView1.DataSource = models;
            ShowDialog();
        }


        private void browseBtn_Click(object sender, EventArgs e)
        {
            openFile_Dialog.ShowDialog();
            file_txt.Text = openFile_Dialog.FileName;
        }
    }
}
