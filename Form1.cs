
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImssAnalysis.Model;
using ChoETL;

namespace ImssAnalysis
{
    
    public partial class Form1 : Form
    {
        private static string csvFile = "";
        private static string nombreAsgurado = "";
        private static string lugarNacimiento = "";
        private static string segSocial = "";
        ESEEntities db = new ESEEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            Application.DoEvents();
            int IdSolicitud = int.Parse(System.Configuration.ConfigurationManager.AppSettings["IdSolicitud"]);
            db.pEliminaRegistrosPatronales(IdSolicitud);
            grabaInfoPatronal(IdSolicitud, filePath.Text);
            grabaCuentaIndividual(IdSolicitud, filePath.Text);
            vCartaIndividual iRegistrosPatronales = new vCartaIndividual();
            List<vCartaIndividual> iListRegistrosPatronales1 = new List<vCartaIndividual>();
            if (rbSinOrdenamineto.Checked)
                iListRegistrosPatronales1 = db.vCartaIndividual.Where(x => x.IdSolicitud == IdSolicitud).ToList();
            if (rbEmpresaFecha.Checked)
                iListRegistrosPatronales1 = db.vCartaIndividual.Where(x => x.IdSolicitud == IdSolicitud).OrderBy(y => y.NombreCompania).ThenByDescending(z => z.DFechaIngreso).ToList();
            if (rbFechaIngreso.Checked)
                iListRegistrosPatronales1 = db.vCartaIndividual.Where(x => x.IdSolicitud == IdSolicitud).OrderByDescending(z => z.DFechaIngreso).ToList();
            DataTable table = ConvertListToDataTable(iListRegistrosPatronales1.ToList());
            dataGridView1.DataSource = table;
            using (var w = new ChoCSVWriter<vCartaIndividual>(Console.Out).WithFirstLineHeader())
            {
                w.Write(iListRegistrosPatronales1);
            }
	    Log.write(ex.message);
            MessageBox.Show("Ha concluido la carga del archivo.");


        }
        static DataTable ConvertListToDataTable(List<vCartaIndividual> list)
        {
            List<CsvFD> iCsvFD = new List<CsvFD>();
            DataTable dt = new DataTable();
            dt.Columns.Add("IdSolicitud");
            dt.Columns.Add("RegistroPatronal");
            dt.Columns.Add("NombreCompania");
            dt.Columns.Add("FechaIngreso");
            dt.Columns.Add("FechaEgreso");
            dynamic csvRow = new CsvFD();
            csvRow.IdSolicitud = 1;
            csvRow.RegistroPatronal = segSocial;
            csvRow.NombreCompania = nombreAsgurado;
            csvRow.FechaIngreso = lugarNacimiento;
            csvRow.FechaEgreso = "";
            iCsvFD.Add(csvRow);
            foreach (var oItem in list)
            {
                var fechaEgreso = oItem.FechaEgreso;
                if (oItem.FechaEgreso == "")
                {
                    fechaEgreso = "00/00/0000";
                }
                dt.Rows.Add(new object[] {
                    oItem.IdSolicitud
                    , oItem.RegistroPatronal
                    , oItem.NombreCompania
                    , oItem.FechaIngreso
                    , fechaEgreso
                });
                csvRow = new CsvFD();
                csvRow.IdSolicitud = oItem.IdSolicitud;
                csvRow.RegistroPatronal = oItem.RegistroPatronal;
                csvRow.NombreCompania = oItem.NombreCompania;
                csvRow.FechaIngreso = oItem.FechaIngreso;
                csvRow.FechaEgreso = fechaEgreso;
                iCsvFD.Add(csvRow);
            }
            using (var parser = new ChoCSVWriter(csvFile))
            {
                parser.Write(iCsvFD);
            }
            return dt;

        }
        public void grabaInfoPatronal(int idSolicitud, string imssFile)
        {
            string text = System.IO.File.ReadAllText(imssFile);
            Regex expressionRP = new Regex(@"(REGISTRO PATRONAL)\s*\w+\s(-)\s\d");
            Regex expressionCompanias = new Regex(@"(NOMBRE)\r\n\s*.*");
            var registroPatronales = expressionRP.Matches(text);
            var nombresCompanias = expressionCompanias.Matches(text);

            for (int i = 0; i < registroPatronales.Count; i++)
            {
                string registroPatronal = registroPatronales[i].Value.Replace("REGISTRO PATRONAL", "").TrimStart();
                string nombrePatron = nombresCompanias[i].Value.Replace("NOMBRE", "").TrimStart();
                db.pInsertaRegistrosPatronales(idSolicitud, registroPatronal, nombrePatron);
            }
        }

        public void grabaCuentaIndividual(int idSolicitud, string imssFile)
        {
            string text = System.IO.File.ReadAllText(imssFile);
            List<string> fechaEntrada = new List<string>();
            List<string> fechaSalida = new List<string>();
            nombreAsgurado = ObtieneNombreAsegurado(text);
            lugarNacimiento = ObtieneLugarNacimiento(text);
            segSocial = ObtieneSegSocial(text);

            List<vRegistrosPatronales> iRegitroPatronales = db.vRegistrosPatronales.Where(x => x.IdSolicitud == idSolicitud).ToList();
            
            foreach (vRegistrosPatronales item in iRegitroPatronales)
            {

                //string registroP = item.RegistroPatronal.Replace(" - ", "").Trim();
                string registroP = item.RegistroPatronal.Substring(0, 10);
                Regex expressionFechaSalida = new Regex(@".*" + registroP + ".*( 2 )(([012]\\d)|3[01])/((0\\d)|(1[012]))/\\d{4}");
                Regex expressionFechaEntrada = new Regex(".*" + registroP + ".*( 8 )(([012]\\d)|3[01])/((0\\d)|(1[012]))/\\d{4}");
                Regex expressionFechaEntrada1 = new Regex(".*" + registroP + ".*( 1 )(([012]\\d)|3[01])/((0\\d)|(1[012]))/\\d{4}");
                var registroPatronales = expressionFechaSalida.Matches(text);
                fechaSalida = ObtieneFecha(registroPatronales);
                registroPatronales = expressionFechaEntrada.Matches(text);
                if (registroPatronales.Count == 0) registroPatronales = expressionFechaEntrada1.Matches(text);
                fechaEntrada = ObtieneFecha(registroPatronales);
                int registros = 0;
                if (fechaEntrada.Count >= fechaSalida.Count)
                    registros = fechaEntrada.Count;
                else
                    registros = fechaSalida.Count;

                for (int i = 0; i < registros; i++)
                {
                    try
                    {
                        var fecSal = "";
                        if (fechaSalida.Count == i)
                            fecSal = "01/01/0001";
                        else
                            fecSal = fechaSalida[i];

                        db.pInsertaCartaIndividual(item.IdRegistroPatronal, DateTime.Parse(fechaEntrada[i].Substring(6, 4) + "-" + fechaEntrada[i].Substring(3, 2) + "-" + fechaEntrada[i].Substring(0, 2)), DateTime.Parse(fecSal.Substring(6, 4) + "-" + fecSal.Substring(3, 2) + "-" + fecSal.Substring(0, 2)));
                    }
                    catch (Exception ex)
                    {
                        if (!ex.InnerException.Message.Contains("Cannot insert duplicate key row in object"))
                        {
                            throw;
                        }
                    }
                }
            }
        }

        private string ObtieneNombreAsegurado(string text)
        {
            Regex expressionNombreAsegurado = new Regex(@"(NOMBRE DEL ASEGURADO)\s*.*");
            var nombreAseguradoArray = expressionNombreAsegurado.Matches(text);
            string nombreAsegurado;
            try
            {
                nombreAsegurado = nombreAseguradoArray[0].ToString().Replace("NOMBRE DEL ASEGURADO     ", "NOMBRE DEL ASEGURADO,").Replace("\r", "");
            }
            catch (Exception)
            {
                nombreAsegurado = "NOMBRE DEL ASEGURADO,NO SE PUDO LEER DEL ARCHIVO";
            }
            return nombreAsegurado;
        }
        private string ObtieneLugarNacimiento(string text)
        {
            Regex expressionNombreAsegurado = new Regex(@"(LUGAR DE NACIMIENTO)\s*.*");
            var nombreAseguradoArray = expressionNombreAsegurado.Matches(text);
            string nombreAsegurado;
            try
            {
                nombreAsegurado = nombreAseguradoArray[0].ToString().Replace("LUGAR DE NACIMIENTO      ", "LUGAR DE NACIMIENTO,").Replace("\r", "");
            }
            catch (Exception)
            {
                nombreAsegurado = "LUGAR DE NACIMIENTO,NO SE PUDO LEER DEL ARCHIVO";
            }
            return nombreAsegurado;
        }

        private string ObtieneSegSocial(string text)
        {
            Regex expressionSegSocial = new Regex(@"(NUM. SEG. SOCIAL)\s*.*CURP");
            var nombreSegSocialArray = expressionSegSocial.Matches(text);
            string nombreSegSocial;
            try
            {
                nombreSegSocial = nombreSegSocialArray[0].ToString().Replace("NUM. SEG. SOCIAL         ", "NUM. SEG. SOCIAL,").Replace("\r", "").Replace("CURP","").TrimEnd();
            }
            catch (Exception)
            {
                nombreSegSocial = "NUM. SEG. SOCIAL,NO SE PUDO LEER DEL ARCHIVO";
            }
            return nombreSegSocial;
        }
        private static List<string> ObtieneFecha(MatchCollection registroPatronales)
        {
            string fecha = String.Empty;
            List<string> lstFechas = new List<string>();
            if (registroPatronales.Count == 0)
            {
                fecha = "01/01/0001";
                lstFechas.Add(fecha);
                return lstFechas;
            }

            for (int i = 0; i < registroPatronales.Count; i++)
            {
                string registroPatronal = registroPatronales[i].Value.TrimStart();
                fecha = registroPatronal.Substring(registroPatronal.Length - 10, 10);
                if (String.IsNullOrEmpty(fecha))
                {
                    fecha = "01/01/0001";
                }
                lstFechas.Add(fecha);
            }
            return lstFechas;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"c:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath.Text = openFileDialog1.FileName;
            }
            csvFile = filePath.Text.Replace(".txt", ".csv");
        }

        private void RbEmpresaFecha_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

}
