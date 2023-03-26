using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Macros;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace NafraProjetos
{
    public partial class Painel : System.Windows.Forms.Form
    {
        int X = 0;
        int Y = 0;

        private void Painel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void Painel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

        #region Global

        public static class Global
        {
            public static string
                Lista1, Lista2, Lista3, Lista4 = string.Empty,
                Path = @"C:\Users\Public\AuraPrevSheets.json",
                Path2 = @"C:\Users\Public\Relatorio.txt",
                ApplicationName = "AuraPrevSheets",
                SpreadsheetId = "1Vlcp1hQoquV1cbxT4vLrWuGN18tsX1muaWWwhl0axlA",
                CadeiaConexao = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BD_NafraProjetos;Integrated Security=True";

            public static double SheetsId = 11;

            public static int IdHistorico = 0, IdLogin = 0, Usuario_Id, Job_Id;

            public static DateTime DtProjeto;


            public static string
                sheet = "Gerenciador",
                SheetsNome, SheetsEmail, SheetsAtivo, SheetsEmUso, Form_End, Form_Ocu, Form_Ris, Form_RespUso, Form_RespTec,
                Form_CREA, Form_SisTipo, Form_Norma, Form_DMang, Form_CMang, Form_LMang, Form_CTubo, Form_MatTubo, Form_TipoEsg, Form_DEsg,
                Form_RiVol, Form_RiPos, Form_QtdHid, Form_Tag,
                Form_D1Hid, Form_D2Hid, Form_D3Hid, Form_D4Hid, Form_DBiPa, Form_DBiRi, Form_DDT,
                NomeMemorial, NomeHidrante,
                LP_Comprimento, LP_PerdaDeCarga, LP_Nivel, LP_ElevacaoDoNivel, LP_Elevacao, LP_Diametro, LP_RaioNominal, FormatoUnidades, Form_P1Hid,
                PHid = "T1", SHid = "T2", THid = "T3", QHid = "T4", BiPa = "BI-PA", BiRi = "BI-RI", TrechoDT = "DT", RI = "RI", BI = "BI", PA = "PA";

            public static Parameter
                Elevacao_1Hid, Elevacao_2Hid, Elevacao_3Hid, Elevacao_4Hid, Elevacao_PA, Elevacao_BI, Elevacao_RI,
                P_End, P_Ocu, P_Ris, P_RespUso, P_RespTec, P_CREA,
                P_SisTipo, P_Norma, P_DMang, P_CMang, P_LMang,
                P_CTubo, P_MatTubo, P_TipoEsg, P_DEsg, P_RiVol,
                P_RiPos, P_QtdHid, P_JtTotal, P_NPSH, P_Hman, P_QTotal, P_Pot,
                P_T1Hid, P_T2Hid, P_T3Hid, P_T4Hid, P_TBiPa, P_TBiRi,
                P_El1Hid, P_El2Hid, P_El3Hid, P_El4Hid, P_ElBiPa, P_ElBiRi,
                P_Q1Hid, P_Q2Hid, P_Q3Hid, P_Q4Hid, P_QBiPa, P_QBiRi,
                P_P1Hid, P_P2Hid, P_P3Hid, P_P4Hid, P_PBiPa, P_PBiRi,
                P_Je1Hid, P_Je2Hid, P_Je3Hid, P_Je4Hid,
                P_Jm1Hid, P_Jm2Hid, P_Jm3Hid, P_Jm4Hid,
                P_D1Hid, P_D2Hid, P_D3Hid, P_D4Hid, P_DBiPa, P_DBiRi,
                P_Lr1Hid, P_Lr2Hid, P_Lr3Hid, P_Lr4Hid, P_LrBiPa, P_LrBiRi,
                P_Lv1Hid, P_Lv2Hid, P_Lv3Hid, P_Lv4Hid, P_LvBiPa, P_LvBiRi,
                P_Lt1Hid, P_Lt2Hid, P_Lt3Hid, P_Lt4Hid, P_LtBiPa, P_LtBiRi,
                P_Ju1Hid, P_Ju2Hid, P_Ju3Hid, P_Ju4Hid, P_JuBiPa, P_JuBiRi,
                P_Jt1Hid, P_Jt2Hid, P_Jt3Hid, P_Jt4Hid, P_JtBiPa, P_JtBiRi,
                P_Ve1Hid, P_Ve2Hid, P_Ve3Hid, P_Ve4Hid, P_VeBiPa, P_VeBiRi,
                P_Mo1Hid, P_Mo2Hid, P_Mo3Hid, P_Mo4Hid, P_MoBiPa, P_MoBiRi,
                P_VarMCA1, P_VarMCA2, P_VarMCA3,
                Tag1Hid, Tag2Hid, Tag3Hid, Tag4Hid;

            public static int QtdHid;

            public static double
                SumElevacao_1Hid, SumElevacao_2Hid, SumElevacao_3Hid, SumElevacao_4Hid, SumElevacao_PA, SumElevacao_BI, SumElevacao_RI,
                SPC_1Hid, SPC_2Hid, SPC_3Hid, SPC_4Hid, SPC_BiPa, SPC_BiRi,
                PdC_1Hid_OPA, PdC_2Hid_OPA, PdC_3Hid_OPA, PdC_4Hid_OPA, PdC_BiPa_OPA, PdC_BiRi_OPA,
                PdC_1Hid_OPF, PdC_2Hid_OPF, PdC_3Hid_OPF, PdC_4Hid_OPF, PdC_BiPa_OPF, PdC_BiRi_OPF,
                CTIU, CTIU_1Hid, CTIU_2Hid, CTIU_3Hid, CTIU_4Hid, CTIU_BiPa, CTIU_BiRi,
                D1Hid, D2Hid, D3Hid, D4Hid, DBiPa, DBiRi, DDT, VarMaxMo;

        }
        #endregion

        private readonly Document Doc;
        public UIDocument ActiveUIDocument { get; private set; }

        public Painel(Document doc)
        {
            InitializeComponent();
            Doc = doc;
            this.MouseDown += new MouseEventHandler(Painel_MouseDown);
            this.MouseMove += new MouseEventHandler(Painel_MouseMove);
        }

        private void Painel_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(400, 400);
            this.groupBox1.Location = new System.Drawing.Point(8, 5);

            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(TP_Login);   
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.ClientSize = new Size(1024, 768);

            string query = "SELECT Id FROM Usuario WHERE Email = @Email AND Senha = @Senha";
            using (SqlConnection con = new SqlConnection(Global.CadeiaConexao))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar)).Value = TB_LoginEmail.Text;
                cmd.Parameters.Add(new SqlParameter("@Senha", SqlDbType.VarChar)).Value = TB_LoginSenha.Text;
                try
                {
                    con.Open();
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        Global.Usuario_Id = reader.GetInt32(0);
                        tabControl1.TabPages.Remove(TP_Login);
                        tabControl1.TabPages.Add(TP_Jobs);
                        reader.Close();

                        Processar("Atualizado!");
                    }
                    catch
                    {
                        MessageBox.Show("E-mail ou Senha não cadastrados!");
                    }
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }

            //IList<IList<object>> Login = IlistColunaSheet("Login", "A", "C");
            //if (Login != null && Login.Count > 0)
            //{
            //    bool Cadastrado = false;
            //    foreach (var row in Login)
            //    {
            //        if (row[1].ToString() == textBox9.Text && row[2].ToString() == textBox10.Text)
            //        {
            //            int.TryParse(row[0].ToString(), out Global.IdLogin);
            //            groupBox1.Visible = false;
            //            groupBox5.Visible = true;
            //            Cadastrado = true;
            //            break;
            //        }
            //    }
            //    if (Cadastrado == false) MessageBox.Show("Login ou Senha errados!");
            //}
        }



        //private void button18_Click(object sender, EventArgs e)
        //{
        //    if (tabControl2.SelectedTab == Etapa02)
        //    {
        //        tabControl2.TabPages.Remove(Etapa02);
        //        this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa01"];
        //        button18.Enabled = false;
        //    }
        //    else if (tabControl2.SelectedTab == Etapa03)
        //    {
        //        tabControl2.TabPages.Remove(Etapa03);
        //        this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa02"];
        //    }
        //    else if (tabControl2.SelectedTab == Etapa04)
        //    {
        //        tabControl2.TabPages.Remove(Etapa04);
        //        this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa03"];
        //    }
        //    else if (tabControl2.SelectedTab == Etapa05)
        //    {
        //        tabControl2.TabPages.Remove(Etapa05);
        //        this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa04"];
        //    }
        //    else if (tabControl2.SelectedTab == Etapa06)
        //    {
        //        tabControl2.TabPages.Remove(Etapa06);
        //        this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa05"];
        //    }
        //    else if (tabControl2.SelectedTab == Etapa07)
        //    {
        //        tabControl2.TabPages.Remove(Etapa07);
        //        this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa06"];
        //    }
        //    else if (tabControl2.SelectedTab == Etapa08)
        //    {
        //        tabControl2.TabPages.Remove(Etapa08);
        //        this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa07"];
        //        button19.Enabled = true;
        //    }
        //}

        //private void button19_Click(object sender, EventArgs e)
        //{
        //    if (tabControl2.SelectedTab == Etapa01)
        //    {
        //        tabControl2.TabPages.Add(Etapa02);
        //        this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa02"];
        //        button18.Enabled = true;
        //    }
        //    else if (tabControl2.SelectedTab == Etapa02)
        //    {
        //        tabControl2.TabPages.Add(Etapa03);
        //        this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa03"];
        //    }
        //    else if (tabControl2.SelectedTab == Etapa03)
        //    {
        //        tabControl2.TabPages.Add(Etapa04);
        //        this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa04"];
        //    }
        //    else if (tabControl2.SelectedTab == Etapa04)
        //    {
        //        tabControl2.TabPages.Add(Etapa05);
        //        this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa05"];
        //    }
        //    else if (tabControl2.SelectedTab == Etapa05)
        //    {
        //        tabControl2.TabPages.Add(Etapa06);
        //        this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa06"];
        //    }
        //    else if (tabControl2.SelectedTab == Etapa06)
        //    {
        //        tabControl2.TabPages.Add(Etapa07);
        //        this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa07"];
        //    }
        //    else if (tabControl2.SelectedTab == Etapa07)
        //    {
        //        tabControl2.TabPages.Add(Etapa08);
        //        this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa08"];
        //    }
        //    else if (tabControl2.SelectedTab == Etapa08)
        //    {
        //        button19.Enabled = false;
        //    }
        //}

        private void Somar(object sender, KeyEventArgs e)
        {
            double.TryParse(TB_AdicionarAreaExistente.Text, out double AreaExistente);
            double.TryParse(TB_AdicionarAreaNova.Text, out double AreaNova);
            TB_AdicionarAreaTotal.Text = (AreaExistente + AreaNova).ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO TableTeste (NameUser, AgeUser) VALUES (@NameUser, @AgeUser)";
            using (SqlConnection con = new SqlConnection(Global.CadeiaConexao))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add(new SqlParameter("@NameUser", SqlDbType.VarChar)).Value = textBox7.Text;
                cmd.Parameters.Add(new SqlParameter("@AgeUser", SqlDbType.Decimal)).Value = double.Parse(textBox11.Text);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ok");
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string query = "UPDATE TableTeste SET NameUser=@NameUser, AgeUser=@AgeUser WHERE Id=@Id";
            using (SqlConnection con = new SqlConnection(Global.CadeiaConexao))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Id", int.Parse(textBox13.Text));
                cmd.Parameters.Add(new SqlParameter("@NameUser", SqlDbType.VarChar)).Value = textBox7.Text;
                cmd.Parameters.Add(new SqlParameter("@AgeUser", SqlDbType.Decimal)).Value = double.Parse(textBox11.Text);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ok");
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string query = "DELETE TableTeste WHERE Id=@Id";
            using (SqlConnection con = new SqlConnection(Global.CadeiaConexao))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Id", int.Parse(textBox13.Text));
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ok");
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM TableTeste";
            using (SqlConnection con = new SqlConnection(Global.CadeiaConexao))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Usuario (Nome, Sobrenome, Telefone, Email, Senha, DataInicio, DataFim, Ativo, Logado, QtdAcesso, Msg)" +
                " VALUES (@Nome, @Sobrenome, @Telefone, @Email, @Senha, '01-01-2023', '01-01-2024', 1, 0, 0, 'teste')";
            using (SqlConnection con = new SqlConnection(Global.CadeiaConexao))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = TB_CadastroNome.Text;
                cmd.Parameters.Add(new SqlParameter("@Sobrenome", SqlDbType.VarChar)).Value = TB_CadastroSobrenome.Text;
                cmd.Parameters.Add(new SqlParameter("@Telefone", SqlDbType.VarChar)).Value = TB_CadastroTelefone.Text;
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar)).Value = TB_CadastroEmail.Text;
                cmd.Parameters.Add(new SqlParameter("@Senha", SqlDbType.Decimal)).Value = TB_CadastroSenha.Text;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuário cadastrado!");
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
            tabControl1.TabPages.Remove(TP_Cadastro);
            tabControl1.TabPages.Add(TP_Login);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string query =
                "SELECT O.OcupacaoUso AS 'Ocupação', DO.Divisao AS 'Divisão', DO.Descricao AS 'Descrição', IT.QtdCargaIncendio AS 'Carga de Incêndio'" +
                "FROM IT14 AS IT, DivisaoOcupacao AS DO, Ocupacao AS O " +
                "WHERE O.Id = DO.Ocupacao_Id AND DO.Id = IT.DivisaoOcupacao_Id AND IT.Id = " + CB_classificacao.SelectedValue;
            using (SqlConnection con = new SqlConnection(Global.CadeiaConexao))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView3.DataSource = dt;
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
        }

        private void Processar(string msg)
        {
            string query2 =
                "SELECT Id, NomeJob AS 'Nome do JOB', DataInicio AS 'Data Início'," +
                " DataEdificacao AS 'Data de construção', Area AS 'Área (m³)', Altura AS 'Altura (m)'" +
                " FROM Job WHERE Usuario_Id = " + Global.Usuario_Id.ToString();
            using (SqlConnection con2 = new SqlConnection(Global.CadeiaConexao))
            using (SqlCommand cmd2 = new SqlCommand(query2, con2))
            {
                try
                {
                    con2.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DGV_Jobs.DataSource = dt;
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }

            toolStripStatusLabel1.Text = msg;
            statusStrip1.Refresh();
            for (int i = 0; i < 101; i++)
            {
                toolStripProgressBar1.Value = i;
            }
        }

        void ProcessarHid(string msg)
        {
            statusCalculo.Text = msg;
            statusStrip1.Refresh();
            if (checkBox1.Checked) Thread.Sleep(300);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Medida = (string)dataGridView5.CurrentRow.Cells[0].Value;
            MessageBox.Show(Medida);
            if (Medida == "Extintores")
            {
            }
            tabControl1.TabPages.Remove(TP_Adicionar);
            tabControl1.TabPages.Add(TP_Hidrante);

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void label47_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(TP_Login);
            tabControl1.TabPages.Add(TP_Cadastro);
        }

        private void label48_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(TP_Login);
            tabControl1.TabPages.Add(TP_Recuperar);
        }

        //private void MoverBotao(object sender, EventArgs e)
        //{
        //    this.pictureBox8.Location = new System.Drawing.Point(128, 600);
        //}

        //private void RetornarBotao(object sender, EventArgs e)
        //{
        //    this.pictureBox8.Location = new System.Drawing.Point(128, 610);
        //}

        private void button14_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(TP_Cadastro);
            tabControl1.TabPages.Add(TP_Login);
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(TP_Jobs);
            tabControl1.TabPages.Add(TP_Login);
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(TP_Jobs);
            tabControl1.TabPages.Add(TP_Adicionar);

            string query = "SELECT * FROM Estado";
            using (SqlConnection con = new SqlConnection(Global.CadeiaConexao))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "NomeEstado";
                    comboBox2.ValueMember = "Id";
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
            string query2 = "SELECT * FROM ObjetivoJob";
            using (SqlConnection con2 = new SqlConnection(Global.CadeiaConexao))
            using (SqlCommand cmd2 = new SqlCommand(query2, con2))
            {
                try
                {
                    con2.Open();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    comboBox8.DataSource = dt2;
                    comboBox8.DisplayMember = "Objetivo";
                    comboBox8.ValueMember = "Id";
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
            string query3 = "SELECT * FROM IT14";
            using (SqlConnection con3 = new SqlConnection(Global.CadeiaConexao))
            using (SqlCommand cmd3 = new SqlCommand(query3, con3))
            {
                try
                {
                    con3.Open();
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    CB_classificacao.DataSource = dt3;
                    CB_classificacao.DisplayMember = "Compilado";
                    CB_classificacao.ValueMember = "Id";                    
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Global.Job_Id = (int)DGV_Jobs.CurrentRow.Cells[0].Value;
            tabControl1.TabPages.Remove(TP_Jobs);
            tabControl1.TabPages.Add(TP_Adicionar);
            MessageBox.Show("Usuário cadastrado!" + Global.Job_Id.ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int Job_Id = (int)DGV_Jobs.CurrentRow.Cells[0].Value;
            string query = "DELETE Job WHERE Id = " + Job_Id.ToString();
            using (SqlConnection con = new SqlConnection(Global.CadeiaConexao))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("JOB excluido com sucesso!");
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
            Processar("Atualizado!");
        }

        void RemoverPagina()
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            //tabControl1.TabPages.Remove(TP_Adicionar);
            RemoverPagina();
            
            tabControl1.TabPages.Add(TP_Jobs);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string query1 =
                "SELECT " +
                " CI.Risco, CI.DescricaoLimite, O.Grupo, ItN.Item, PO.Tipo, PO.Denominacao, PO.Obs " +
                "FROM " +
                " Usuario AS U, Job AS J, IT14 AS IT, CargaIncendio AS CI, DivisaoOcupacao AS DO, Ocupacao AS O," +
                " Protecao AS P, Medida AS M, Norma AS N, ItemNorma AS ItN, ParametroOcupacao AS PO, Capacidade AS C, DescricaoNota AS DN " +
                "WHERE " +
                " U.Id = J.Usuario_Id AND IT.Id = J.IT14_Id AND CI.Id = IT.CargaIncendio_Id AND DO.Id = IT.DivisaoOcupacao_Id" +
                " AND O.Id = DO.Ocupacao_Id AND DO.Id = P.DivisaoOcupacao_Id AND M.Id = P.Medida_Id AND N.Id = M.Norma_Id " +
                " AND PO.Id = P.ParametroOcupacao_Id AND C.Id = PO.Capacidade_Id AND DN.Id = P.DescricaoNota_Id " +
                " AND J.Id = " + Global.Job_Id.ToString() + " AND C.Minimo <= @Altura AND C.Maximo >= @Altura AND ItN.Item LIKE 'TABELA 6C%' " +
                "GROUP BY " +
                " CI.Risco, CI.DescricaoLimite, O.Grupo, ItN.Item, PO.Tipo, PO.Denominacao, PO.Obs ";
            using (SqlConnection con1 = new SqlConnection(Global.CadeiaConexao))
            using (SqlCommand cmd1 = new SqlCommand(query1, con1))
            {
                cmd1.Parameters.Add(new SqlParameter("@Altura", SqlDbType.Decimal)).Value = double.Parse(TB_AdicionarAtura.Text);
                try
                {
                    con1.Open();
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    dataGridView4.DataSource = dt1;
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
            string query2 =
                "SELECT M.TipoMedida AS 'Medida', DN.Descricao AS 'Nota específica', N.NumeroNorma AS 'Legislação' " +
                "FROM IT14 AS IT, CargaIncendio AS CI, DivisaoOcupacao AS DO, Ocupacao AS O, Protecao AS P," +
                " Medida AS M, Norma AS N, ItemNorma AS ItN, ParametroOcupacao AS PO, Capacidade AS C, DescricaoNota AS DN " +
                "WHERE CI.Id = IT.CargaIncendio_Id AND DO.Id = IT.DivisaoOcupacao_Id AND O.Id = DO.Ocupacao_Id AND" +
                " DO.Id = P.DivisaoOcupacao_Id AND M.Id = P.Medida_Id AND N.Id = M.Norma_Id AND PO.Id = P.ParametroOcupacao_Id AND" +
                " C.Id = PO.Capacidade_Id AND DN.Id = P.DescricaoNota_Id AND IT.Id = @IT14 AND C.Minimo <= @Altura AND" +
                " C.Maximo >= @Altura AND ItN.Item LIKE 'TABELA 6C%'";
            using (SqlConnection con2 = new SqlConnection(Global.CadeiaConexao))
            using (SqlCommand cmd2 = new SqlCommand(query2, con2))
            {
                cmd2.Parameters.Add(new SqlParameter("@IT14", SqlDbType.Int)).Value = int.Parse(CB_classificacao.SelectedValue.ToString());
                cmd2.Parameters.Add(new SqlParameter("@Altura", SqlDbType.Decimal)).Value = double.Parse(TB_AdicionarAtura.Text);
                try
                {
                    con2.Open();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    dataGridView5.DataSource = dt2;
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DateTime DataInicio = DateTime.Now;
            string query = "INSERT INTO Job (Usuario_Id, Estado_Id, ObjetivoJob_Id, IT14_Id, NomeJob, DataInicio, DataEdificacao, Area, Altura)" +
                " VALUES (" + Global.Usuario_Id + ", @Estado_Id, @ObjetivoJob_Id, @IT14_Id, @NomeJob, '" + DataInicio.ToShortDateString() + "', @DataEdificacao, @Area, @Altura)";
            using (SqlConnection con = new SqlConnection(Global.CadeiaConexao))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add(new SqlParameter("@Estado_Id", SqlDbType.Int)).Value = int.Parse(comboBox2.SelectedValue.ToString());
                cmd.Parameters.Add(new SqlParameter("@ObjetivoJob_Id", SqlDbType.Int)).Value = int.Parse(comboBox8.SelectedValue.ToString());
                cmd.Parameters.Add(new SqlParameter("@IT14_Id", SqlDbType.Int)).Value = int.Parse(CB_classificacao.SelectedValue.ToString());
                cmd.Parameters.Add(new SqlParameter("@NomeJob", SqlDbType.VarChar)).Value = textBox22.Text;
                cmd.Parameters.Add(new SqlParameter("@DataEdificacao", SqlDbType.Date)).Value = dateTimePicker1.Text;
                cmd.Parameters.Add(new SqlParameter("@Area", SqlDbType.Decimal)).Value = double.Parse(TB_AdicionarAreaTotal.Text);
                cmd.Parameters.Add(new SqlParameter("@Altura", SqlDbType.Decimal)).Value = double.Parse(TB_AdicionarAtura.Text);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Job criado com sucesso!");
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
            Processar("Atualizado!");
            tabControl1.TabPages.Remove(TP_Adicionar);
            tabControl1.TabPages.Add(TP_Jobs);


            //UPDATE TableTeste SET NameUser = @NameUser, AgeUser = @AgeUser WHERE Id = @Id"
            //string query = "UPDATE Job SET IT14_Id = @IT14_Id, Area = @Area, Altura = @Altura WHERE Id = @Id";
            //using (var con = new SqlConnection(Global.CadeiaConexao))
            //using (var cmd = new SqlCommand(query, con))
            //{
            //    cmd.Parameters.Add(new SqlParameter("@Estado_Id", SqlDbType.Int)).Value = int.Parse(comboBox2.SelectedValue.ToString());
            //    cmd.Parameters.Add(new SqlParameter("@ObjetivoJob_Id", SqlDbType.Int)).Value = int.Parse(comboBox8.SelectedValue.ToString());
            //    cmd.Parameters.Add(new SqlParameter("@NomeJob", SqlDbType.VarChar)).Value = textBox22.Text;
            //    cmd.Parameters.Add(new SqlParameter("@DataEdificacao", SqlDbType.Date)).Value = dateTimePicker1.Text;
            //    //cmd.Parameters.Add(new SqlParameter("@Area", SqlDbType.Decimal)).Value = double.Parse(textBox8.Text);
            //    //cmd.Parameters.Add(new SqlParameter("@Altura", SqlDbType.Decimal)).Value = double.Parse(textBox19.Text);
            //    try
            //    {
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        MessageBox.Show("Job criado!");
            //    }
            //    catch (SqlException err)
            //    {
            //        MessageBox.Show(err.ToString(), "Erro");
            //    }
            //}
            //tabControl1.TabPages.Remove(tabPage4);
            //tabControl1.TabPages.Add(tabPage5);
            //CultureInfo Cultura = new CultureInfo("pt-BR");
            //var DtProjeto = DateTime.Parse(dateTimePicker1.Text, Cultura);
            ////MessageBox.Show(DtProjeto.ToString());

            //var DE_20811_83 = new DateTime(1983, 3, 11);
            //var DE_38069_93 = new DateTime(1993, 12, 14);
            //var DE_46076_01 = new DateTime(2001, 8, 31);
            //var DE_56819_11 = new DateTime(2011, 3, 10);
            //var DE_63911_18 = new DateTime(2019, 4, 9);

            //var De20811_83 = DateTime.Compare(DtProjeto, DE_20811_83);
            //var De38069_93 = DateTime.Compare(DtProjeto, DE_38069_93);
            //var De46076_01 = DateTime.Compare(DtProjeto, DE_46076_01);
            //var De56819_11 = DateTime.Compare(DtProjeto, DE_56819_11);
            //var De63911_18 = DateTime.Compare(DtProjeto, DE_63911_18);

            //if (De20811_83 < 0)
            //{
            //    MessageBox.Show("IT43");
            //    tabControl2.TabPages.Add(Etapa03);
            //    this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa03"];
            //}
            //else if (De20811_83 >= 0 && De38069_93 < 0)
            //{
            //    MessageBox.Show("DE_20811_83");
            //    tabControl2.TabPages.Add(Etapa04);
            //    this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa04"];
            //}
            //else if (De38069_93 >= 0 && De46076_01 < 0)
            //{
            //    MessageBox.Show("DE_38069_93");
            //    tabControl2.TabPages.Add(Etapa05);
            //    this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa05"];
            //}
            //else if (De46076_01 >= 0 && De56819_11 < 0)
            //{
            //    MessageBox.Show("DE_46076_01");
            //    tabControl2.TabPages.Add(Etapa06);
            //    this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa06"];
            //}
            //else if (De56819_11 >= 0 && De63911_18 < 0)
            //{
            //    MessageBox.Show("DE_56819_11");
            //    tabControl2.TabPages.Add(Etapa07);
            //    this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa07"];
            //}
            //else
            //{
            //    MessageBox.Show("DE_63911_18");
            //    tabControl2.TabPages.Add(Etapa08);
            //    this.tabControl2.SelectedTab = this.tabControl2.TabPages["Etapa08"];
            //}
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            if (File.Exists(Global.Path2))
            {
                File.Delete(Global.Path2);
            }
            using (FileStream fs = File.Create(Global.Path2))
            {
                AddText(fs,
                    "Classificação: "
                    + CB_classificacao.Text
                    + "\r\nÁrea construída: "
                    + TB_AdicionarAreaTotal.Text + " m²"
                    + "\r\nAltura: "
                    + TB_AdicionarAtura.Text + " m"
                    + "\r\n\r\n"


                    + Global.Lista3 + "\r\n"
                    + Global.Lista4 + "\r\n"

                    + "\r\n"
                    + ""
                    );
            }
            System.Diagnostics.Process.Start(Global.Path2);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(TP_Recuperar);
            tabControl1.TabPages.Add(TP_Login);
        }

        private void B_Recuperar_Click(object sender, EventArgs e)
        {
            string query = "SELECT Senha FROM Usuario WHERE Email = @Email";
            using (SqlConnection con = new SqlConnection(Global.CadeiaConexao))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar)).Value = TB_RecuperarEmail.Text;
                try
                {
                    con.Open();
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        Email outlook = new Email("smtp.gmail.com", "nafraprojetos@gmail.com", "aiswsyqsdtdnxfeq");
                        outlook.SendEmail(emailsTo: new List<string> { TB_RecuperarEmail.Text },
                        subject: "Recuperação de senha",
                        body: "Segue a senha solicitada: " + reader.GetString(0).ToString(),
                        attachments: new List<string> { @"C:\temp\Assinatura Email.png" });
                        MessageBox.Show("Senha enviada para o e-mail informado!");
                        reader.Close();
                    }
                    catch(Exception err)
                    {
                        MessageBox.Show(err.ToString(), "E-mail não encontrado!");
                    }

                    //con.Open();
                    //SqlDataReader reader = cmd.ExecuteReader();
                    //while (reader.Read())
                    //{
                    //    MessageBox.Show(String.Format("{0}", reader.GetString(0)));
                    //}
                    //reader.Close();
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
        }

        private void toolStripSplitButton1_ButtonClick_1(object sender, EventArgs e)
        {
            this.ClientSize = new Size(400, 400);
            this.groupBox1.Location = new System.Drawing.Point(8, 5);
            RemoverPagina();
            tabControl1.TabPages.Add(TP_Login);
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;            
            Close();
        }

        private void Extrair(object sender, KeyEventArgs e)
        {
            string[] itensCombo = CB_classificacao.Text.Split('-');
            foreach (string item in itensCombo)
            {
                listBox1.Items.Add(item);
            }
            listBox1.Refresh();
        }

        private void label27_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(TP_Jobs);
            tabControl1.TabPages.Add(TP_Hidrante);
        }


        #region public string
        public string PS_End
        {
            get { return this.TB_End.Text; }
        }
        public string PS_Ocu
        {
            get { return this.TB_Ocu.Text; }
        }
        public string PS_Ris
        {
            get { return this.TB_Ris.Text; }
        }
        public string PS_RespUso
        {
            get { return this.TB_RespUso.Text; }
        }
        public string PS_RespTec
        {
            get { return this.TB_RespTec.Text; }
        }
        public string PS_CREA
        {
            get { return this.TB_CREA.Text; }
        }
        public string PS_SisTipo
        {
            get { return this.TB_SisTipo.Text; }
        }
        public string PS_Norma
        {
            get { return this.TB_Norma.Text; }
        }
        public string PS_DMang
        {
            get { return this.TB_DMang.Text; }
        }
        public string PS_CMang
        {
            get { return this.TB_CMang.Text; }
        }
        public string PS_LMang
        {
            get { return this.TB_LMang.Text; }
        }
        public string PS_CTubo
        {
            get { return this.TB_CTubo.Text; }
        }
        public string PS_MatTubo
        {
            get { return this.TB_MatTubo.Text; }
        }
        public string PS_TipoEsg
        {
            get { return this.TB_TipoEsg.Text; }
        }
        public string PS_DEsg
        {
            get { return this.TB_DEsg.Text; }
        }
        public string PS_RiVol
        {
            get { return this.TB_RiVol.Text; }
        }
        public string PS_RiPos
        {
            get { return this.TB_RiPos.Text; }
        }
        public string PS_D1Hid
        {
            get { return this.TB_D1Hid.Text; }
        }
        public string PS_D2Hid
        {
            get { return this.TB_D2Hid.Text; }
        }
        public string PS_D3Hid
        {
            get { return this.TB_D3Hid.Text; }
        }
        public string PS_D4Hid
        {
            get { return this.TB_D4Hid.Text; }
        }
        public string PS_DBiPa
        {
            get { return this.TB_DBiPa.Text; }
        }
        public string PS_DBiRi
        {
            get { return this.TB_DBiRi.Text; }
        }
        public string PS_DDT
        {
            get { return this.TB_DDT.Text; }
        }
        public string PS_P1Hid
        {
            get { return this.TB_P1Hid.Text; }
        }
        public string PS_QtdHid
        {
            get { return this.TB_QtdHid.Text; }
        }
        public string PS_Tag
        {
            get { return this.TB_Tag.Text; }
        }
        public string PS_VarMaxMo
        {
            get { return this.TB_VarMaxMo.Text; }
        }
        public string PS_NomeMemorial
        {
            get { return this.TB_NomeMemorial.Text; }
        }
        public string PS_NomeHidrante
        {
            get { return this.TB_NomeHidrante.Text; }
        }
        public string PS_LP_Comprimento
        {
            get { return this.TB_LP_Comprimento.Text; }
        }
        public string PS_LP_PerdaDeCarga
        {
            get { return this.TB_LP_PerdaDeCarga.Text; }
        }
        public string PS_LP_Nivel
        {
            get { return this.TB_LP_Nivel.Text; }
        }
        public string PS_LP_ElevacaoDoNivel
        {
            get { return this.TB_LP_ElevacaoDoNivel.Text; }
        }
        public string PS_LP_Elevacao
        {
            get { return this.TB_LP_Elevacao.Text; }
        }
        public string PS_LP_Diametro
        {
            get { return this.TB_LP_Diametro.Text; }
        }
        public string PS_LP_RaioNominal
        {
            get { return this.TB_LP_RaioNominal.Text; }
        }
        public string PS_FormatoUnidades
        {
            get { return this.TB_FormatoUnidades.Text; }
        }
        #endregion

        IEnumerable<Element> SelectFamilyInstance(string FamilyInstance)
        {
            ElementClassFilter ECF = new ElementClassFilter(typeof(FamilyInstance));
            FilteredElementCollector FEC = new FilteredElementCollector(Doc);
            FEC.WherePasses(ECF);
            var query = from element in FEC where element.Name == FamilyInstance select element;
            return query;
        }
        ElementParameterFilter ElementParameterFilter(BuiltInParameter BIP, string Trecho)
        {
            ElementId EI = new ElementId(BIP);
            ParameterValueProvider PVP = new ParameterValueProvider(EI);
            FilterStringRuleEvaluator FSRE = new FilterStringContains();
            FilterRule FR = new FilterStringRule(PVP, FSRE, Trecho, false);
            ElementParameterFilter EPF = new ElementParameterFilter(FR);
            return EPF;
        }
        void ElementParameterFilter_OMEA(int Matriz, string Trecho, BuiltInParameter BIP, BuiltInCategory BIC)
        {
            ProcessarHid("Trecho " + Trecho + " calculado!");
            FilteredElementCollector FEC = new FilteredElementCollector(Doc);
            ElementCategoryFilter ECF = new ElementCategoryFilter(BIC);
            IList<Element> IL = FEC.WherePasses(ECF).WherePasses(ElementParameterFilter(BIP, Trecho)).ToElements();
            if (Matriz == 1)
            {
                Global.PdC_1Hid_OPA = 0.0;
            }
            if (Matriz == 2)
            {
                Global.PdC_2Hid_OPA = 0.0;
            }
            if (Matriz == 3)
            {
                Global.PdC_3Hid_OPA = 0.0;
            }
            if (Matriz == 4)
            {
                Global.PdC_4Hid_OPA = 0.0;
            }
            if (Matriz == 5)
            {
                Global.PdC_BiPa_OPA = 0.0;
            }
            if (Matriz == 6)
            {
                Global.PdC_BiRi_OPA = 0.0;
            }
            foreach (FamilyInstance FI in IL)
            {
                if (Matriz == 1)
                {
                    Global.Tag1Hid = FI.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);
                    Global.PdC_1Hid_OPA += UnitUtils.ConvertFromInternalUnits(FI.LookupParameter(Global.LP_PerdaDeCarga).AsDouble(), UnitTypeId.Meters);
                }
                if (Matriz == 2)
                {
                    Global.Tag2Hid = FI.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);
                    Global.PdC_2Hid_OPA += UnitUtils.ConvertFromInternalUnits(FI.LookupParameter(Global.LP_PerdaDeCarga).AsDouble(), UnitTypeId.Meters);
                }
                if (Matriz == 3)
                {
                    Global.Tag3Hid = FI.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);
                    Global.PdC_3Hid_OPA += UnitUtils.ConvertFromInternalUnits(FI.LookupParameter(Global.LP_PerdaDeCarga).AsDouble(), UnitTypeId.Meters);
                }
                if (Matriz == 4)
                {
                    Global.Tag4Hid = FI.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);
                    Global.PdC_4Hid_OPA += UnitUtils.ConvertFromInternalUnits(FI.LookupParameter(Global.LP_PerdaDeCarga).AsDouble(), UnitTypeId.Meters);
                }
                if (Matriz == 5)
                {
                    Global.PdC_BiPa_OPA += UnitUtils.ConvertFromInternalUnits(FI.LookupParameter(Global.LP_PerdaDeCarga).AsDouble(), UnitTypeId.Meters);
                }
                if (Matriz == 6)
                {
                    Global.PdC_BiRi_OPA += UnitUtils.ConvertFromInternalUnits(FI.LookupParameter(Global.LP_PerdaDeCarga).AsDouble(), UnitTypeId.Meters);
                }
                Parameter Nivel = FI.LookupParameter(Global.LP_Nivel);
                Parameter ElevacaoNivel = FI.LookupParameter(Global.LP_ElevacaoDoNivel);

                List<Element> L = new List<Element>();
                FilteredElementCollector FEC2 = new FilteredElementCollector(Doc);
                L.AddRange(FEC2.OfClass(typeof(Level)).ToElements());
                foreach (Element E in L)
                {
                    if (E.Name == Nivel.AsValueString())
                    {
                        if (Matriz == 1)
                        {
                            Global.Elevacao_1Hid = E.LookupParameter(Global.LP_Elevacao);
                        }
                        if (Matriz == 2)
                        {
                            Global.Elevacao_2Hid = E.LookupParameter(Global.LP_Elevacao);
                        }
                        if (Matriz == 3)
                        {
                            Global.Elevacao_3Hid = E.LookupParameter(Global.LP_Elevacao);
                        }
                        if (Matriz == 4)
                        {
                            Global.Elevacao_4Hid = E.LookupParameter(Global.LP_Elevacao);
                        }
                        if (Matriz == 8)
                        {
                            Global.Elevacao_PA = E.LookupParameter(Global.LP_Elevacao);
                        }
                        if (Matriz == 9)
                        {
                            Global.Elevacao_BI = E.LookupParameter(Global.LP_Elevacao);
                        }
                        if (Matriz == 10)
                        {
                            Global.Elevacao_RI = E.LookupParameter(Global.LP_Elevacao);
                        }
                        break;
                    }
                }
                if (Matriz == 1)
                {
                    Global.SumElevacao_1Hid = ElevacaoNivel.AsDouble() + Global.Elevacao_1Hid.AsDouble();
                    Global.SumElevacao_1Hid = UnitUtils.ConvertFromInternalUnits(Global.SumElevacao_1Hid, UnitTypeId.Meters);
                }
                if (Matriz == 2)
                {
                    Global.SumElevacao_2Hid = ElevacaoNivel.AsDouble() + Global.Elevacao_2Hid.AsDouble();
                    Global.SumElevacao_2Hid = UnitUtils.ConvertFromInternalUnits(Global.SumElevacao_2Hid, UnitTypeId.Meters);
                }
                if (Matriz == 3)
                {
                    Global.SumElevacao_3Hid = ElevacaoNivel.AsDouble() + Global.Elevacao_3Hid.AsDouble();
                    Global.SumElevacao_3Hid = UnitUtils.ConvertFromInternalUnits(Global.SumElevacao_3Hid, UnitTypeId.Meters);
                }
                if (Matriz == 4)
                {
                    Global.SumElevacao_4Hid = ElevacaoNivel.AsDouble() + Global.Elevacao_4Hid.AsDouble();
                    Global.SumElevacao_4Hid = UnitUtils.ConvertFromInternalUnits(Global.SumElevacao_4Hid, UnitTypeId.Meters);
                }
                if (Matriz == 8)
                {
                    Global.SumElevacao_PA = ElevacaoNivel.AsDouble() + Global.Elevacao_PA.AsDouble();
                    Global.SumElevacao_PA = UnitUtils.ConvertFromInternalUnits(Global.SumElevacao_PA, UnitTypeId.Meters);
                }
                if (Matriz == 9)
                {
                    Global.SumElevacao_BI = ElevacaoNivel.AsDouble() + Global.Elevacao_BI.AsDouble();
                    Global.SumElevacao_BI = UnitUtils.ConvertFromInternalUnits(Global.SumElevacao_BI, UnitTypeId.Meters);
                }
                if (Matriz == 10)
                {
                    Global.SumElevacao_RI = ElevacaoNivel.AsDouble() + Global.Elevacao_RI.AsDouble();
                    Global.SumElevacao_RI = UnitUtils.ConvertFromInternalUnits(Global.SumElevacao_RI, UnitTypeId.Meters);
                }
            }
        }
        void ElementParameterFilter_OPC(int Matriz, string Trecho, BuiltInParameter BIP, BuiltInCategory BIC)
        {
            ProcessarHid("Trecho " + Trecho + " calculado!");
            FilteredElementCollector FEC = new FilteredElementCollector(Doc);
            ElementCategoryFilter ECF = new ElementCategoryFilter(BIC);
            IList<Element> IL = FEC.WherePasses(ECF).WherePasses(ElementParameterFilter(BIP, Trecho)).ToElements();
            if (Matriz == 1)
            {
                Global.SPC_1Hid = 0.0;
            }
            if (Matriz == 2)
            {
                Global.SPC_2Hid = 0.0;
            }
            if (Matriz == 3)
            {
                Global.SPC_3Hid = 0.0;
            }
            if (Matriz == 4)
            {
                Global.SPC_4Hid = 0.0;
            }
            if (Matriz == 5)
            {
                Global.SPC_BiPa = 0.0;
            }
            if (Matriz == 6)
            {
                Global.SPC_BiRi = 0.0;
            }
            foreach (Pipe P in IL)
            {
                if (Matriz == 1)
                {
                    Global.SPC_1Hid += UnitUtils.ConvertFromInternalUnits(P.LookupParameter(Global.LP_Comprimento).AsDouble(), UnitTypeId.Meters);
                }
                if (Matriz == 2)
                {
                    Global.SPC_2Hid += UnitUtils.ConvertFromInternalUnits(P.LookupParameter(Global.LP_Comprimento).AsDouble(), UnitTypeId.Meters);
                }
                if (Matriz == 3)
                {
                    Global.SPC_3Hid += UnitUtils.ConvertFromInternalUnits(P.LookupParameter(Global.LP_Comprimento).AsDouble(), UnitTypeId.Meters);
                }
                if (Matriz == 4)
                {
                    Global.SPC_4Hid += UnitUtils.ConvertFromInternalUnits(P.LookupParameter(Global.LP_Comprimento).AsDouble(), UnitTypeId.Meters);
                }
                if (Matriz == 5)
                {
                    Global.SPC_BiPa += UnitUtils.ConvertFromInternalUnits(P.LookupParameter(Global.LP_Comprimento).AsDouble(), UnitTypeId.Meters);
                }
                if (Matriz == 6)
                {
                    Global.SPC_BiRi += UnitUtils.ConvertFromInternalUnits(P.LookupParameter(Global.LP_Comprimento).AsDouble(), UnitTypeId.Meters);
                }
                Parameter P_D = P.LookupParameter(Global.LP_Diametro);
                using (Transaction T = new Transaction(Doc, "LookupParameter"))
                {
                    if (Matriz == 1)
                    {
                        Global.CTIU = UnitUtils.ConvertToInternalUnits((Global.D1Hid / 1000), UnitTypeId.Meters);
                    }
                    if (Matriz == 2)
                    {
                        Global.CTIU = UnitUtils.ConvertToInternalUnits((Global.D2Hid / 1000), UnitTypeId.Meters);
                    }
                    if (Matriz == 3)
                    {
                        Global.CTIU = UnitUtils.ConvertToInternalUnits((Global.D3Hid / 1000), UnitTypeId.Meters);
                    }
                    if (Matriz == 4)
                    {
                        Global.CTIU = UnitUtils.ConvertToInternalUnits((Global.D4Hid / 1000), UnitTypeId.Meters);
                    }
                    if (Matriz == 5)
                    {
                        Global.CTIU = UnitUtils.ConvertToInternalUnits((Global.DBiPa / 1000), UnitTypeId.Meters);
                    }
                    if (Matriz == 6)
                    {
                        Global.CTIU = UnitUtils.ConvertToInternalUnits((Global.DBiRi / 1000), UnitTypeId.Meters);
                    }
                    if (Matriz == 7)
                    {
                        Global.CTIU = UnitUtils.ConvertToInternalUnits((Global.DDT / 1000), UnitTypeId.Meters);
                    }
                    try
                    {
                        T.Start();
                        P_D.Set(Global.CTIU);
                        T.Commit();
                    }
                    catch (Exception err)
                    {
                        ProcessarHid("Atenção: ElementParameterFilter_OPC " + err.Message);
                        T.RollBack();
                    }
                }
            }
        }

        void ElementParameterFilter_OPF(int Matriz, string Trecho, BuiltInParameter BIP, BuiltInCategory BIC)
        {
            ProcessarHid("Trecho " + Trecho + " calculado!");
            FilteredElementCollector FEC = new FilteredElementCollector(Doc);
            ElementCategoryFilter ECF = new ElementCategoryFilter(BIC);
            IList<Element> IL = FEC.WherePasses(ECF).WherePasses(ElementParameterFilter(BIP, Trecho)).ToElements();
            if (Matriz == 1)
            {
                Global.PdC_1Hid_OPF = 0.0;
            }
            if (Matriz == 2)
            {
                Global.PdC_2Hid_OPF = 0.0;
            }
            if (Matriz == 3)
            {
                Global.PdC_3Hid_OPF = 0.0;
            }
            if (Matriz == 4)
            {
                Global.PdC_4Hid_OPF = 0.0;
            }
            if (Matriz == 5)
            {
                Global.PdC_BiPa_OPF = 0.0;
            }
            if (Matriz == 6)
            {
                Global.PdC_BiRi_OPF = 0.0;
            }
            foreach (FamilyInstance FI in IL)
            {
                if (Matriz == 1)
                {
                    Global.PdC_1Hid_OPF += UnitUtils.ConvertFromInternalUnits(FI.LookupParameter(Global.LP_PerdaDeCarga).AsDouble(), UnitTypeId.Meters);
                }
                if (Matriz == 2)
                {
                    Global.PdC_2Hid_OPF += UnitUtils.ConvertFromInternalUnits(FI.LookupParameter(Global.LP_PerdaDeCarga).AsDouble(), UnitTypeId.Meters);
                }
                if (Matriz == 3)
                {
                    Global.PdC_3Hid_OPF += UnitUtils.ConvertFromInternalUnits(FI.LookupParameter(Global.LP_PerdaDeCarga).AsDouble(), UnitTypeId.Meters);
                }
                if (Matriz == 4)
                {
                    Global.PdC_4Hid_OPF += UnitUtils.ConvertFromInternalUnits(FI.LookupParameter(Global.LP_PerdaDeCarga).AsDouble(), UnitTypeId.Meters);
                }
                if (Matriz == 5)
                {
                    Global.PdC_BiPa_OPF += UnitUtils.ConvertFromInternalUnits(FI.LookupParameter(Global.LP_PerdaDeCarga).AsDouble(), UnitTypeId.Meters);
                }
                if (Matriz == 6)
                {
                    Global.PdC_BiRi_OPF += UnitUtils.ConvertFromInternalUnits(FI.LookupParameter(Global.LP_PerdaDeCarga).AsDouble(), UnitTypeId.Meters);
                }
                Parameter P_D = FI.LookupParameter(Global.LP_RaioNominal);
                using (Transaction T = new Transaction(Doc, "LookupParameter"))
                {
                    if (Matriz == 1)
                    {
                        Global.CTIU = UnitUtils.ConvertToInternalUnits(((Global.D1Hid / 1000) / 2), UnitTypeId.Meters);
                    }
                    if (Matriz == 2)
                    {
                        Global.CTIU = UnitUtils.ConvertToInternalUnits(((Global.D2Hid / 1000) / 2), UnitTypeId.Meters);
                    }
                    if (Matriz == 3)
                    {
                        Global.CTIU = UnitUtils.ConvertToInternalUnits(((Global.D3Hid / 1000) / 2), UnitTypeId.Meters);
                    }
                    if (Matriz == 4)
                    {
                        Global.CTIU = UnitUtils.ConvertToInternalUnits(((Global.D4Hid / 1000) / 2), UnitTypeId.Meters);
                    }
                    if (Matriz == 5)
                    {
                        Global.CTIU = UnitUtils.ConvertToInternalUnits(((Global.DBiPa / 1000) / 2), UnitTypeId.Meters);
                    }
                    if (Matriz == 6)
                    {
                        Global.CTIU = UnitUtils.ConvertToInternalUnits(((Global.DBiRi / 1000) / 2), UnitTypeId.Meters);
                    }
                    if (Matriz == 7)
                    {
                        Global.CTIU = UnitUtils.ConvertToInternalUnits(((Global.DDT / 1000) / 2), UnitTypeId.Meters);
                    }
                    try
                    {
                        T.Start();
                        P_D.Set(Global.CTIU);
                        T.Commit();
                    }
                    catch (Exception err)
                    {
                        ProcessarHid("Atenção: ElementParameterFilter_OPF " + err.Message);
                        T.RollBack();
                    }
                }
            }
        }

        private void btn_calcular_Click(object sender, EventArgs e)
        {
            double.TryParse(PS_D1Hid, out Global.D1Hid);
            double.TryParse(PS_D2Hid, out Global.D2Hid);
            double.TryParse(PS_D3Hid, out Global.D3Hid);
            double.TryParse(PS_D4Hid, out Global.D4Hid);
            double.TryParse(PS_DBiPa, out Global.DBiPa);
            double.TryParse(PS_DBiRi, out Global.DBiRi);
            double.TryParse(PS_DDT, out Global.DDT);
            double.TryParse(PS_VarMaxMo, out Global.VarMaxMo);
            Global.NomeMemorial = PS_NomeMemorial;
            Global.NomeHidrante = PS_NomeHidrante;
            Global.LP_Comprimento = PS_LP_Comprimento;
            Global.LP_PerdaDeCarga = PS_LP_PerdaDeCarga;
            Global.LP_Nivel = PS_LP_Nivel;
            Global.LP_ElevacaoDoNivel = PS_LP_ElevacaoDoNivel;
            Global.LP_Elevacao = PS_LP_Elevacao;
            Global.LP_Diametro = PS_LP_Diametro;
            Global.LP_RaioNominal = PS_LP_RaioNominal;
            Global.FormatoUnidades = PS_FormatoUnidades;

            progressBar.Value = 1;
            ProcessarHid("Coletando informações!");

            #region LookupParameter              
            List<FamilyInstance> FI = SelectFamilyInstance(Global.NomeMemorial).Cast<FamilyInstance>().ToList<FamilyInstance>();
            foreach (Element se in FI)
            {
                Global.P_End = se.LookupParameter("End");
                Global.P_Ocu = se.LookupParameter("Ocu");
                Global.P_Ris = se.LookupParameter("Ris");
                Global.P_RespUso = se.LookupParameter("RespUso");
                Global.P_RespTec = se.LookupParameter("RespTec");
                Global.P_CREA = se.LookupParameter("CREA");
                Global.P_SisTipo = se.LookupParameter("SisTipo");
                Global.P_Norma = se.LookupParameter("Norma");
                Global.P_DMang = se.LookupParameter("DMang");
                Global.P_CMang = se.LookupParameter("CMang");
                Global.P_LMang = se.LookupParameter("LMang");
                Global.P_CTubo = se.LookupParameter("CTubo");
                Global.P_MatTubo = se.LookupParameter("MatTubo");
                Global.P_TipoEsg = se.LookupParameter("TipoEsg");
                Global.P_DEsg = se.LookupParameter("DEsg");
                Global.P_RiVol = se.LookupParameter("RiVol");
                Global.P_RiPos = se.LookupParameter("RiPos");

                Global.P_QtdHid = se.LookupParameter("QtdHid");
                Global.P_JtTotal = se.LookupParameter("JtTotal");
                Global.P_NPSH = se.LookupParameter("NPSH");
                Global.P_Hman = se.LookupParameter("Hman");
                Global.P_QTotal = se.LookupParameter("QTotal");
                Global.P_Pot = se.LookupParameter("Pot");

                Global.P_T1Hid = se.LookupParameter("T1Hid");
                Global.P_T2Hid = se.LookupParameter("T2Hid");
                Global.P_T3Hid = se.LookupParameter("T3Hid");
                Global.P_T4Hid = se.LookupParameter("T4Hid");
                Global.P_TBiPa = se.LookupParameter("TBiPa");
                Global.P_TBiRi = se.LookupParameter("TBiRi");

                Global.P_El1Hid = se.LookupParameter("El1Hid");
                Global.P_El2Hid = se.LookupParameter("El2Hid");
                Global.P_El3Hid = se.LookupParameter("El3Hid");
                Global.P_El4Hid = se.LookupParameter("El4Hid");
                Global.P_ElBiPa = se.LookupParameter("ElBiPa");
                Global.P_ElBiRi = se.LookupParameter("ElBiRi");

                Global.P_Q1Hid = se.LookupParameter("Q1Hid");
                Global.P_Q2Hid = se.LookupParameter("Q2Hid");
                Global.P_Q3Hid = se.LookupParameter("Q3Hid");
                Global.P_Q4Hid = se.LookupParameter("Q4Hid");
                Global.P_QBiPa = se.LookupParameter("QBiPa");
                Global.P_QBiRi = se.LookupParameter("QBiRi");

                Global.P_P1Hid = se.LookupParameter("P1Hid");
                Global.P_P2Hid = se.LookupParameter("P2Hid");
                Global.P_P3Hid = se.LookupParameter("P3Hid");
                Global.P_P4Hid = se.LookupParameter("P4Hid");
                Global.P_PBiPa = se.LookupParameter("PBiPa");
                Global.P_PBiRi = se.LookupParameter("PBiRi");

                Global.P_Je1Hid = se.LookupParameter("Je1Hid");
                Global.P_Je2Hid = se.LookupParameter("Je2Hid");
                Global.P_Je3Hid = se.LookupParameter("Je3Hid");
                Global.P_Je4Hid = se.LookupParameter("Je4Hid");

                Global.P_Jm1Hid = se.LookupParameter("Jm1Hid");
                Global.P_Jm2Hid = se.LookupParameter("Jm2Hid");
                Global.P_Jm3Hid = se.LookupParameter("Jm3Hid");
                Global.P_Jm4Hid = se.LookupParameter("Jm4Hid");

                Global.P_D1Hid = se.LookupParameter("D1Hid");
                Global.P_D2Hid = se.LookupParameter("D2Hid");
                Global.P_D3Hid = se.LookupParameter("D3Hid");
                Global.P_D4Hid = se.LookupParameter("D4Hid");
                Global.P_DBiPa = se.LookupParameter("DBiPa");
                Global.P_DBiRi = se.LookupParameter("DBiRi");

                Global.P_Lr1Hid = se.LookupParameter("Lr1Hid");
                Global.P_Lr2Hid = se.LookupParameter("Lr2Hid");
                Global.P_Lr3Hid = se.LookupParameter("Lr3Hid");
                Global.P_Lr4Hid = se.LookupParameter("Lr4Hid");
                Global.P_LrBiPa = se.LookupParameter("LrBiPa");
                Global.P_LrBiRi = se.LookupParameter("LrBiRi");

                Global.P_Lv1Hid = se.LookupParameter("Lv1Hid");
                Global.P_Lv2Hid = se.LookupParameter("Lv2Hid");
                Global.P_Lv3Hid = se.LookupParameter("Lv3Hid");
                Global.P_Lv4Hid = se.LookupParameter("Lv4Hid");
                Global.P_LvBiPa = se.LookupParameter("LvBiPa");
                Global.P_LvBiRi = se.LookupParameter("LvBiRi");

                Global.P_Lt1Hid = se.LookupParameter("Lt1Hid");
                Global.P_Lt2Hid = se.LookupParameter("Lt2Hid");
                Global.P_Lt3Hid = se.LookupParameter("Lt3Hid");
                Global.P_Lt4Hid = se.LookupParameter("Lt4Hid");
                Global.P_LtBiPa = se.LookupParameter("LtBiPa");
                Global.P_LtBiRi = se.LookupParameter("LtBiRi");

                Global.P_Ju1Hid = se.LookupParameter("Ju1Hid");
                Global.P_Ju2Hid = se.LookupParameter("Ju2Hid");
                Global.P_Ju3Hid = se.LookupParameter("Ju3Hid");
                Global.P_Ju4Hid = se.LookupParameter("Ju4Hid");
                Global.P_JuBiPa = se.LookupParameter("JuBiPa");
                Global.P_JuBiRi = se.LookupParameter("JuBiRi");

                Global.P_Jt1Hid = se.LookupParameter("Jt1Hid");
                Global.P_Jt2Hid = se.LookupParameter("Jt2Hid");
                Global.P_Jt3Hid = se.LookupParameter("Jt3Hid");
                Global.P_Jt4Hid = se.LookupParameter("Jt4Hid");
                Global.P_JtBiPa = se.LookupParameter("JtBiPa");
                Global.P_JtBiRi = se.LookupParameter("JtBiRi");

                Global.P_Ve1Hid = se.LookupParameter("Ve1Hid");
                Global.P_Ve2Hid = se.LookupParameter("Ve2Hid");
                Global.P_Ve3Hid = se.LookupParameter("Ve3Hid");
                Global.P_Ve4Hid = se.LookupParameter("Ve4Hid");
                Global.P_VeBiPa = se.LookupParameter("VeBiPa");
                Global.P_VeBiRi = se.LookupParameter("VeBiRi");

                Global.P_Mo1Hid = se.LookupParameter("Mo1Hid");
                Global.P_Mo2Hid = se.LookupParameter("Mo2Hid");
                Global.P_Mo3Hid = se.LookupParameter("Mo3Hid");
                Global.P_Mo4Hid = se.LookupParameter("Mo4Hid");
                Global.P_MoBiPa = se.LookupParameter("MoBiPa");
                Global.P_MoBiRi = se.LookupParameter("MoBiRi");

                Global.P_VarMCA1 = se.LookupParameter("VarMCA1");
                Global.P_VarMCA2 = se.LookupParameter("VarMCA2");
                Global.P_VarMCA3 = se.LookupParameter("VarMCA3");
            }
            #endregion

            Global.QtdHid = Convert.ToInt32(TB_QtdHid.Text);
            statusCalculo.Text = "Cálculo para " + Global.QtdHid.ToString() + " hidrantes!";

            List<FamilyInstance> L_CountHid = SelectFamilyInstance(Global.NomeHidrante).Cast<FamilyInstance>().ToList<FamilyInstance>();
            int QtdHid = L_CountHid.Count();
            if (QtdHid > 0)
            {
                int SeqHid = 0;
                foreach (Element E_CountHid in L_CountHid)
                {
                    Parameter TagHid = E_CountHid.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);
                    SeqHid += 1;

                    using (Transaction T_CountHid = new Transaction(Doc, "T_CountHid"))
                    {
                        try
                        {
                            T_CountHid.Start();
                            TagHid.Set(PS_Tag + SeqHid.ToString());
                            T_CountHid.Commit();
                        }
                        catch (Exception err)
                        {
                            ProcessarHid("Atenção: QtdHid " + err.Message);
                            T_CountHid.RollBack();
                        }
                    }
                    ProcessarHid("Identificando o hidrante: " + PS_Tag + SeqHid.ToString());
                }
            }

            progressBar.Value = 5;

            #region 1Hid
            ElementParameterFilter_OMEA(1, Global.PHid, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_MechanicalEquipment);
            ElementParameterFilter_OPC(1, Global.PHid, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_PipeCurves);
            ElementParameterFilter_OPF(1, Global.PHid, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_PipeFitting);
            #endregion

            progressBar.Value = 10;

            #region 2Hid
            if (Global.QtdHid == 2 || Global.QtdHid == 3 || Global.QtdHid == 4)
            {
                ElementParameterFilter_OMEA(2, Global.SHid, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_MechanicalEquipment);
                ElementParameterFilter_OPC(2, Global.SHid, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_PipeCurves);
                ElementParameterFilter_OPF(2, Global.SHid, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_PipeFitting);
            }
            else
            {
                Global.SPC_2Hid = 0;
                Global.SumElevacao_2Hid = 0;
                Global.PdC_2Hid_OPA = 0;
                Global.PdC_2Hid_OPF = 0;
            }
            #endregion

            progressBar.Value = 15;

            #region 3Hid
            if (Global.QtdHid == 3 || Global.QtdHid == 4)
            {
                ElementParameterFilter_OMEA(3, Global.THid, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_MechanicalEquipment);
                ElementParameterFilter_OPC(3, Global.THid, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_PipeCurves);
                ElementParameterFilter_OPF(3, Global.THid, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_PipeFitting);
            }
            else
            {
                Global.SPC_3Hid = 0;
                Global.SumElevacao_3Hid = 0;
                Global.PdC_3Hid_OPA = 0;
                Global.PdC_3Hid_OPF = 0;
            }
            #endregion

            progressBar.Value = 20;

            #region 4Hid
            if (Global.QtdHid == 4)
            {
                ElementParameterFilter_OMEA(4, Global.QHid, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_MechanicalEquipment);
                ElementParameterFilter_OPC(4, Global.QHid, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_PipeCurves);
                ElementParameterFilter_OPF(4, Global.QHid, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_PipeFitting);
            }
            else
            {
                Global.SPC_4Hid = 0;
                Global.SumElevacao_4Hid = 0;
                Global.PdC_4Hid_OPA = 0;
                Global.PdC_4Hid_OPF = 0;
            }
            #endregion

            progressBar.Value = 25;

            #region BiPa                 
            ElementParameterFilter_OMEA(5, Global.BiPa, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_PipeAccessory);
            ElementParameterFilter_OPC(5, Global.BiPa, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_PipeCurves);
            ElementParameterFilter_OPF(5, Global.BiPa, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_PipeFitting);
            #endregion

            progressBar.Value = 30;

            #region BiRi                 
            ElementParameterFilter_OMEA(6, Global.BiRi, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_PipeAccessory);
            ElementParameterFilter_OPC(6, Global.BiRi, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_PipeCurves);
            ElementParameterFilter_OPF(6, Global.BiRi, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_PipeFitting);
            #endregion

            progressBar.Value = 35;

            #region DDT                                
            ElementParameterFilter_OPC(7, Global.TrechoDT, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_PipeCurves);
            ElementParameterFilter_OPF(7, Global.TrechoDT, BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS, BuiltInCategory.OST_PipeFitting);
            #endregion

            progressBar.Value = 40;

            #region Localiza a cota Y do ponto PA
            ElementParameterFilter_OMEA(8, Global.PA, BuiltInParameter.ALL_MODEL_MARK, BuiltInCategory.OST_PipeFitting);
            #endregion

            progressBar.Value = 45;

            #region Localiza a cota Y do ponto BI
            ElementParameterFilter_OMEA(9, Global.BI, BuiltInParameter.ALL_MODEL_MARK, BuiltInCategory.OST_MechanicalEquipment);
            #endregion

            progressBar.Value = 50;

            #region Localiza a cota Y do ponto RI
            ElementParameterFilter_OMEA(10, Global.RI, BuiltInParameter.ALL_MODEL_MARK, BuiltInCategory.OST_MechanicalEquipment);
            #endregion

            progressBar.Value = 55;

            #region Elevação
            double El1Hid = Global.SumElevacao_PA >= Global.SumElevacao_1Hid ?
                (Global.SumElevacao_PA - Global.SumElevacao_1Hid) * -1 :
                (Global.SumElevacao_PA <= Global.SumElevacao_1Hid ?
                Global.SumElevacao_1Hid - Global.SumElevacao_PA : 0);

            double El2Hid = Global.SumElevacao_PA >= Global.SumElevacao_2Hid ?
                (Global.SumElevacao_PA - Global.SumElevacao_2Hid) * -1 :
                (Global.SumElevacao_PA <= Global.SumElevacao_2Hid ?
                Global.SumElevacao_2Hid - Global.SumElevacao_PA : 0);
            if (Global.QtdHid < 2) El2Hid = 0;

            double El3Hid = Global.SumElevacao_PA >= Global.SumElevacao_3Hid ?
                (Global.SumElevacao_PA - Global.SumElevacao_3Hid) * -1 :
                (Global.SumElevacao_PA <= Global.SumElevacao_3Hid ?
                Global.SumElevacao_3Hid - Global.SumElevacao_PA : 0);
            if (Global.QtdHid < 3) El3Hid = 0;

            double El4Hid = Global.SumElevacao_PA >= Global.SumElevacao_4Hid ?
                (Global.SumElevacao_PA - Global.SumElevacao_4Hid) * -1 :
                (Global.SumElevacao_PA <= Global.SumElevacao_4Hid ?
                Global.SumElevacao_4Hid - Global.SumElevacao_PA : 0);
            if (Global.QtdHid < 4) El4Hid = 0;

            Global.SumElevacao_BI = Global.SumElevacao_BI + 0.16;
            double ElBiPa = Global.SumElevacao_BI >= Global.SumElevacao_PA ?
                (Global.SumElevacao_BI - Global.SumElevacao_PA) * -1 :
                (Global.SumElevacao_BI <= Global.SumElevacao_PA ?
                Global.SumElevacao_PA - Global.SumElevacao_BI : 0);

            double ElBiRi = Global.SumElevacao_RI >= Global.SumElevacao_BI ?
                (Global.SumElevacao_RI - Global.SumElevacao_BI) * -1 :
                (Global.SumElevacao_RI <= Global.SumElevacao_BI ?
                Global.SumElevacao_BI - Global.SumElevacao_RI : 0);
            #endregion

            ProcessarHid("Identificando as elevações!");
            progressBar.Value = 60;

            double P1Hid; double.TryParse(PS_P1Hid, out P1Hid);

            double DEsg; double.TryParse(PS_DEsg, out DEsg);

            double CMang; double.TryParse(PS_CMang, out CMang);
            double DMang; double.TryParse(PS_DMang, out DMang);
            double LMang; double.TryParse(PS_LMang, out LMang);

            double CTubo; double.TryParse(PS_CTubo, out CTubo);

            double Lt1Hid = Global.SPC_1Hid + Global.PdC_1Hid_OPA + Global.PdC_1Hid_OPF;
            double Lt2Hid = Global.SPC_2Hid + Global.PdC_2Hid_OPA + Global.PdC_2Hid_OPF;
            double Lt3Hid = Global.SPC_3Hid + Global.PdC_3Hid_OPA + Global.PdC_3Hid_OPF;
            double Lt4Hid = Global.SPC_4Hid + Global.PdC_4Hid_OPA + Global.PdC_4Hid_OPF;
            double LtBiPa = Global.SPC_BiPa + Global.PdC_BiPa_OPA + Global.PdC_BiPa_OPF;
            double LtBiRi = Global.SPC_BiRi + Global.PdC_BiRi_OPA + Global.PdC_BiRi_OPF;

            if (Global.QtdHid < 2) { Lt2Hid = 0; Lt3Hid = 0; Lt4Hid = 0; }
            if (Global.QtdHid < 3) { Lt3Hid = 0; Lt4Hid = 0; }
            if (Global.QtdHid < 4) { Lt4Hid = 0; }

            double Q1Hid = (Math.PI * Math.Pow((DEsg / 1000), 2) / 4) * Math.Sqrt(2 * 9.81 * P1Hid) * 60000;
            double Je1Hid = (PS_SisTipo == "na mangueira e no esguicho" ?
                (0.1 * (Math.Pow((Q1Hid / 60000) / (Math.PI * Math.Pow(DEsg / 1000, 2) / 4), 2)) / (2 * 9.81)) : 0);
            double Jm1Hid = (PS_SisTipo == "na mangueira e no esguicho" ?
            (10.643 * Math.Pow(Q1Hid / 60000, 1.85) * Math.Pow(CMang, -1.85) * Math.Pow(DMang / 1000, -4.87) * LMang) : 0);
            double Ju1Hid = 10.643 * Math.Pow(Q1Hid / 60000, 1.85) * Math.Pow(CTubo, -1.85) * Math.Pow(Global.D1Hid / 1000, -4.87);
            double Jt1Hid = Lt1Hid * Ju1Hid;
            double Mo1Hid = El1Hid + P1Hid + Je1Hid + Jm1Hid + Jt1Hid;

            ProcessarHid("Equilibrando as pressões 1HID");
            progressBar.Value = 65;

            double Var1, P2Hid, Q2Hid, Je2Hid, Jm2Hid, Ju2Hid, Jt2Hid, Mo2Hid;
            double P2Hid_do = P1Hid;
            int i1 = 0;
            do
            {
                i1++;
                P2Hid_do += 0.1;
                P2Hid = P2Hid_do;
                Q2Hid = (Math.PI * Math.Pow((DEsg / 1000), 2) / 4) * Math.Sqrt(2 * 9.81 * P2Hid) * 60000;
                Je2Hid = (PS_SisTipo == "na mangueira e no esguicho" ? (0.1 * (Math.Pow((Q2Hid / 60000) / (Math.PI * Math.Pow(DEsg / 1000, 2) / 4), 2)) / (2 * 9.81)) : 0);
                Jm2Hid = (PS_SisTipo == "na mangueira e no esguicho" ? (10.643 * Math.Pow(Q2Hid / 60000, 1.85) * Math.Pow(CMang, -1.85) * Math.Pow(DMang / 1000, -4.87) * LMang) : 0);
                Ju2Hid = 10.643 * Math.Pow(Q2Hid / 60000, 1.85) * Math.Pow(CTubo, -1.85) * Math.Pow(Global.D2Hid / 1000, -4.87);
                Jt2Hid = Lt2Hid * Ju2Hid;
                Mo2Hid = El2Hid + P2Hid + Je2Hid + Jm2Hid + Jt2Hid;
                Var1 = Math.Abs(Mo2Hid - Mo1Hid);
                //TaskDialog.Show("erro", 
                //    String.Format(
                //        "i1: {0}\n P2Hid_do: {1}\n P2Hid: {2}\n Q2Hid: {3}\n Je2Hid: {4}\n Jm2Hid: {5}\n Ju2Hid: {6}\n Jt2Hid: {7}\n Mo2Hid: {8}\n Var1: {9}\n\n" +
                //        "Q1Hid: {10}\n Je1Hid: {11}\n Jm1Hid: {12}\n Ju1Hid: {13}\n Jt1Hid: {14}\n Mo1Hid: {15}\n  Global.VarMaxMo: {16}",
                //    i1, P2Hid_do, P2Hid, Q2Hid, Je2Hid, Jm2Hid, Ju2Hid, Jt2Hid, Mo2Hid, Var1, Q1Hid, Je1Hid, Jm1Hid, Ju1Hid, Jt1Hid, Mo1Hid, Global.VarMaxMo));
            }
            while (Var1 > Global.VarMaxMo && Global.QtdHid >= 2 && i1 < 100);
            if (Global.QtdHid < 2) { Q2Hid = 0; P2Hid = 0; Je2Hid = 0; Jm2Hid = 0; Global.D2Hid = 0; Ju2Hid = 0; Jt2Hid = 0; Mo2Hid = 0; Var1 = 0; }

            ProcessarHid("Equilibrando as pressões 2HID");
            if (Var1 > Global.VarMaxMo) TaskDialog.Show("Erro", "A indicação dos trechos está incorreta. \nLimpe o sistema e realize a identificação novamente!");
            progressBar.Value = 70;

            double Var2, P3Hid, Q3Hid, Je3Hid, Jm3Hid, Ju3Hid, Jt3Hid, Mo3Hid;
            double P3Hid_do = P2Hid;
            int i2 = 0;
            do
            {
                i2++;
                P3Hid_do += 0.1;
                P3Hid = P3Hid_do;
                Q3Hid = (Math.PI * Math.Pow((DEsg / 1000), 2) / 4) * Math.Sqrt(2 * 9.81 * P3Hid) * 60000;
                Je3Hid = (PS_SisTipo == "na mangueira e no esguicho" ? (0.1 * (Math.Pow((Q3Hid / 60000) / (Math.PI * Math.Pow(DEsg / 1000, 2) / 4), 2)) / (2 * 9.81)) : 0);
                Jm3Hid = (PS_SisTipo == "na mangueira e no esguicho" ? (10.643 * Math.Pow(Q3Hid / 60000, 1.85) * Math.Pow(CMang, -1.85) * Math.Pow(DMang / 1000, -4.87) * LMang) : 0);
                Ju3Hid = 10.643 * Math.Pow(Q3Hid / 60000, 1.85) * Math.Pow(CTubo, -1.85) * Math.Pow(Global.D3Hid / 1000, -4.87);
                Jt3Hid = Lt3Hid * Ju3Hid;
                Mo3Hid = El3Hid + P3Hid + Je3Hid + Jm3Hid + Jt3Hid;
                Var2 = Math.Abs(Mo3Hid - Mo2Hid);
            }
            while (Var2 > Global.VarMaxMo && Global.QtdHid >= 3 && i2 < 100);
            if (Global.QtdHid < 3) { Q3Hid = 0; P3Hid = 0; Je3Hid = 0; Jm3Hid = 0; Global.D3Hid = 0; Ju3Hid = 0; Jt3Hid = 0; Mo3Hid = 0; Var2 = 0; }

            ProcessarHid("Equilibrando as pressões 3HID");
            if (Var2 > Global.VarMaxMo) TaskDialog.Show("Erro", "A indicação dos trechos está incorreta. \nLimpe o sistema e realize a identificação novamente!");
            progressBar.Value = 80;

            double Var3, P4Hid, Q4Hid, Je4Hid, Jm4Hid, Ju4Hid, Jt4Hid, Mo4Hid;
            double P4Hid_do = P3Hid;
            int i3 = 0;
            do
            {
                i3++;
                P4Hid_do += 0.1;
                P4Hid = P4Hid_do;
                Q4Hid = (Math.PI * Math.Pow((DEsg / 1000), 2) / 4) * Math.Sqrt(2 * 9.81 * P4Hid) * 60000;
                Je4Hid = (PS_SisTipo == "na mangueira e no esguicho" ? (0.1 * (Math.Pow((Q4Hid / 60000) / (Math.PI * Math.Pow(DEsg / 1000, 2) / 4), 2)) / (2 * 9.81)) : 0);
                Jm4Hid = (PS_SisTipo == "na mangueira e no esguicho" ? (10.643 * Math.Pow(Q4Hid / 60000, 1.85) * Math.Pow(CMang, -1.85) * Math.Pow(DMang / 1000, -4.87) * LMang) : 0);
                Ju4Hid = 10.643 * Math.Pow(Q4Hid / 60000, 1.85) * Math.Pow(CTubo, -1.85) * Math.Pow(Global.D4Hid / 1000, -4.87);
                Jt4Hid = Lt4Hid * Ju4Hid;
                Mo4Hid = El4Hid + P4Hid + Je4Hid + Jm4Hid + Jt4Hid;
                Var3 = Math.Abs(Mo4Hid - Mo3Hid);
            }
            while (Var3 > Global.VarMaxMo && Global.QtdHid >= 4 && i3 < 100);
            if (Global.QtdHid < 4) { Q4Hid = 0; P4Hid = 0; Je4Hid = 0; Jm4Hid = 0; Global.D4Hid = 0; Ju4Hid = 0; Jt4Hid = 0; Mo4Hid = 0; Var3 = 0; }

            ProcessarHid("Equilibrando as pressões 4HID");
            if (Var3 > Global.VarMaxMo) TaskDialog.Show("Erro", "A indicação dos trechos está incorreta. \nLimpe o sistema e realize a identificação novamente!");
            progressBar.Value = 90;

            double PBiPa = Math.Max(Math.Max(Math.Max(Mo1Hid, Mo2Hid), Mo3Hid), Mo4Hid);
            double QBiPa = Q1Hid + Q2Hid + Q3Hid + Q4Hid;
            double JuBiPa = 10.643 * Math.Pow(QBiPa / 60000, 1.85) * Math.Pow(CTubo, -1.85) * Math.Pow(Global.DBiPa / 1000, -4.87);
            double JtBiPa = LtBiPa * JuBiPa;
            double MoBiPa = ElBiPa + PBiPa + JtBiPa;

            double PBiRi = MoBiPa;
            double QBiRi = QBiPa;
            double JuBiRi = 10.643 * Math.Pow(QBiRi / 60000, 1.85) * Math.Pow(CTubo, -1.85) * Math.Pow(Global.DBiRi / 1000, -4.87);
            double JtBiRi = LtBiRi * JuBiRi;
            double MoBiRi = ElBiRi + PBiRi + JtBiRi;

            double Ve1Hid = (Q1Hid / 60000) / (Math.Pow((Global.D1Hid / 2000), 2) * 3.1416);
            double Ve2Hid = (Q2Hid / 60000) / (Math.Pow((Global.D2Hid / 2000), 2) * 3.1416);
            if (Global.QtdHid < 2) Ve2Hid = 0;
            double Ve3Hid = (Q3Hid / 60000) / (Math.Pow((Global.D3Hid / 2000), 2) * 3.1416);
            if (Global.QtdHid < 3) Ve3Hid = 0;
            double Ve4Hid = (Q4Hid / 60000) / (Math.Pow((Global.D4Hid / 2000), 2) * 3.1416);
            if (Global.QtdHid < 4) Ve4Hid = 0;
            double VeBiPa = (QBiPa / 60000) / (Math.Pow((Global.DBiPa / 2000), 2) * 3.1416);
            double VeBiRi = (QBiRi / 60000) / (Math.Pow((Global.DBiRi / 2000), 2) * 3.1416);

            double JtTotal = 10.643 * Math.Pow(1.5 * QBiPa / 60000, 1.85) * Math.Pow(CTubo, -1.85) * Math.Pow(Global.DBiRi / 1000, -4.87) * LtBiRi;
            double NPSH = 10.33 - 0.24 - JtTotal - ElBiRi - 0.5;
            double Hman = Math.Max(MoBiPa, MoBiRi);
            double Pot = (1000 * Hman * (QBiRi / 60000)) / (75 * 0.6);

            double QTotal = QBiRi;

            ProcessarHid("Equilibrando as pressões do sistema");
            progressBar.Value = 100;

            #region SetParameter
            using (Transaction t = new Transaction(Doc, "parameter"))
            {
                try
                {
                    t.Start();
                    Global.P_End.Set(PS_End);
                    Global.P_Ocu.Set(PS_Ocu);
                    Global.P_Ris.Set(PS_Ris);
                    Global.P_RespUso.Set(PS_RespUso);
                    Global.P_RespTec.Set(PS_RespTec);
                    Global.P_CREA.Set(PS_CREA);
                    Global.P_Norma.Set(PS_Norma);
                    Global.P_DMang.Set(PS_DMang);
                    Global.P_CMang.Set(PS_CMang);
                    Global.P_LMang.Set(PS_LMang);
                    Global.P_CTubo.Set(PS_CTubo);
                    Global.P_MatTubo.Set(PS_MatTubo);
                    Global.P_TipoEsg.Set(PS_TipoEsg);
                    Global.P_DEsg.Set(PS_DEsg);
                    Global.P_RiVol.Set(PS_RiVol);
                    Global.P_RiPos.Set(PS_RiPos);

                    Global.P_QtdHid.Set(QtdHid.ToString());
                    Global.P_JtTotal.Set(JtTotal == 0 ? "-" : JtTotal.ToString(Global.FormatoUnidades));
                    Global.P_NPSH.Set(NPSH == 0 ? "-" : NPSH.ToString(Global.FormatoUnidades));
                    Global.P_Hman.Set(Hman == 0 ? "-" : Hman.ToString(Global.FormatoUnidades));
                    Global.P_QTotal.Set(QTotal == 0 ? "-" : QTotal.ToString(Global.FormatoUnidades));
                    Global.P_Pot.Set(Pot == 0 ? "-" : Pot.ToString(Global.FormatoUnidades));

                    Global.P_T1Hid.Set(Global.Tag1Hid.AsString() + "-" + Global.PA);
                    Global.P_T2Hid.Set(Global.QtdHid >= 2 ? Global.Tag2Hid.AsString() + "-" + Global.PA : "-");
                    Global.P_T3Hid.Set(Global.QtdHid >= 3 ? Global.Tag3Hid.AsString() + "-" + Global.PA : "-");
                    Global.P_T4Hid.Set(Global.QtdHid >= 4 ? Global.Tag4Hid.AsString() + "-" + Global.PA : "-");
                    Global.P_TBiPa.Set(Global.BiPa);
                    Global.P_TBiRi.Set(Global.BiRi);

                    Global.P_El1Hid.Set(El1Hid == 0 ? "-" : El1Hid.ToString(Global.FormatoUnidades));
                    Global.P_El2Hid.Set(El2Hid == 0 ? "-" : El2Hid.ToString(Global.FormatoUnidades));
                    Global.P_El3Hid.Set(El3Hid == 0 ? "-" : El3Hid.ToString(Global.FormatoUnidades));
                    Global.P_El4Hid.Set(El4Hid == 0 ? "-" : El4Hid.ToString(Global.FormatoUnidades));
                    Global.P_ElBiPa.Set(ElBiPa == 0 ? "-" : ElBiPa.ToString(Global.FormatoUnidades));
                    Global.P_ElBiRi.Set(ElBiRi == 0 ? "-" : ElBiRi.ToString(Global.FormatoUnidades));

                    Global.P_Q1Hid.Set(Q1Hid == 0 ? "-" : Q1Hid.ToString(Global.FormatoUnidades));
                    Global.P_Q2Hid.Set(Q2Hid == 0 ? "-" : Q2Hid.ToString(Global.FormatoUnidades));
                    Global.P_Q3Hid.Set(Q3Hid == 0 ? "-" : Q3Hid.ToString(Global.FormatoUnidades));
                    Global.P_Q4Hid.Set(Q4Hid == 0 ? "-" : Q4Hid.ToString(Global.FormatoUnidades));
                    Global.P_QBiPa.Set(QBiPa == 0 ? "-" : QBiPa.ToString(Global.FormatoUnidades));
                    Global.P_QBiRi.Set(QBiRi == 0 ? "-" : QBiRi.ToString(Global.FormatoUnidades));

                    Global.P_P1Hid.Set(P1Hid == 0 ? "-" : P1Hid.ToString(Global.FormatoUnidades));
                    Global.P_P2Hid.Set(P2Hid == 0 ? "-" : P2Hid.ToString(Global.FormatoUnidades));
                    Global.P_P3Hid.Set(P3Hid == 0 ? "-" : P3Hid.ToString(Global.FormatoUnidades));
                    Global.P_P4Hid.Set(P4Hid == 0 ? "-" : P4Hid.ToString(Global.FormatoUnidades));
                    Global.P_PBiPa.Set(PBiPa == 0 ? "-" : PBiPa.ToString(Global.FormatoUnidades));
                    Global.P_PBiRi.Set(PBiRi == 0 ? "-" : PBiRi.ToString(Global.FormatoUnidades));

                    Global.P_Je1Hid.Set(Je1Hid == 0 ? "-" : Je1Hid.ToString(Global.FormatoUnidades));
                    Global.P_Je2Hid.Set(Je2Hid == 0 ? "-" : Je2Hid.ToString(Global.FormatoUnidades));
                    Global.P_Je3Hid.Set(Je3Hid == 0 ? "-" : Je3Hid.ToString(Global.FormatoUnidades));
                    Global.P_Je4Hid.Set(Je4Hid == 0 ? "-" : Je4Hid.ToString(Global.FormatoUnidades));

                    Global.P_Jm1Hid.Set(Jm1Hid == 0 ? "-" : Jm1Hid.ToString(Global.FormatoUnidades));
                    Global.P_Jm2Hid.Set(Jm2Hid == 0 ? "-" : Jm2Hid.ToString(Global.FormatoUnidades));
                    Global.P_Jm3Hid.Set(Jm3Hid == 0 ? "-" : Jm3Hid.ToString(Global.FormatoUnidades));
                    Global.P_Jm4Hid.Set(Jm4Hid == 0 ? "-" : Jm4Hid.ToString(Global.FormatoUnidades));

                    Global.P_D1Hid.Set(PS_D1Hid);
                    Global.P_D2Hid.Set(Global.D2Hid == 0 ? "-" : Global.D2Hid.ToString());
                    Global.P_D3Hid.Set(Global.D3Hid == 0 ? "-" : Global.D3Hid.ToString());
                    Global.P_D4Hid.Set(Global.D4Hid == 0 ? "-" : Global.D4Hid.ToString());
                    Global.P_DBiPa.Set(PS_DBiPa);
                    Global.P_DBiRi.Set(PS_DBiRi);

                    Global.P_Lr1Hid.Set(Global.SPC_1Hid == 0 ? "-" : Global.SPC_1Hid.ToString(Global.FormatoUnidades));
                    Global.P_Lr2Hid.Set(Global.SPC_2Hid == 0 ? "-" : Global.SPC_2Hid.ToString(Global.FormatoUnidades));
                    Global.P_Lr3Hid.Set(Global.SPC_3Hid == 0 ? "-" : Global.SPC_3Hid.ToString(Global.FormatoUnidades));
                    Global.P_Lr4Hid.Set(Global.SPC_4Hid == 0 ? "-" : Global.SPC_4Hid.ToString(Global.FormatoUnidades));
                    Global.P_LrBiPa.Set(Global.SPC_BiPa == 0 ? "-" : Global.SPC_BiPa.ToString(Global.FormatoUnidades));
                    Global.P_LrBiRi.Set(Global.SPC_BiRi == 0 ? "-" : Global.SPC_BiRi.ToString(Global.FormatoUnidades));

                    Global.P_Lv1Hid.Set((Global.PdC_1Hid_OPA + Global.PdC_1Hid_OPF) == 0 ? "-" : (Global.PdC_1Hid_OPA + Global.PdC_1Hid_OPF).ToString(Global.FormatoUnidades));
                    Global.P_Lv2Hid.Set((Global.PdC_2Hid_OPA + Global.PdC_2Hid_OPF) == 0 ? "-" : (Global.PdC_2Hid_OPA + Global.PdC_2Hid_OPF).ToString(Global.FormatoUnidades));
                    Global.P_Lv3Hid.Set((Global.PdC_3Hid_OPA + Global.PdC_3Hid_OPF) == 0 ? "-" : (Global.PdC_3Hid_OPA + Global.PdC_3Hid_OPF).ToString(Global.FormatoUnidades));
                    Global.P_Lv4Hid.Set((Global.PdC_4Hid_OPA + Global.PdC_4Hid_OPF) == 0 ? "-" : (Global.PdC_4Hid_OPA + Global.PdC_4Hid_OPF).ToString(Global.FormatoUnidades));
                    Global.P_LvBiPa.Set((Global.PdC_BiPa_OPA + Global.PdC_BiPa_OPF) == 0 ? "-" : (Global.PdC_BiPa_OPA + Global.PdC_BiPa_OPF).ToString(Global.FormatoUnidades));
                    Global.P_LvBiRi.Set((Global.PdC_BiRi_OPA + Global.PdC_BiRi_OPF) == 0 ? "-" : (Global.PdC_BiRi_OPA + Global.PdC_BiRi_OPF).ToString(Global.FormatoUnidades));

                    Global.P_Lt1Hid.Set(Lt1Hid == 0 ? "-" : Lt1Hid.ToString(Global.FormatoUnidades));
                    Global.P_Lt2Hid.Set(Lt2Hid == 0 ? "-" : Lt2Hid.ToString(Global.FormatoUnidades));
                    Global.P_Lt3Hid.Set(Lt3Hid == 0 ? "-" : Lt3Hid.ToString(Global.FormatoUnidades));
                    Global.P_Lt4Hid.Set(Lt4Hid == 0 ? "-" : Lt4Hid.ToString(Global.FormatoUnidades));
                    Global.P_LtBiPa.Set(LtBiPa == 0 ? "-" : LtBiPa.ToString(Global.FormatoUnidades));
                    Global.P_LtBiRi.Set(LtBiRi == 0 ? "-" : LtBiRi.ToString(Global.FormatoUnidades));

                    Global.P_Ju1Hid.Set(Ju1Hid == 0 ? "-" : Ju1Hid.ToString(Global.FormatoUnidades));
                    Global.P_Ju2Hid.Set(Ju2Hid == 0 ? "-" : Ju2Hid.ToString(Global.FormatoUnidades));
                    Global.P_Ju3Hid.Set(Ju3Hid == 0 ? "-" : Ju3Hid.ToString(Global.FormatoUnidades));
                    Global.P_Ju4Hid.Set(Ju4Hid == 0 ? "-" : Ju4Hid.ToString(Global.FormatoUnidades));
                    Global.P_JuBiPa.Set(JuBiPa == 0 ? "-" : JuBiPa.ToString(Global.FormatoUnidades));
                    Global.P_JuBiRi.Set(JuBiRi == 0 ? "-" : JuBiRi.ToString(Global.FormatoUnidades));

                    Global.P_Jt1Hid.Set(Jt1Hid == 0 ? "-" : Jt1Hid.ToString(Global.FormatoUnidades));
                    Global.P_Jt2Hid.Set(Jt2Hid == 0 ? "-" : Jt2Hid.ToString(Global.FormatoUnidades));
                    Global.P_Jt3Hid.Set(Jt3Hid == 0 ? "-" : Jt3Hid.ToString(Global.FormatoUnidades));
                    Global.P_Jt4Hid.Set(Jt4Hid == 0 ? "-" : Jt4Hid.ToString(Global.FormatoUnidades));
                    Global.P_JtBiPa.Set(JtBiPa == 0 ? "-" : JtBiPa.ToString(Global.FormatoUnidades));
                    Global.P_JtBiRi.Set(JtBiRi == 0 ? "-" : JtBiRi.ToString(Global.FormatoUnidades));

                    Global.P_Ve1Hid.Set(Ve1Hid == 0 ? "-" : Ve1Hid.ToString(Global.FormatoUnidades));
                    Global.P_Ve2Hid.Set(Ve2Hid == 0 ? "-" : Ve2Hid.ToString(Global.FormatoUnidades));
                    Global.P_Ve3Hid.Set(Ve3Hid == 0 ? "-" : Ve3Hid.ToString(Global.FormatoUnidades));
                    Global.P_Ve4Hid.Set(Ve4Hid == 0 ? "-" : Ve4Hid.ToString(Global.FormatoUnidades));
                    Global.P_VeBiPa.Set(VeBiPa == 0 ? "-" : VeBiPa.ToString(Global.FormatoUnidades));
                    Global.P_VeBiRi.Set(VeBiRi == 0 ? "-" : VeBiRi.ToString(Global.FormatoUnidades));

                    Global.P_Mo1Hid.Set(Mo1Hid == 0 ? "-" : Mo1Hid.ToString(Global.FormatoUnidades));
                    Global.P_Mo2Hid.Set(Mo2Hid == 0 ? "-" : Mo2Hid.ToString(Global.FormatoUnidades));
                    Global.P_Mo3Hid.Set(Mo3Hid == 0 ? "-" : Mo3Hid.ToString(Global.FormatoUnidades));
                    Global.P_Mo4Hid.Set(Mo4Hid == 0 ? "-" : Mo4Hid.ToString(Global.FormatoUnidades));
                    Global.P_MoBiPa.Set(MoBiPa == 0 ? "-" : MoBiPa.ToString(Global.FormatoUnidades));
                    Global.P_MoBiRi.Set(MoBiRi == 0 ? "-" : MoBiRi.ToString(Global.FormatoUnidades));

                    Global.P_VarMCA1.Set(Var1 == 0 ? "-" : Var1.ToString(Global.FormatoUnidades));
                    Global.P_VarMCA2.Set(Var2 == 0 ? "-" : Var2.ToString(Global.FormatoUnidades));
                    Global.P_VarMCA3.Set(Var3 == 0 ? "-" : Var3.ToString(Global.FormatoUnidades));

                    t.Commit();
                }
                catch (Exception err)
                {
                    ProcessarHid("Atenção: SetParameter " + err.Message);
                    t.RollBack();
                }
            }
            #endregion
            ProcessarHid("Cálculo realizado ;)");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TB_End.Text = "xxx";
            TB_Ocu.Text = "xxx";
            TB_Ris.Text = "Baixo";
            TB_RespUso.Text = "xxx";
            TB_RespTec.Text = "xxx";
            TB_CREA.Text = "xxx";
            TB_SisTipo.Text = "na mangueira e no esguicho";
            TB_Norma.Text = "xxx";

            TB_D1Hid.Text = "63";
            TB_D2Hid.Text = "63";
            TB_D3Hid.Text = "63";
            TB_D4Hid.Text = "63";
            TB_DBiPa.Text = "63";
            TB_DBiRi.Text = "63";
            TB_DDT.Text = "63";

            TB_MatTubo.Text = "Aço galvanizado";
            TB_CTubo.Text = "120";

            TB_DMang.Text = "40";
            TB_CMang.Text = "140";
            TB_LMang.Text = "30";

            TB_DEsg.Text = "13";
            TB_TipoEsg.Text = "Agulheta 13mm";
            TB_P1Hid.Text = "6";

            TB_RiVol.Text = "1";
            TB_RiPos.Text = "Elevado";

            TB_QtdHid.Text = "4";
            TB_Tag.Text = "HP";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Global.Form_End = PS_End;
            Global.Form_Ocu = PS_Ocu;
            Global.Form_RespUso = PS_RespUso;
            Global.Form_RespTec = PS_RespTec;
            Global.Form_CREA = PS_CREA;
            Global.Form_SisTipo = PS_SisTipo;
            Global.Form_Norma = PS_Norma;
            Global.Form_Ris = PS_Ris;
            Global.Form_D1Hid = PS_D1Hid;
            Global.Form_D2Hid = PS_D2Hid;
            Global.Form_D3Hid = PS_D3Hid;
            Global.Form_D4Hid = PS_D4Hid;
            Global.Form_DBiPa = PS_DBiPa;
            Global.Form_DBiRi = PS_DBiRi;
            Global.Form_DDT = PS_DDT;
            Global.Form_MatTubo = PS_MatTubo;
            Global.Form_CTubo = PS_CTubo;
            Global.Form_DMang = PS_DMang;
            Global.Form_CMang = PS_CMang;
            Global.Form_LMang = PS_LMang;
            Global.Form_DEsg = PS_DEsg;
            Global.Form_TipoEsg = PS_TipoEsg;
            Global.Form_P1Hid = PS_P1Hid;
            Global.Form_Tag = PS_Tag;
            Global.Form_RiVol = PS_RiVol;
            Global.Form_RiPos = PS_RiPos;
            Global.Form_QtdHid = PS_QtdHid;
            //DialogResult = DialogResult.Cancel;
            //Close();
            DialogResult = DialogResult.OK;
            Close();

        }

        private void Recuperar_Click(object sender, EventArgs e)
        {

        }
    }
}
