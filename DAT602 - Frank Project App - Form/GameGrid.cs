using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAT602___Frank_Project_App___Form
{
    public partial class GameGrid : Form
    {
        public GameGrid()
        {
            InitializeComponent();

            CenterToScreen();
        }

        private void UpdateDisplay()
        {
            gameGridData.DefaultCellStyle.SelectionBackColor = Color.White;
            gameGridData.DefaultCellStyle.SelectionForeColor = Color.Black;
            gameGridData.DataSource = null;
            //var gridinfo = DataAccess.GetGameGrid().AsEnumerable();
            //var gridcol = DataAccess.GetGameGrid().Columns[0];

            //List<string> tile;

            //for (var i = 0; i < 10; i += 10)
            //{
            //    tile = new List<string>();
            //    for (var j = 0; j < 10; j++)
            //    {
            //        tile.Add(
            //            from row in gridinfo
            //            where 'X' == i && 'Y' == j
            //            select row.Field(gridcol)
            //            );
            //    }
            //}

            //DataGridViewRow test = new DataGridViewRow();
            //test.SetValues();

            gameGridData.Rows.Add();
            gameGridData.Rows.Add();
            gameGridData.Rows.Add();
            gameGridData.Rows.Add();
            gameGridData.Rows.Add();
            gameGridData.Rows.Add();
            gameGridData.Rows.Add();
            gameGridData.Rows.Add();
            gameGridData.Rows.Add();
            gameGridData.Rows.Add();

            //gameGridData.
        }

        private void GameGrid_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void ExitGameButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
