using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GenerateSqlScript
{
    public partial class Form1 : Form
    {
        #region Declare 
        SqlConnection connection;
        DataTable dataTable = null;
        SqlDataSourceEnumerator instance = System.Data.Sql.SqlDataSourceEnumerator.Instance;
        BackgroundWorker background = null;
        AutoCompleteStringCollection SERVERTableName = null;
        string sql = "";

        #endregion
        public Form1()
        {
            InitializeComponent();
            txt_table.CharacterCasing = CharacterCasing.Upper;

            #region Load Instance SQL Server
            background = new BackgroundWorker();
            background.WorkerSupportsCancellation = true;
            background.DoWork += delegate
            {
                txt_server.UseWaitCursor = true;
                dataTable = instance.GetDataSources();
                SERVERTableName = new AutoCompleteStringCollection();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    SERVERTableName.Add(dataRow["ServerName"].ToString() + "\\" + dataRow["InstanceName"].ToString());
                }
            };
            background.RunWorkerCompleted += delegate
            {
                txt_server.UseWaitCursor = false;
                txt_server.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_server.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt_server.AutoCompleteCustomSource = SERVERTableName;
            };
            background.RunWorkerAsync();
            #endregion
        }

        #region Function
        private DataTable GetDataTable(string sql)
        {

            if (connection == null) But_login_Click(null, null);
            if (connection.State != ConnectionState.Open) But_login_Click(null, null);
            using (DataTable dt = new DataTable())
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Server quá tải, quá trình thực hiện không thành công!\nVui lòng thực hiện lại hành động!.\n===========================\nLỗi:" + ex.Message, "Không có gì thông báo khi bạn tắt thông báo này!");

                }
                return dt;
            }
        }

        private void LoadDataToCollection()
        {
            if (connection == null) return;
            if (connection.State != ConnectionState.Open) return;
            AutoCompleteStringCollection ACSCTableName = new AutoCompleteStringCollection();
            AutoCompleteStringCollection ACSCStoreProcedure = new AutoCompleteStringCollection();

            using (DataTable dataTableName = GetDataTable(String.Concat(new string[] {
               "SELECT TABLE_NAME",
                " FROM INFORMATION_SCHEMA.TABLES",
                " WHERE /*TABLE_TYPE = 'BASE TABLE' AND */ TABLE_CATALOG='"+txt_db.Text+"'"
           })))
            {
                foreach (DataRow dataRow in dataTableName.Rows)
                {
                    ACSCTableName.Add(dataRow["TABLE_NAME"].ToString());
                }
                txt_table.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_table.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt_table.AutoCompleteCustomSource = ACSCTableName;
            }
            using (DataTable dataTableName = GetDataTable(String.Concat(new string[] {
               " SELECT name",
                " FROM dbo.sysobjects",
                " WHERE (type in('P'))"
           })))
            {
                foreach (DataRow dataRow in dataTableName.Rows)
                {
                    ACSCStoreProcedure.Add(dataRow["name"].ToString());
                }
                txt_list_storeprodures.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_list_storeprodures.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt_list_storeprodures.AutoCompleteCustomSource = ACSCStoreProcedure;
            }


        }

        private void LoadListDBName()
        {
            if (connection == null) return;
            if (connection.State != ConnectionState.Open) return;

            AutoCompleteStringCollection ACSCDBName = new AutoCompleteStringCollection();
            using (DataTable dataColumnName = GetDataTable(String.Concat(new string[] {
            "SELECT name FROM sys.databases",
            " ORDER BY name",
           })))
            {
                foreach (DataRow dataRow in dataColumnName.Rows)
                {
                    ACSCDBName.Add(dataRow["name"].ToString());
                }


                txt_db.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_db.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt_db.AutoCompleteCustomSource = ACSCDBName;

            }
        }

        private void GetSQL()
        {
            rtb_results2.Text = "";

            txt_table.Enabled = true;
            txt_where.Enabled = true;
            txt_order.Enabled = true;
            switch (cbx_action.SelectedIndex)
            {
                case 0:
                    txt_table.Enabled = false;
                    txt_where.Enabled = false;
                    txt_order.Enabled = false;
                    break;
                case 1:
                    rtb_results2.Text = cbx_action.Text + " * FROM " + txt_table.Text + " Where " + txt_where.Text + " Order by " + txt_order.Text;
                    break;

                case 2:
                    rtb_results2.Text = cbx_action.Text + " " + txt_table.Text + " SET " + txt_order.Text + " Where " + txt_where.Text;

                    break;

                case 3:
                    rtb_results2.Text = cbx_action.Text + " " + txt_table.Text + " Where " + txt_where.Text;
                    break;
            }
        }

        public int ExecuteSQL_Re(string strSQL)
        {
            int trave = 0;
            if (!strSQL.Equals(""))
            {
                SqlCommand Com = new SqlCommand(strSQL, connection);
                try
                {
                    trave = Com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                Com.Dispose();
            }
            return trave;
        }

        private StringBuilder GetContaintStoreProduceChild(string storeProduce)
        {
            StringBuilder sb = new StringBuilder();
            using (dataTable = GetDataTable(String.Concat(
                           new string[] {
                       "SELECT name",
                        "   FROM SYSOBJECTS",
                        "   WHERE ID IN (   SELECT SD.DEPID",
                        "   FROM SYSOBJECTS SO,",
                        "   SYSDEPENDS SD",
                        "   WHERE SO.NAME = '"+storeProduce+"'",
                        "   AND SD.ID = SO.ID",
                        "   )",
                        "   and xtype = 'p'"
                           }
                           )))
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    lst_store.Items.Add(dataRow["name"].ToString());
                    sb.Append(GetContaintStoreProduce(dataRow["name"].ToString()).ToString());
                    sb.Append(GetContaintStoreProduceChild(dataRow["name"].ToString()).ToString());
                }
            }
            return sb;
        }

        private StringBuilder GetContaintStoreProduce(string storeProduce)
        {

            StringBuilder sb = new StringBuilder();
            using (dataTable = GetDataTable(String.Concat(
                                 new string[] {
                       "EXEC sp_helptext '"+storeProduce.Trim()+"'"
                                 }
                                 )))
            {
                sb.Append("--" + storeProduce.ToUpper());
                sb.Append("\n----------------------------------\n");
                if (cbtypep.Text == "CREATE")
                {
                    sb.Append("IF(EXiSTS(SELECT name FROM sysobjects WHERE name ='" + storeProduce + "'))  DROP PROCEDURE " + storeProduce );

                }
                sb.Append("\nGO\n");
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (dataRow["text"].ToString().StartsWith("CREATE"))
                        sb.Append(dataRow["text"].ToString().Replace("CREATE", cbtypep.Text));
                    else
                        sb.Append(dataRow["text"].ToString());
                }
                sb.Append("\n");
            }
            return sb;
        }

        private StringBuilder CreateTable(string TableName)
        {
            StringBuilder sb = new StringBuilder();

            #region Dựng cột
            sql = String.Concat(new string[] {
                                " select * from (",
                                " select '  ['+column_name+'] ' + data_type + coalesce('('+cast(character_maximum_length as varchar)+')','') + ' ' +",
                                " case when exists ( ",
                                " select id from syscolumns",
                                " where object_name(id)= '"+TableName+"'",
                                " and name=column_name",
                                " and columnproperty(id,name,'IsIdentity') = 1 ",
                                " ) ",
                                " then",
                                " 'IDENTITY(' + ",
                                " cast(ident_seed( '"+TableName+"') as varchar) + ',' + ",
                                " cast(ident_incr( '"+TableName+"') as varchar) + ')'",
                                " else ''",
                                " end + ' ' +",
                                " ( case when IS_NULLABLE = 'No' then 'NOT ' else '' end ) + 'NULL ' + coalesce('DEFAULT '+COLUMN_DEFAULT,'')  col,ordinal_position stt",
                                " from information_schema.columns where table_name =  '"+TableName+"'",
                                " ) a order by stt",
                            });

            using (dataTable = GetDataTable(sql))
            {

                sb.Append("--" + TableName.ToUpper());
                sb.Append("\n----------------------------------\n");
                if (cbtypep.Text == "CREATE")
                {
                    sb.Append("--IF(EXiSTS(SELECT name FROM sysobjects WHERE name ='" + TableName + "'))  DROP TABLE " + TableName+"\n");
                }
                sb.Append(cbtypep.Text + " TABLE [" + TableName + "] (\n");

                foreach (DataRow dr in dataTable.Rows)
                {
                    sb.Append(dr["col"].ToString() + "");
                    sb.Append(",\n");
                }
            }
            #endregion

            #region Khóa chính    PRIMARY KEY
            sql = String.Concat(new string[] {
                                " select * from (",
                                " select '   ['+COLUMN_NAME+']'  col, 900+ordinal_position stt",
                                " from information_schema.key_column_usage",
                                " where constraint_name in(select  constraint_name ",
                                " from information_schema.table_constraints",
                                " where table_name = '"+TableName+"' and constraint_type='PRIMARY KEY')",
                                " ) c"
                                });

            using (dataTable = GetDataTable(sql))
            {
                if (dataTable.Rows.Count > 0)
                {
                    string sql2 = "";
                    sql2 = "   PRIMARY KEY (\n";
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        sql2 += dr["col"].ToString() + "";
                        sql2 += ",\n";
                    }
                    sql2 = sql2.Substring(0, sql2.Length - 2);
                    sql2 += "\n   )\n";

                    sb.Append(sql2);
                }
            }
            #endregion

            sb.Append(")\n");
            return sb;
        }

        private StringBuilder CreateV(string ViewName)
        {
            StringBuilder sb = new StringBuilder();
            using (dataTable = GetDataTable(String.Concat(
                                         new string[] {
                                        "EXEC sp_helptext '"+ViewName+"'"
                                         }
                                         )))
            {
                sb.Append("--" + ViewName.ToUpper());
                sb.Append("\n----------------------------------\n");
                if (cbtypep.Text == "CREATE")
                {
                    sb.Append("IF(EXiSTS(SELECT name FROM sysobjects WHERE name ='" + ViewName + "'))  DROP VIEW " + ViewName);
                }
                sb.Append(" \nGO\n");
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if(dataRow["text"].ToString().StartsWith("CREATE"))
                        sb.Append(dataRow["text"].ToString().Replace("CREATE", cbtypep.Text));
                    else
                        sb.Append(dataRow["text"].ToString());
                }
                sb.Append("\n");
            }
            return sb;
        }

        private AutoCompleteStringCollection autoComplete(string strsouce, string columnouto, Control[] controllist)
        {

            AutoCompleteStringCollection ACSC = new AutoCompleteStringCollection();
            using (dataTable = GetDataTable(strsouce))
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    ACSC.Add(dataRow[columnouto].ToString());
                }
            }
            foreach (TextBox controlx in controllist)
            {
                controlx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                controlx.AutoCompleteSource = AutoCompleteSource.CustomSource;
                controlx.AutoCompleteCustomSource = ACSC;
            }
            return ACSC;
        }
        #endregion

        #region Even
        private void but_generateSqlSript_table_Click(object sender, EventArgs e)
        {
            if (connection == null) But_login_Click(sender, e);
            if (connection.State != ConnectionState.Open) But_login_Click(sender, e);
            try
            {
                /*Chú thích xem sao*/
                if (txt_where.Text == string.Empty)
                    txt_where.Text = "1=1";
                string sql = "";
                if (txt_order.Text != string.Empty)
                    sql = "SELECT * FROM " + txt_table.Text + " WHERE " + txt_where.Text + " ORDER BY " + txt_order.Text;
                else
                    sql = "SELECT * FROM " + txt_table.Text + " WHERE " + txt_where.Text;

                DataTable dt = GetDataTable(sql);

                StringBuilder sb = new StringBuilder();
                sb.Append("DELETE " + txt_table.Text + " WHERE " + txt_where.Text + "\nGO");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("\nINSERT " + txt_table.Text + " VALUES (");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] == DBNull.Value)
                        {
                            sb.Append("NULL");
                        }
                        else
                        {
                            if (dt.Columns[j].DataType.ToString() == "System.DateTime")
                            {
                                DateTime dateTime = DateTime.Parse(dt.Rows[i][j].ToString());
                                sb.Append("N'" + dateTime.ToString("MM/dd/yyyy HH:mm:ss.fff") + "'");
                            }
                            else
                            {
                                sb.Append("N'" + dt.Rows[i][j].ToString().Replace("'", "''") + "'");
                            }
                        }
                        if (j == dt.Columns.Count - 1)
                            sb.Append(")\nGO");
                        else
                            sb.Append(", ");
                    }
                }
                rtb_results.Text = sb.ToString();
                Clipboard.SetText(sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ai rồi cũng có lỗi! nên xin lượng thứ nếu chương trình bị lỗi,\nNếu được, bạn hãy xem bạn cho tôi những gì?\nLỗi từ những cái bạn cho tôi đấy.\n===========================\nLỗi:" + ex.Message, "Không có gì thông báo khi bạn tắt thông báo này!");
            }
        }

        private void But_login_Click(object sender, EventArgs e)
        {
            string strdb = "";
            if (txt_db.Text != string.Empty) strdb = "Database = " + txt_db.Text + ";";
            connection = new SqlConnection(@"Server=" + txt_server.Text + ";" + strdb + "User Id=" + txt_user.Text + ";Password=" + txt_pass.Text + "");//;Connect Timeout=0
            try { connection.Open(); }
            catch (Exception ex) { MessageBox.Show("Kết nối thất bại.\n================\n" + ex.Message, "Kết nối"); }
            LoadDataToCollection();
            LoadListDBName();

        }

        private void But_generateSqlSript_store_produres_Click(object sender, EventArgs e)
        {
            rtb_results.Text = "";
            lst_store.Items.Clear();
            try
            {
                string[] listStoreProcedures = txt_list_storeprodures.Text.Split(new char[] { ',', ';', '.', '/', '\\' });

                foreach (string stringStoreP in listStoreProcedures)
                {
                    if (stringStoreP.Trim() != string.Empty)
                    {
                        rtb_results.Text += GetContaintStoreProduce(stringStoreP.Trim()).ToString();
                        rtb_results.Text += GetContaintStoreProduceChild(stringStoreP.Trim()).ToString();
                        rtb_results.Text += "\n----------------------------------------Hết Store Chính---------------------------------------------\n";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không ai mong muốn có lỗi, nếu có lỗi thì tự xem và sửa đi!.\n===========================\nLỗi:" + ex.Message, "Không có gì thông báo khi bạn tắt thông báo này!");
            }
        }

        private void But_createtable_Click(object sender, EventArgs e)
        {
            rtb_results.Text = "";
            try
            {
                using (DataTable data = GetDataTable("select name,type from sysobjects where name in('" + txt_table.Text + "')"))
                {
                    foreach (DataRow dtr in data.Rows)
                    {
                        if (CheckObjectVisible(dtr["name"].ToString()))
                            #region Create View
                            if (dtr["type"].ToString().Trim().Equals("V"))
                            {
                                rtb_results.Text += CreateV(dtr["name"].ToString()).ToString();
                            }
                            #endregion
                            else
                            #region Create Table
                            {
                                rtb_results.Text += CreateTable(dtr["name"].ToString()).ToString();
                            }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không ai mong muốn có lỗi, nếu có lỗi thì tự xem và sửa đi!.\n===========================\nLỗi:" + ex.Message, "Không có gì thông báo khi bạn tắt thông báo này!");
            }
        }

        private bool CheckObjectVisible(string strobjects)
        {
            bool boo = false;
            using (dataTable = GetDataTable("select name from sysobjects where name = '" + strobjects + "'"))
            {
                if (dataTable.Rows.Count > 0)
                    boo = true;
            }
            return boo;
        }

        private void but_refreshview_Click(object sender, EventArgs e)
        {
            using (DataTable data = GetDataTable("select type from sysobjects where name in ('" + txt_table.Text + "')"))
            {
                foreach (DataRow dtr in data.Rows)
                {
                    if (dtr["type"].ToString().Trim().Equals("V"))
                    {
                        ExecuteSQL_Re("EXEC sp_refreshview '" + txt_table.Text + "'");
                    }
                }
            }
        }

        private void but_execute_Click(object sender, EventArgs e)
        {
            if (connection == null) But_login_Click(sender, e);
            if (connection.State != ConnectionState.Open) But_login_Click(sender, e);
            try
            {
                dgr_result.DataSource = null;

                if (!(rtb_results2.Text == ""))
                {
                    if (rtb_results2.Text.ToLower().StartsWith("select"))
                    {
                        DataTable dataTable = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(rtb_results2.Text, connection);
                        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                        da.Fill(dataTable);
                        da.UpdateCommand = new SqlCommandBuilder(da).GetUpdateCommand();

                        dataTable.RowChanged += delegate
                        {
                            da.Update(dataTable);
                        };
                        dataTable.RowDeleted += delegate
                        {
                            da.Update(dataTable);
                        };


                        dgr_result.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show(ExecuteSQL_Re(rtb_results.Text).ToString() + " record(s) effected", "Thực hiện xong!");

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ai rồi cũng có lỗi! nên xin lượng thứ nếu chương trình bị lỗi,\nNếu được, bạn hãy xem bạn cho tôi những gì?\nLỗi từ những cái bạn cho tôi đấy.\n===========================\nLỗi:" + ex.Message, "Không có gì thông báo khi bạn tắt thông báo này!");
            }
        }

        private void but_create_tab_tmp_x_Click(object sender, EventArgs e)
        {
            rtb_results.Text = "";

            if (connection == null) But_login_Click(sender, e);
            if (connection.State != ConnectionState.Open) But_login_Click(sender, e);
            using (DataTable data = GetDataTable("select name,type from sysobjects where name in('" + txt_table.Text + "')"))
            {
                foreach (DataRow dtr in data.Rows)
                {

                    #region Create Table
                    {
                        if (CheckObjectVisible(dtr["name"].ToString()))
                            rtb_results.Text += CreateTable(dtr["name"].ToString()).ToString();

                        if (CheckObjectVisible(dtr["name"].ToString() + "tmp"))
                            rtb_results.Text += CreateTable(dtr["name"].ToString() + "tmp").ToString();

                        if (CheckObjectVisible("x" + dtr["name"].ToString()))
                            rtb_results.Text += CreateTable("x" + dtr["name"].ToString()).ToString();

                        if (CheckObjectVisible("V_" + dtr["name"].ToString()))
                            rtb_results.Text += CreateV("V_" + dtr["name"].ToString()).ToString();

                    }
                    #endregion
                }
            }
        }

        private void Txt_db_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_db.AutoCompleteCustomSource.Contains(txt_db.Text))
                {
                    connection.ChangeDatabase(txt_db.Text);
                    LoadDataToCollection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối DataBase thất bại.\n================\n" + ex.Message, "Kết nối");
            }
        }

        private void Txt_table_TextChanged(object sender, EventArgs e)
        {
            autoComplete(String.Concat(new string[] {
                                    "SELECT COLUMN_NAME",
                                    " FROM INFORMATION_SCHEMA.COLUMNS",
                                    " WHERE TABLE_NAME = '"+txt_table.Text+"'",
                                    " ORDER BY ORDINAL_POSITION",
                                   }), "COLUMN_NAME", new Control[] { txt_where, txt_order });


            GetSQL();
        }

        private void txt_where_TextChanged(object sender, EventArgs e)
        {

            GetSQL();
        }

        private void txt_order_TextChanged(object sender, EventArgs e)
        {
            GetSQL();
        }

        private void cbx_action_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSQL();
        }
        #endregion

        private void rtb_results2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                switch (e.KeyCode)
                {
                    case Keys.R:
                        but_execute_Click(null, null);
                        break;
                }
        }

        private void dgr_result_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                switch (e.KeyCode)
                {
                    case Keys.V:
                        string s = Clipboard.GetText();
                        string[] lines = s.Replace("\n", "").Split('\r');
                        string[] fields;
                        int row = dgr_result.CurrentRow.Index;
                        int column = 1;
                        foreach (string l in lines)
                        {
                            fields = l.Split('\t');
                            foreach (string f in fields)
                                dgr_result[column++, row].Value = f;
                            row++;
                            column = 1;
                        }
                        break;
                }
        }

    }
}
