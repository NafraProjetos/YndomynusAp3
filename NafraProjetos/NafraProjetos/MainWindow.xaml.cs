
using System.Data;
using System.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Globalization;
using Autodesk.Revit.DB;
using System.Windows.Controls;

namespace NafraProjetos
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        //private static void CreateCommand(string queryString, string connectionString)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(connectionString))
        //    {
        //        MySqlCommand command = new MySqlCommand(queryString, connection);
        //        command.Connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //}

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddTransient<MyMySqlConnection>(_ => new MyMySqlConnection(Configuration["ConnectionStrings:Default"]));
        //}



        #region Global        
        public static class Global
        {
            //public static List<string> ListaNotasGerais = new List<string>();
            public static string
                Lista1, Lista2, Lista3, Lista4, ListaNotasGerais, ListaMedidas, ListaClassificacao, ListaAltura = string.Empty,
                Path = @"C:\Users\Public\AuraPrevSheets.json",
                Path2 = @"C:\Users\Public\Relatorio.txt",
                ApplicationName = "AuraPrevSheets",
                SpreadsheetId = "1Vlcp1hQoquV1cbxT4vLrWuGN18tsX1muaWWwhl0axlA",
                CadeiaConexao = @"Server=aws-sa-east-1.connect.psdb.cloud;Database=nf_db;user=cbwquc7xlimsv4j45ko1;password=pscale_pw_mHammStwymBFVgcGYZm9hAWGUQIuC7MHQat8qPH8k42;SslMode=VerifyFull;";
            //CadeiaConexao = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BD_NafraProjetos;Integrated Security=True";

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
                PHid = "T1", SHid = "T2", THid = "T3", QHid = "T4", BiPa = "BI-PA", BiRi = "BI-RI", TrechoDT = "DT", RI = "RI", BI = "BI", PA = "PA",
                Fonte, Crud;

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

            public static int QtdHid, Protecao_Id;

            public static double
                SumElevacao_1Hid, SumElevacao_2Hid, SumElevacao_3Hid, SumElevacao_4Hid, SumElevacao_PA, SumElevacao_BI, SumElevacao_RI,
                SPC_1Hid, SPC_2Hid, SPC_3Hid, SPC_4Hid, SPC_BiPa, SPC_BiRi,
                PdC_1Hid_OPA, PdC_2Hid_OPA, PdC_3Hid_OPA, PdC_4Hid_OPA, PdC_BiPa_OPA, PdC_BiRi_OPA,
                PdC_1Hid_OPF, PdC_2Hid_OPF, PdC_3Hid_OPF, PdC_4Hid_OPF, PdC_BiPa_OPF, PdC_BiRi_OPF,
                CTIU, CTIU_1Hid, CTIU_2Hid, CTIU_3Hid, CTIU_4Hid, CTIU_BiPa, CTIU_BiRi,
                D1Hid, D2Hid, D3Hid, D4Hid, DBiPa, DBiRi, DDT, VarMaxMo;

        }
        #endregion
        private DragAndDrop dragAndDropWindow;
        Document Doc;
        public MainWindow(Document doc)
        {
            InitializeComponent();
            Doc = doc;
            dragAndDropWindow = new DragAndDrop(this);


        }
        private new void PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Trace.WriteLine("Main Window: PreviewMouseLeftButtonDown");
            this.OnMouseLeftButtonDown(sender, e);
        }
        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Trace.WriteLine("Main Window: OnMouseLeftButtonDown");
            dragAndDropWindow.OnMouseLeftButtonDown(sender, e);
        }

        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Trace.WriteLine("Main Window: OnMouseLeftButtonUp");
            dragAndDropWindow.OnMouseLeftButtonUp(sender, e);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Trace.WriteLine("Main Window: OnMouseMove");
            dragAndDropWindow.OnMouseMove(sender, e);
        }




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this.ClientSize = new Size(400, 400);
            //this.groupBox1.Location = new System.Drawing.Point(8, 5);

            TabControl1.Items.Clear();
            TabControl1.Items.Add(TP_Login);
            TP_Login.IsSelected = true;
            //TabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void Fechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Processar(string msg)
        {
            string query2 =
                "SELECT Id AS '#', NomeJob AS 'Nome do JOB', DataInicio AS 'Data Início', DataEdificacao AS 'Data de construção', " +
                "Area AS 'Área (m³)', Altura AS 'Altura (m)', Estado_Id AS 'Estado', ObjetivoJob_Id AS 'Objetivo', IT14_Id AS 'IT' " +
                " FROM Job WHERE Usuario_Id = " + Global.Usuario_Id.ToString();
            using (MySqlConnection con2 = new MySqlConnection(Global.CadeiaConexao))
            using (MySqlCommand cmd2 = new MySqlCommand(query2, con2))
            {
                try
                {
                    con2.Open();
                    DataTable dt = new DataTable();
                    MySqlDataReader sdr = cmd2.ExecuteReader();
                    dt.Load(sdr);
                    DG_Jobs.ItemsSource = dt.DefaultView;
                }
                catch (MySqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
            DG_Ocupacao.IsEnabled = false;

            //toolStripStatusLabel1.Text = msg;
            //statusStrip1.Refresh();
            //for (int i = 0; i < 101; i++)
            //{
            //    toolStripProgressBar1.Value = i;
            //}
        }

        private void B_LoginLogar_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT Id FROM Usuario WHERE Email = @Email AND Senha = @Senha AND Ativo = 1";
            using (MySqlConnection con = new MySqlConnection(Global.CadeiaConexao))
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.VarChar)).Value = TB_LoginEmail.Text;
                cmd.Parameters.Add(new MySqlParameter("@Senha", MySqlDbType.VarChar)).Value = TB_LoginSenha.Password.ToString();
                try
                {
                    con.Open();
                    try
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        Global.Usuario_Id = reader.GetInt32(0);
                        TabControl1.Items.Remove(TP_Login);
                        TabControl1.Items.Add(TP_Jobs);
                        TP_Jobs.IsSelected = true;
                        reader.Close();
                        Processar("Atualizado!");
                    }
                    catch
                    {
                        MessageBox.Show("E-mail ou Senha não cadastrados!");
                        //MessageBoxResult result = MessageBox.Show("Quer?", "sério", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        //if (result == MessageBoxResult.Yes)
                        //{
                        //    TB_LoginEmail.Text = "if";
                        //}
                        //else
                        //{
                        //    TB_LoginEmail.Text = "else";
                        //}
                    }
                }
                catch (MySqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
        }

        private void B_Recuperar_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT Senha FROM Usuario WHERE Email = @Email";
            using (MySqlConnection con = new MySqlConnection(Global.CadeiaConexao))
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.VarChar)).Value = TB_RecuperarEmail.Text;
                try
                {
                    con.Open();
                    try
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        Email outlook = new Email("smtp.gmail.com", "nafraprojetos@gmail.com", "aiswsyqsdtdnxfeq");
                        outlook.SendEmail(emailsTo: new List<string> { TB_RecuperarEmail.Text },
                        subject: "Recuperação de senha",
                        body: "Segue a senha solicitada: " + reader.GetString(0).ToString(),
                        attachments: new List<string> { @"C:\temp\Assinatura Email.png" });
                        MessageBox.Show("Senha enviada para o e-mail informado!");
                        reader.Close();
                        RemoverPagina();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString(), "E-mail não encontrado!");
                    }
                }
                catch (MySqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
        }

        private void Cadastro_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TabControl1.Items.Remove(TP_Login);
            TabControl1.Items.Add(TP_Recuperar);
            TP_Recuperar.IsSelected = true;
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            //this.ClientSize = new Size(400, 400);
            //this.groupBox1.Location = new System.Drawing.Point(8, 5);
            RemoverPagina();

        }

        void RemoverPagina()
        {
            TabControl1.Items.Clear();
            TabControl1.Items.Add(TP_Login);
            TP_Login.IsSelected = true;
        }

        void Carregar()
        {
            DG_Ocupacao.ItemsSource = null;
            dataGridView4.ItemsSource = null;
            dataGridView5.ItemsSource = null;
            dataGridView6.ItemsSource = null;

            string query = "SELECT * FROM Estado WHERE Ativo = 1 ";
            using (MySqlConnection con = new MySqlConnection(Global.CadeiaConexao))
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                try
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    CB_Estado.ItemsSource = dt.DefaultView;
                    CB_Estado.DisplayMemberPath = "NomeEstado";
                    CB_Estado.SelectedValuePath = "Id";
                }
                catch (MySqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
            string query2 = "SELECT * FROM ObjetivoJob WHERE Ativo = 1 ";
            using (MySqlConnection con2 = new MySqlConnection(Global.CadeiaConexao))
            using (MySqlCommand cmd2 = new MySqlCommand(query2, con2))
            {
                try
                {
                    con2.Open();
                    MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    CB_Objetivo.ItemsSource = dt2.DefaultView;
                    CB_Objetivo.DisplayMemberPath = "Objetivo";
                    CB_Objetivo.SelectedValuePath = "Id";
                }
                catch (MySqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
            string query3 = "SELECT * FROM IT14";
            using (MySqlConnection con3 = new MySqlConnection(Global.CadeiaConexao))
            using (MySqlCommand cmd3 = new MySqlCommand(query3, con3))
            {
                try
                {
                    con3.Open();
                    MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    CB_classificacao.ItemsSource = dt3.DefaultView;
                    CB_classificacao.DisplayMemberPath = "Compilado";
                    CB_classificacao.SelectedValuePath = "Id";

                    List<string> listsss = new List<string>();
                    foreach (DataRow row in dt3.Rows)
                    {
                        listsss.Add(row["Compilado"].ToString());
                    }
                    tb.FilterMode = AutoCompleteFilterMode.Contains;
                    tb.ItemsSource = listsss;
                }
                catch (MySqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
        }

        private void B_CadastroCadastrar_Click(object sender, RoutedEventArgs e)
        {

            DateTime DateTimeNow = DateTime.Now;
            var DataInicio = DateTimeNow.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
            var DataSoma = DateTimeNow.AddMonths(12);
            var DataFim = DataSoma.ToString("yyyy-MM-dd", new CultureInfo("en-US"));

            string query = "INSERT INTO Usuario (Nome, Sobrenome, Telefone, Email, Senha, DataInicio, DataFim, Ativo, Logado, QtdAcesso, Msg)" +
                " VALUES (@Nome, @Sobrenome, @Telefone, @Email, @Senha, '" + DataInicio + "', '" + DataFim + "', 1, 0, 0, 'teste')";
            using (MySqlConnection con = new MySqlConnection(Global.CadeiaConexao))
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.Add(new MySqlParameter("@Nome", MySqlDbType.VarChar)).Value = TB_CadastroNome.Text;
                cmd.Parameters.Add(new MySqlParameter("@Sobrenome", MySqlDbType.VarChar)).Value = TB_CadastroSobrenome.Text;
                cmd.Parameters.Add(new MySqlParameter("@Telefone", MySqlDbType.VarChar)).Value = TB_CadastroTelefone.Text;
                cmd.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.VarChar)).Value = TB_CadastroEmail.Text;
                cmd.Parameters.Add(new MySqlParameter("@Senha", MySqlDbType.VarChar)).Value = TB_CadastroSenha.Password.ToString();
                try
                {
                    MySqlDataReader MyReader2;
                    con.Open();
                    MyReader2 = cmd.ExecuteReader();
                    MessageBox.Show("Usuário cadastrado!");
                }
                catch (MySqlException err)
                {
                    MessageBox.Show(err.ToString(), "Erro");
                }
            }
            RemoverPagina();
        }

        private void B_Adicionar_Click(object sender, RoutedEventArgs e)
        {
            Carregar();
            TabControl1.Items.Remove(TP_Jobs);
            TabControl1.Items.Add(TP_Adicionar);
            TP_Adicionar.IsSelected = true;
            Global.Crud = "Adicionar";
        }

        private void B_Classficacao_Click(object sender, RoutedEventArgs e)
        {
            DG_Ocupacao.IsEnabled = true;
            CB_classificacao.Text = tb.Text;
            if (tb.Text.Length > 0)
            {
                string query =
                    "SELECT O.Grupo, O.OcupacaoUso AS 'Ocupação', DO.Divisao AS 'Divisão', DO.Descricao AS 'Descrição', IT.QtdCargaIncendio AS 'Carga de Incêndio', " +
                    "CI.DescricaoLimite AS 'Limite', CI.Risco " +
                    "FROM IT14 AS IT, DivisaoOcupacao AS DO, Ocupacao AS O, CargaIncendio AS CI " +
                    "WHERE O.Id = DO.Ocupacao_Id AND DO.Id = IT.DivisaoOcupacao_Id AND IT.Id = " + CB_classificacao.SelectedValue + " AND CI.Id = IT.CargaIncendio_Id";
                using (MySqlConnection con = new MySqlConnection(Global.CadeiaConexao))
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        DataTable dt = new DataTable();
                        MySqlDataReader sdr = cmd.ExecuteReader();
                        dt.Load(sdr);
                        DG_Ocupacao.ItemsSource = dt.DefaultView;

                        foreach (DataRow row in dt.Rows)
                        {
                            Global.Fonte = row["Divisão"].ToString();
                            Global.ListaClassificacao =
                                "\r\nGrupo: " + row["Grupo"].ToString() +
                                "\r\nOcupação: " + row["Ocupação"].ToString() +
                                "\r\nDivisão: " + row["Divisão"].ToString() +
                                "\r\nDescrição: " + row["Descrição"].ToString() +
                                "\r\nCarga de Incêndio: " + row["Carga de Incêndio"].ToString() + " MJ/m²" +
                                "\r\nLimite: " + row["Limite"].ToString() +
                                "\r\nRisco: " + row["Risco"].ToString();
                        }
                    }
                    catch (MySqlException err)
                    {
                        MessageBox.Show(err.ToString(), "Erro");
                    }
                }
            }
            else
            {
                MessageBox.Show("Campo ocupação vazio!");
            }
        }

        private void Somar(object sender, System.Windows.Input.KeyEventArgs e)
        {
            double.TryParse(TB_AdicionarAreaExistente.Text, out double AreaExistente);
            double.TryParse(TB_AdicionarAreaNova.Text, out double AreaNova);
            TB_AdicionarAreaTotal.Text = (AreaExistente + AreaNova).ToString();
        }

        private void B_AdicionarSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length > 0 && CB_Estado.Text.Length > 0 && CB_Objetivo.Text.Length > 0 && dateTimePicker1.Text.Length > 0)
            {
                if (Global.Crud == "Adicionar")
                {
                    DateTime DateTimeNow = DateTime.Now;
                    var DataInicio = DateTimeNow.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
                    var Datayyy = dateTimePicker1;
                    //var DataFim = Datayyy("yyyy-MM-dd", new CultureInfo("en-US"));
                    //arrumar a 'DataEdificacao aqui
                    string query = "INSERT INTO Job (Usuario_Id, Estado_Id, ObjetivoJob_Id, IT14_Id, NomeJob, DataInicio, DataEdificacao, Area, Altura)" +
                        " VALUES (" + Global.Usuario_Id + ", @Estado_Id, @ObjetivoJob_Id, " + CB_classificacao.SelectedValue + ", @NomeJob, '" + DataInicio + "', '2023-01-01', @Area, @Altura)";
                    using (MySqlConnection con = new MySqlConnection(Global.CadeiaConexao))
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        //MessageBox.Show(query.ToString());
                        cmd.Parameters.Add(new MySqlParameter("@Estado_Id", MySqlDbType.Int32)).Value = int.Parse(CB_Estado.SelectedValue.ToString());
                        cmd.Parameters.Add(new MySqlParameter("@ObjetivoJob_Id", MySqlDbType.Int32)).Value = int.Parse(CB_Objetivo.SelectedValue.ToString());
                        cmd.Parameters.Add(new MySqlParameter("@NomeJob", MySqlDbType.VarChar)).Value = textBox22.Text;
                        //cmd.Parameters.Add(new MySqlParameter("@DataEdificacao", MySqlDbType.DateTime)).Value = dateTimePicker1.Text;
                        cmd.Parameters.Add(new MySqlParameter("@Area", MySqlDbType.Decimal)).Value = double.Parse(TB_AdicionarAreaTotal.Text);
                        cmd.Parameters.Add(new MySqlParameter("@Altura", MySqlDbType.Decimal)).Value = double.Parse(TB_AdicionarAtura.Text);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Job criado com sucesso!");
                        }
                        catch (MySqlException err)
                        {
                            MessageBox.Show(err.ToString(), "Erro");
                        }
                    }
                    TabControl1.Items.Remove(TP_Adicionar);
                    TabControl1.Items.Add(TP_Jobs);
                    TP_Jobs.IsSelected = true;
                }
                if (Global.Crud == "Editar")
                {
                    //arrumar a 'DataEdificacao aqui
                    string query = "UPDATE Job SET Usuario_Id=" + Global.Usuario_Id + ", Estado_Id= @Estado_Id, ObjetivoJob_Id=@ObjetivoJob_Id, IT14_Id=" + CB_classificacao.SelectedValue + ", " +
                        "NomeJob=@NomeJob, DataEdificacao='2023-01-01', Area=@Area, Altura=@Altura WHERE Id = " + Global.Job_Id;
                    using (MySqlConnection con = new MySqlConnection(Global.CadeiaConexao))
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        //MessageBox.Show(query.ToString());
                        cmd.Parameters.Add(new MySqlParameter("@Estado_Id", MySqlDbType.Int32)).Value = int.Parse(CB_Estado.SelectedValue.ToString());
                        cmd.Parameters.Add(new MySqlParameter("@ObjetivoJob_Id", MySqlDbType.Int32)).Value = int.Parse(CB_Objetivo.SelectedValue.ToString());
                        cmd.Parameters.Add(new MySqlParameter("@NomeJob", MySqlDbType.VarChar)).Value = textBox22.Text;
                        //cmd.Parameters.Add(new MySqlParameter("@DataEdificacao", MySqlDbType.Date)).Value = dateTimePicker1.Text;
                        cmd.Parameters.Add(new MySqlParameter("@Area", MySqlDbType.Decimal)).Value = double.Parse(TB_AdicionarAreaTotal.Text);
                        cmd.Parameters.Add(new MySqlParameter("@Altura", MySqlDbType.Decimal)).Value = double.Parse(TB_AdicionarAtura.Text);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Job atualizado com sucesso!");
                        }
                        catch (MySqlException err)
                        {
                            MessageBox.Show(err.ToString(), "Erro");
                        }
                    }
                    TabControl1.Items.Remove(TP_Adicionar);
                    TabControl1.Items.Add(TP_Jobs);
                    TP_Jobs.IsSelected = true;
                }

                Processar("Atualizado!");
            }
            else
            {
                MessageBox.Show("Campo vazio!");
            }
        }
        private void B_VoltarJob_Click(object sender, RoutedEventArgs e)
        {
            TabControl1.Items.Remove(TP_Adicionar);
            TabControl1.Items.Add(TP_Jobs);
            TP_Jobs.IsSelected = true;
            Processar("Atualizado!");
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        private void B_ClassficacaoImprimir_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length > 0 && CB_Estado.Text.Length > 0 && CB_Objetivo.Text.Length > 0 && dateTimePicker1.Text.Length > 0)
            {
                if (File.Exists(Global.Path2))
                {
                    File.Delete(Global.Path2);
                }
                using (FileStream fs = File.Create(Global.Path2))
                {
                    AddText(fs,
                        "Job: " + textBox22.Text
                        + "\r\nData de construção: " + dateTimePicker1.Text
                        + "\r\nEstado: " + CB_Estado.Text
                        + "\r\n\r\nClassificação: " + CB_classificacao.Text
                        + Global.ListaClassificacao
                        + "\r\n\r\nAltura: " + TB_AdicionarAtura.Text + " m"
                        + Global.ListaAltura
                        + "\r\nÁrea: " + TB_AdicionarAreaTotal.Text + " m²"
                        + "\r\n\r\nMedidas" + Global.ListaMedidas
                        + "\r\n\r\nNotas Gerais" + Global.ListaNotasGerais
                        );
                }
                //Process.Start(Global.Path2);
                //Process.Start(new ProcessStartInfo { FileName = @"http://. . . .", UseShellExecute = true });
                Process.Start(new ProcessStartInfo { FileName = Global.Path2, UseShellExecute = true });

                //PrintDialog printDialog = new PrintDialog();
                //if(printDialog.ShowDialog() == true)
                //{
                //    printDialog.PrintVisual(print, "invoice");
                //}
            }
            else
            {
                MessageBox.Show("Campo vazio!");
            }
        }

        private void B_Excluir_Click(object sender, RoutedEventArgs e)
        {
            if (DG_Jobs != null && DG_Jobs.SelectedItems != null && DG_Jobs.SelectedItems.Count == 1)
            {
                DataRowView drv = (DataRowView)DG_Jobs.SelectedItem;
                string query = "DELETE FROM Job WHERE Id = " + drv[0].ToString();
                using (MySqlConnection con = new MySqlConnection(Global.CadeiaConexao))
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    try
                    {
                        //MessageBox.Show(drv[0].ToString());
                        //MessageBox.Show(query.ToString());
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("JOB excluido com sucesso!");
                    }
                    catch (MySqlException err)
                    {
                        MessageBox.Show(err.ToString(), "Erro");
                    }
                }
                Processar("Atualizado!");
            }
            else
            {
                MessageBox.Show("Selecione uma linha!");
            }
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            Carregar();
            if (DG_Jobs != null && DG_Jobs.SelectedItems != null && DG_Jobs.SelectedItems.Count == 1)
            {
                TabControl1.Items.Remove(TP_Jobs);
                TabControl1.Items.Add(TP_Adicionar);
                TP_Adicionar.IsSelected = true;

                Global.Crud = "Editar";
                DataRowView drv = (DataRowView)DG_Jobs.SelectedItem;
                Global.Job_Id = int.Parse(drv[0].ToString());
                textBox22.Text = drv[1].ToString();
                dateTimePicker1.Text = drv[3].ToString();
                TB_AdicionarAreaExistente.Text = drv[4].ToString();
                TB_AdicionarAtura.Text = drv[5].ToString();

                string query = "SELECT Compilado FROM IT14 WHERE Id = " + drv[8].ToString();
                using (MySqlConnection con = new MySqlConnection(Global.CadeiaConexao))
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        MySqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        tb.Text = reader.GetString(0).ToString();
                        reader.Close();
                    }
                    catch (MySqlException err)
                    {
                        MessageBox.Show(err.ToString(), "Erro");
                    }
                }

                string query2 = "SELECT NomeEstado FROM Estado WHERE Id = " + drv[6].ToString();
                using (MySqlConnection con2 = new MySqlConnection(Global.CadeiaConexao))
                using (MySqlCommand cmd2 = new MySqlCommand(query2, con2))
                {
                    try
                    {
                        con2.Open();
                        MySqlDataReader reader2 = cmd2.ExecuteReader();
                        reader2.Read();
                        CB_Estado.Text = reader2.GetString(0).ToString();
                        reader2.Close();
                    }
                    catch (MySqlException err)
                    {
                        MessageBox.Show(err.ToString(), "Erro");
                    }
                }

                string query3 = "SELECT Objetivo FROM ObjetivoJob WHERE Id = " + drv[7].ToString();
                using (MySqlConnection con3 = new MySqlConnection(Global.CadeiaConexao))
                using (MySqlCommand cmd3 = new MySqlCommand(query3, con3))
                {
                    try
                    {
                        con3.Open();
                        MySqlDataReader reader3 = cmd3.ExecuteReader();
                        reader3.Read();
                        CB_Objetivo.Text = reader3.GetString(0).ToString();
                        reader3.Close();
                    }
                    catch (MySqlException err)
                    {
                        MessageBox.Show(err.ToString(), "Erro");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma linha!");
            }
        }

        private void Recuperar_Click(object sender, RoutedEventArgs e)
        {
            TabControl1.Items.Remove(TP_Login);
            TabControl1.Items.Add(TP_Recuperar);
            TP_Recuperar.IsSelected = true;
        }

        private void CadastroCadastrar_Click(object sender, RoutedEventArgs e)
        {
            TabControl1.Items.Remove(TP_Login);
            TabControl1.Items.Add(TP_Cadastro);
            TP_Cadastro.IsSelected = true;
        }

        private void B_Hidrante_Click(object sender, RoutedEventArgs e)
        {
            TabControl1.Items.Remove(TP_Jobs);
            TabControl1.Items.Add(TP_Hidrante);
            TP_Hidrante.IsSelected = true;
        }

        private void B_Procurar_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length > 0 && DG_Ocupacao.IsEnabled == true)
            {
                string query1 =
               "SELECT PO.Tipo, PO.Denominacao AS 'Denominação', PO.Obs " +
               "FROM ParametroOcupacao AS PO, Capacidade AS C, Unidade AS U " +
               "WHERE C.Id = PO.Capacidade_Id AND U.Id = C.Unidade_Id AND C.Minimo <= @Altura AND C.Maximo >= @Altura AND U.Parametro = 'Altura' ";
                using (MySqlConnection con1 = new MySqlConnection(Global.CadeiaConexao))
                using (MySqlCommand cmd1 = new MySqlCommand(query1, con1))
                {
                    cmd1.Parameters.Add(new MySqlParameter("@Altura", MySqlDbType.Decimal)).Value = double.Parse(TB_AdicionarAtura.Text);
                    try
                    {
                        con1.Open();
                        DataTable dt1 = new DataTable();
                        MySqlDataReader sdr1 = cmd1.ExecuteReader();
                        dt1.Load(sdr1);
                        dataGridView4.ItemsSource = dt1.DefaultView;
                        foreach (DataRow row in dt1.Rows)
                        {
                            Global.ListaAltura =
                                "\r\nTipo: " + row["Tipo"].ToString() +
                                "\r\nDenominação: " + row["Denominação"].ToString() +
                                "\r\nObs: " + row["Obs"].ToString();
                        }
                    }
                    catch (MySqlException err)
                    {
                        MessageBox.Show(err.ToString(), "Erro");
                    }
                }

                double.TryParse(TB_AdicionarAtura.Text, out double AlturaTotal);
                double.TryParse(TB_AdicionarAreaTotal.Text, out double AreaTotal);
                string TabelaNormaSql = string.Empty;


                string TabelaNorma;
                if (AreaTotal <= 750 && AlturaTotal <= 12 && Global.Fonte != "K-1" && Global.Fonte != "M-1" && Global.Fonte != "M-2"
                    && Global.Fonte != "M-4" && Global.Fonte != "M-5" && Global.Fonte != "M-6" && Global.Fonte != "M-7")
                {
                    TabelaNorma = "TABELA 5";
                }
                else if (AreaTotal > 750 || AlturaTotal > 12)
                //|| Global.Fonte = "K-1" || Global.Fonte = "M-1" || Global.Fonte = "M-2" || Global.Fonte = "M-4" || Global.Fonte = "M-5" || Global.Fonte = "M-6" || Global.Fonte = "M-7")
                {
                    TabelaNorma = "TABELA 6%";
                }
                else
                {
                    TabelaNorma = "ERRO";
                }


                string query2 =
                    "SELECT N.NumeroNorma AS 'Legislação', M.TipoMedida AS 'Medida', DN.Descricao AS 'Nota Específica', ItNo.Item " +
                    "FROM Protecao AS P, ItemNorma AS ItNo, Medida AS M, ParametroOcupacao AS PO, Capacidade AS C, Unidade AS U, " +
                    "DescricaoNota AS DN, DivisaoOcupacao AS DO, IT14 AS IT, Norma AS N " +
                    "WHERE ItNo.Id = P.ItemNorma_Id AND M.Id = P.Medida_Id AND N.Id = M.Norma_Id AND DN.Id = P.DescricaoNota_Id AND DO.Id = P.DivisaoOcupacao_Id " +
                    "AND DO.Id = IT.DivisaoOcupacao_Id AND IT.ID = @IT14 AND PO.Id = P.ParametroOcupacao_Id AND C.Id = PO.Capacidade_Id " +
                    "AND U.Id = C.Unidade_Id AND ItNo.Item LIKE '" + TabelaNorma + "' AND C.Minimo <= @Altura AND C.Maximo >= @Altura";
                using (MySqlConnection con2 = new MySqlConnection(Global.CadeiaConexao))
                using (MySqlCommand cmd2 = new MySqlCommand(query2, con2))
                {
                    cmd2.Parameters.Add(new MySqlParameter("@IT14", MySqlDbType.Int32)).Value = int.Parse(CB_classificacao.SelectedValue.ToString());
                    cmd2.Parameters.Add(new MySqlParameter("@Altura", MySqlDbType.Decimal)).Value = double.Parse(TB_AdicionarAtura.Text);
                    try
                    {
                        con2.Open();
                        DataTable dt2 = new DataTable();
                        MySqlDataReader sdr2 = cmd2.ExecuteReader();
                        dt2.Load(sdr2);
                        dataGridView5.ItemsSource = dt2.DefaultView;
                        Global.ListaMedidas = "";
                        foreach (DataRow row in dt2.Rows)
                        {
                            TabelaNormaSql = row["Item"].ToString();
                            string NotaEsp = string.Empty;
                            if (row["Nota Específica"].ToString() != "NA")
                            {
                                NotaEsp = " NE[" + row["Nota Específica"].ToString() + "]";
                            }
                            Global.ListaMedidas += "\r\n" + row["Medida"].ToString() + NotaEsp;
                            //Global.Protecao_Id = int.Parse(row["Protecao_id"].ToString());
                            //MessageBox.Show(row["#"].ToString());
                            //MessageBox.Show(row["Protecao_Id"].ToString());
                        }
                    }
                    catch (MySqlException err)
                    {
                        MessageBox.Show(err.ToString(), "Erro");
                    }
                }

                string query3 =
                    "SELECT DN.Descricao AS 'Notas Gerais' " +
                    "FROM NotaGeral NG, ItemNorma ItNo, DescricaoNota DN, Nota N " +
                    "WHERE DN.Id = NG.DescricaoNota_Id AND ItNo.Id = NG.ItemNorma_Id AND N.Id = DN.Nota_Id AND N.TipoNota = 'Notas gerais' AND ItNo.Item = '" + TabelaNormaSql + "'";
                using (MySqlConnection con3 = new MySqlConnection(Global.CadeiaConexao))
                using (MySqlCommand cmd3 = new MySqlCommand(query3, con3))
                {
                    try
                    {
                        con3.Open();
                        DataTable dt3 = new DataTable();
                        MySqlDataReader sdr3 = cmd3.ExecuteReader();
                        dt3.Load(sdr3);
                        dataGridView6.ItemsSource = dt3.DefaultView;

                        Global.ListaNotasGerais = "";
                        foreach (DataRow row in dt3.Rows)
                        {
                            Global.ListaNotasGerais += "\r\n" + row["Notas Gerais"].ToString();
                        }
                    }
                    catch (MySqlException err)
                    {
                        MessageBox.Show(err.ToString(), "Erro");
                    }
                }
            }
            else
            {
                MessageBox.Show("Defina a ocupação!");
            }
        }
    }
}
