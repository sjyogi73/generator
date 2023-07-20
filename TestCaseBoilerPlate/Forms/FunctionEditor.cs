using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TestCaseBoilerplate.Models;

namespace TestCaseBoilerplate.Forms
{
    public partial class FunctionEditor : Form
    {
        public FunctionEditor()
        {
            InitializeComponent();
        }

        FunctionModel currentItem;

        public void ShowDialog(FunctionModel item, Form parent)
        {
            currentItem = item;
            funcNameTxtBox.Text = item.FunctioName;
            isGenericCheckBox.Checked = item.IsGeneric;
            returnTypeTxtBox.Text = item.ReturnType;
            accessSpectifierTxtBox.Text = item.AccessSpecifier;
            parametersGrid.DataSource = item.Parameters;
            dataRow.Columns.Clear();
            negativeDataRow.Columns.Clear();
            dataRow.Rows.Clear();
            negativeDataRow.Rows.Clear();
            item.Parameters.ForEach(p => dataRow.Columns.Add(p.ParameterName, $"{p.ParameterName}({p.DataType})"));
            item.Parameters.ForEach(p => negativeDataRow.Columns.Add(p.ParameterName, $"{p.ParameterName}({p.DataType})"));
            item.TestCasePositive.ForEach(e=> dataRow.Rows.Add(e.ToArray()));
            item.TestCaseNegative.ForEach(e => negativeDataRow.Rows.Add(e.ToArray()));
            ShowDialog(parent);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in negativeDataRow.Rows)
            {
                try
                {
                    if (row.Index + 1 == negativeDataRow.RowCount) break;
                    var list = new List<string>();
                    foreach (DataGridViewCell cell in row.Cells) list.Add(cell.Value?.ToString());
                    currentItem.TestCaseNegative.Add(list);
                }
                catch
                {

                }
            }
            foreach (DataGridViewRow row in dataRow.Rows)
            {
                if (row.Index + 1== dataRow.RowCount) continue;
                var list = new List<string>();
                foreach(DataGridViewCell cell in row.Cells) list.Add(cell.Value?.ToString());
                currentItem.TestCasePositive.Add(list);
            }
            Hide();
        }
    }
}
