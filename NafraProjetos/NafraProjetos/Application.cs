using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NafraProjetos
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]

    #region Global
    public static class Global
    {
        public static string
                 PHid = "T1", SHid = "T2", THid = "T3", QHid = "T4", BiPa = "BI-PA", BiRi = "BI-RI", TrechoDT = "DT", RI = "RI", BI = "BI", PA = "PA";
    }
    #endregion

    public class Application : IExternalApplication
    {
        public UIDocument ActiveUIDocument { get; private set; }
        public static ImageSource GetResourceImage(Assembly assembly, string imageName)
        {
            try
            {
                Stream resource = assembly.GetManifestResourceStream(imageName);
                return BitmapFrame.Create(resource);
            }
            catch
            {
                return null;
            }
        }

        private static void AddRibbonPanel(UIControlledApplication application)
        {
            string End_CALCULAR = "NafraProjetos.CalculoHidrante";
            string End_LIMPAR = "NafraProjetos.LimparComentarios";
            string End_RI = "NafraProjetos.RI";
            string End_BI = "NafraProjetos.BI";
            string End_PA = "NafraProjetos.PA";
            string End_PHid = "NafraProjetos.PHid";
            string End_SHid = "NafraProjetos.SHid";
            string End_THid = "NafraProjetos.THid";
            string End_QHid = "NafraProjetos.QHid";
            string End_BiPa = "NafraProjetos.BiPa";
            string End_BiRi = "NafraProjetos.BiRi";
            //string End_xxx = "NafraProjetos.SPK";
            string End_xxx = "NafraProjetos.PainelControle";
            //string End_xxx = "NafraProjetos.End_xxx";            

            // Crie um botão simples com uma Ajuda F1 - Adiciona uma nova guia ao Revit
            application.CreateRibbonTab("NafraProjetos");

            // Adiciona uma faixa de opções associada à guia
            RibbonPanel ArchiPanel = application.CreateRibbonPanel("NafraProjetos", "Limpar");
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData PBD_LIMPAR = new PushButtonData("Sistema", "Sistema", thisAssemblyPath, End_LIMPAR);
            PushButton PB_LIMPAR = ArchiPanel.AddItem(PBD_LIMPAR) as PushButton; // Criamos o botão e o adicionamos à faixa de opções
            PB_LIMPAR.ToolTip = "Sistema!"; // Definimos o texto exibido ao passar o mouse            
            PB_LIMPAR.LargeImage = GetResourceImage(Assembly.GetExecutingAssembly(), "Resources.ICO.Sistema.ico");

            RibbonPanel ArchiPanel2 = application.CreateRibbonPanel("NafraProjetos", "Identificar");
            string thisAssemblyPath2 = Assembly.GetExecutingAssembly().Location;

            PushButtonData PBD_RI = new PushButtonData("RI", "RI", thisAssemblyPath2, End_RI);
            PushButton PB_RI = ArchiPanel2.AddItem(PBD_RI) as PushButton; // Criamos o botão e o adicionamos à faixa de opções
            PB_RI.ToolTip = "RI!"; // Definimos o texto exibido ao passar o mouse            
            PB_RI.LargeImage = GetResourceImage(Assembly.GetExecutingAssembly(), ".Resources.ICO.RI.ico");

            PushButtonData PBD_BI = new PushButtonData("BI", "BI", thisAssemblyPath2, End_BI);
            PushButton PB_BI = ArchiPanel2.AddItem(PBD_BI) as PushButton; // Criamos o botão e o adicionamos à faixa de opções
            PB_BI.ToolTip = "BI!"; // Definimos o texto exibido ao passar o mouse            
            PB_BI.LargeImage = GetResourceImage(Assembly.GetExecutingAssembly(), ".ICO.BI.ico");

            PushButtonData PBD_PA = new PushButtonData("PA", "PA", thisAssemblyPath2, End_PA);
            PushButton PB_PA = ArchiPanel2.AddItem(PBD_PA) as PushButton; // Criamos o botão e o adicionamos à faixa de opções
            PB_PA.ToolTip = "PA!"; // Definimos o texto exibido ao passar o mouse            
            PB_PA.LargeImage = GetResourceImage(Assembly.GetExecutingAssembly(), "ICO.PA.ico");

            RibbonPanel ArchiPanel3 = application.CreateRibbonPanel("NafraProjetos", "Identificar os trechos");
            string thisAssemblyPath3 = Assembly.GetExecutingAssembly().Location;

            PushButtonData PBD_PHid = new PushButtonData("1º", "1º", thisAssemblyPath3, End_PHid);
            PushButton PB_PHid = ArchiPanel3.AddItem(PBD_PHid) as PushButton; // Criamos o botão e o adicionamos à faixa de opções
            PB_PHid.ToolTip = "1º!"; // Definimos o texto exibido ao passar o mouse            
            PB_PHid.LargeImage = GetResourceImage(Assembly.GetExecutingAssembly(), "NafraProjetos.Resources.ICO.T1.ico");

            PushButtonData PBD_SHid = new PushButtonData("2º", "2º", thisAssemblyPath3, End_SHid);
            PushButton PB_SHid = ArchiPanel3.AddItem(PBD_SHid) as PushButton; // Criamos o botão e o adicionamos à faixa de opções
            PB_SHid.ToolTip = "2º!"; // Definimos o texto exibido ao passar o mouse            
            PB_SHid.LargeImage = GetResourceImage(Assembly.GetExecutingAssembly(), "NafraProjetos.Resources.ICO.T2.ico");

            PushButtonData PBD_THid = new PushButtonData("3º", "3º", thisAssemblyPath3, End_THid);
            PushButton PB_THid = ArchiPanel3.AddItem(PBD_THid) as PushButton; // Criamos o botão e o adicionamos à faixa de opções
            PB_THid.ToolTip = "3º!"; // Definimos o texto exibido ao passar o mouse            
            PB_THid.LargeImage = GetResourceImage(Assembly.GetExecutingAssembly(), "NafraProjetos.Resources.ICO.T3.ico");

            PushButtonData PBD_QHid = new PushButtonData("4º", "4º", thisAssemblyPath3, End_QHid);
            PushButton PB_QHid = ArchiPanel3.AddItem(PBD_QHid) as PushButton; // Criamos o botão e o adicionamos à faixa de opções
            PB_QHid.ToolTip = "4º!"; // Definimos o texto exibido ao passar o mouse            
            PB_QHid.LargeImage = GetResourceImage(Assembly.GetExecutingAssembly(), "NafraProjetos.Resources.ICO.T4.ico");

            PushButtonData PBD_BiPa = new PushButtonData("BI-PA", "BI-PA", thisAssemblyPath3, End_BiPa);
            PushButton PB_BiPa = ArchiPanel3.AddItem(PBD_BiPa) as PushButton; // Criamos o botão e o adicionamos à faixa de opções
            PB_BiPa.ToolTip = "BI-PA!"; // Definimos o texto exibido ao passar o mouse            
            PB_BiPa.LargeImage = GetResourceImage(Assembly.GetExecutingAssembly(), "NafraProjetos.Resources.ICO.BI.ico");

            PushButtonData PBD_BiRi = new PushButtonData("BI-RI", "BI-RI", thisAssemblyPath3, End_BiRi);
            PushButton PB_BiRi = ArchiPanel3.AddItem(PBD_BiRi) as PushButton; // Criamos o botão e o adicionamos à faixa de opções
            PB_BiRi.ToolTip = "BI-RI!"; // Definimos o texto exibido ao passar o mouse            
            PB_BiRi.LargeImage = GetResourceImage(Assembly.GetExecutingAssembly(), "NafraProjetos.Resources.ICO.RI.ico");

            RibbonPanel ArchiPanel4 = application.CreateRibbonPanel("NafraProjetos", "Calcular");
            string thisAssemblyPath4 = Assembly.GetExecutingAssembly().Location;

            PushButtonData PBD_CALCULAR = new PushButtonData("Yndomynus", "Yndomynus", thisAssemblyPath4, End_CALCULAR);
            PushButton PB_CALCULAR = ArchiPanel4.AddItem(PBD_CALCULAR) as PushButton; // Criamos o botão e o adicionamos à faixa de opções
            PB_CALCULAR.ToolTip = "Clique aqui!"; // Definimos o texto exibido ao passar o mouse            
            PB_CALCULAR.LargeImage = GetResourceImage(Assembly.GetExecutingAssembly(), "NafraProjetos.Resources.ICO.Hidrante32.ico");
            ContextualHelp CH = new ContextualHelp(ContextualHelpType.Url, "http://www.NafraProjetos.com");
            PB_CALCULAR.SetContextualHelp(CH);
            PB_CALCULAR.LargeImage = GetResourceImage(Assembly.GetExecutingAssembly(), "NafraProjetos.Resources.ICO.Hidrante32.ico");



            PushButtonData PBD_xxx = new PushButtonData("???", "???", thisAssemblyPath4, End_xxx);
            PushButton PB_xxx = ArchiPanel4.AddItem(PBD_xxx) as PushButton; // Criamos o botão e o adicionamos à faixa de opções
            PB_xxx.ToolTip = "_xxx!"; // Definimos o texto exibido ao passar o mouse            
            PB_xxx.LargeImage = GetResourceImage(Assembly.GetExecutingAssembly(), "NafraProjetos.Resources.ICO.Sprinkler32.ico");

            /*PushButtonData PBD_xxx = new PushButtonData("End_xxx", "End_xxx", thisAssemblyPath, End_xxx);
            PushButton PB_xxx = ArchiPanel.AddItem(PBD_xxx) as PushButton; // Criamos o botão e o adicionamos à faixa de opções
            PB_xxx.ToolTip = "_xxx!"; // Definimos o texto exibido ao passar o mouse            
            PB_xxx.LargeImage = GetResourceImage(Assembly.GetExecutingAssembly(), "NafraProjetos.Resources.Hidrante32.ico");*/
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
        public Result OnStartup(UIControlledApplication application)
        {
            AddRibbonPanel(application);
            return Result.Succeeded;
        }
    }

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class CalculoHidrante : IExternalCommand
    {
        public virtual Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            MainWindow wpfForm = new MainWindow(doc);
            wpfForm.ShowDialog();
            return Result.Succeeded;
        }
    }

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class PainelControle : IExternalCommand
    {
        public virtual Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            using (System.Windows.Forms.Form form = new Painel(doc))
            {
                return form.ShowDialog() == System.Windows.Forms.DialogResult.OK ? Result.Succeeded : Result.Cancelled;

            }
            
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class LimparComentarios : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            void LimparComentarios(BuiltInCategory OST)
            {
                FilteredElementCollector FEC = new FilteredElementCollector(doc);
                _ = FEC
                    .OfCategory(OST)
                    .WhereElementIsNotElementType()
                    .ToElements();
                using (Transaction T = new Transaction(doc, "parameter"))
                {
                    _ = T.Start();
                    if (OST == BuiltInCategory.OST_PipeCurves)
                    {
                        foreach (Pipe P in FEC)
                        {
                            Parameter Pc = P.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                            Parameter Pm = P.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);
                            try
                            {
                                _ = Pc.Set(Global.TrechoDT);
                                _ = Pm.Set("");
                            }
                            catch (Exception err)
                            {
                                _ = TaskDialog.Show("Error ST", err.Message);
                                _ = T.RollBack();
                            }
                        }
                    }
                    else
                    {
                        foreach (FamilyInstance FI in FEC)
                        {
                            Parameter Pc = FI.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                            Parameter Pm = FI.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);
                            try
                            {
                                _ = Pc.Set(Global.TrechoDT);
                                _ = Pm.Set("");
                            }
                            catch (Exception err)
                            {
                                _ = TaskDialog.Show("Error ST", err.Message);
                                _ = T.RollBack();
                            }
                        }
                    }
                    _ = T.Commit();
                }
            }
            LimparComentarios(BuiltInCategory.OST_MechanicalEquipment);
            LimparComentarios(BuiltInCategory.OST_PipeCurves);
            LimparComentarios(BuiltInCategory.OST_PipeFitting);
            LimparComentarios(BuiltInCategory.OST_PipeAccessory);
            _ = TaskDialog.Show("Atenção!", "Sistema ajustado!");
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class RI : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            void IdentificarTrechos(string Trecho)
            {
                if ((uidoc != null) && (uidoc.Selection != null))
                {
                    Reference pickedObj = uidoc.Selection.PickObject(ObjectType.Element, "Select element");
                    ElementId id = pickedObj.ElementId;
                    using (Transaction tx = new Transaction(doc))
                    {
                        _ = tx.Start("transaction");
                        if (pickedObj != null)
                        {
                            Element e = doc.GetElement(id);
                            Parameter P_C = e.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);
                            _ = P_C.Set(Trecho);
                            _ = tx.Commit();
                        }
                    }
                }
            }
            IdentificarTrechos(Global.RI);
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class BI : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            void IdentificarTrechos(string Trecho)
            {
                if ((uidoc != null) && (uidoc.Selection != null))
                {
                    Reference pickedObj = uidoc.Selection.PickObject(ObjectType.Element, "Select element");
                    ElementId id = pickedObj.ElementId;
                    using (Transaction tx = new Transaction(doc))
                    {
                        _ = tx.Start("transaction");
                        if (pickedObj != null)
                        {
                            Element e = doc.GetElement(id);
                            Parameter P_C = e.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);
                            _ = P_C.Set(Trecho);
                            _ = tx.Commit();
                        }
                    }
                }
            }
            IdentificarTrechos(Global.BI);
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class PA : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            void IdentificarTrechos(string Trecho)
            {
                if ((uidoc != null) && (uidoc.Selection != null))
                {
                    Reference pickedObj = uidoc.Selection.PickObject(ObjectType.Element, "Select element");
                    ElementId id = pickedObj.ElementId;
                    using (Transaction tx = new Transaction(doc))
                    {
                        _ = tx.Start("transaction");
                        if (pickedObj != null)
                        {
                            Element e = doc.GetElement(id);
                            Parameter P_C = e.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);
                            _ = P_C.Set(Trecho);
                            _ = tx.Commit();
                        }
                    }
                }
            }
            IdentificarTrechos(Global.PA);
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class PHid : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            void IdentificarTrechos(string Trecho)
            {
                if ((uidoc != null) && (uidoc.Selection != null))
                {
                    IList<Reference> pickedObjs = uidoc.Selection.PickObjects(ObjectType.Element, "Select elements");
                    List<ElementId> ids = (from Reference r in pickedObjs select r.ElementId).ToList();
                    using (Transaction tx = new Transaction(doc))
                    {
                        StringBuilder sb = new StringBuilder();
                        _ = tx.Start("transaction");
                        if (pickedObjs != null && pickedObjs.Count > 0)
                        {
                            foreach (ElementId eid in ids)
                            {
                                Element e = doc.GetElement(eid);
                                _ = sb.Append("\n" + e.Name);
                                Parameter P_C = e.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                                _ = P_C.Set(P_C.AsString() == Global.TrechoDT ? "" + Trecho : P_C.AsString() + Trecho);
                            }
                            _ = tx.Commit();
                        }
                    }
                }
            }
            IdentificarTrechos(Global.PHid);
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class SHid : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            void IdentificarTrechos(string Trecho)
            {
                if ((uidoc != null) && (uidoc.Selection != null))
                {
                    IList<Reference> pickedObjs = uidoc.Selection.PickObjects(ObjectType.Element, "Select elements");
                    List<ElementId> ids = (from Reference r in pickedObjs select r.ElementId).ToList();
                    using (Transaction tx = new Transaction(doc))
                    {
                        StringBuilder sb = new StringBuilder();
                        _ = tx.Start("transaction");
                        if (pickedObjs != null && pickedObjs.Count > 0)
                        {
                            foreach (ElementId eid in ids)
                            {
                                Element e = doc.GetElement(eid);
                                _ = sb.Append("\n" + e.Name);
                                Parameter P_C = e.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                                _ = P_C.Set(P_C.AsString() == Global.TrechoDT ? "" + Trecho : P_C.AsString() + Trecho);
                            }
                            _ = tx.Commit();
                        }
                    }
                }
            }
            IdentificarTrechos(Global.SHid);
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class THid : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            void IdentificarTrechos(string Trecho)
            {
                if ((uidoc != null) && (uidoc.Selection != null))
                {
                    IList<Reference> pickedObjs = uidoc.Selection.PickObjects(ObjectType.Element, "Select elements");
                    List<ElementId> ids = (from Reference r in pickedObjs select r.ElementId).ToList();
                    using (Transaction tx = new Transaction(doc))
                    {
                        StringBuilder sb = new StringBuilder();
                        _ = tx.Start("transaction");
                        if (pickedObjs != null && pickedObjs.Count > 0)
                        {
                            foreach (ElementId eid in ids)
                            {
                                Element e = doc.GetElement(eid);
                                _ = sb.Append("\n" + e.Name);
                                Parameter P_C = e.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                                _ = P_C.Set(P_C.AsString() == Global.TrechoDT ? "" + Trecho : P_C.AsString() + Trecho);
                            }
                            _ = tx.Commit();
                        }
                    }
                }
            }
            IdentificarTrechos(Global.THid);
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class QHid : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            void IdentificarTrechos(string Trecho)
            {
                if ((uidoc != null) && (uidoc.Selection != null))
                {
                    IList<Reference> pickedObjs = uidoc.Selection.PickObjects(ObjectType.Element, "Select elements");
                    List<ElementId> ids = (from Reference r in pickedObjs select r.ElementId).ToList();
                    using (Transaction tx = new Transaction(doc))
                    {
                        StringBuilder sb = new StringBuilder();
                        _ = tx.Start("transaction");
                        if (pickedObjs != null && pickedObjs.Count > 0)
                        {
                            foreach (ElementId eid in ids)
                            {
                                Element e = doc.GetElement(eid);
                                _ = sb.Append("\n" + e.Name);
                                Parameter P_C = e.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                                _ = P_C.Set(P_C.AsString() == Global.TrechoDT ? "" + Trecho : P_C.AsString() + Trecho);
                            }
                            _ = tx.Commit();
                        }
                    }
                }
            }
            IdentificarTrechos(Global.QHid);
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class BiPa : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            void IdentificarTrechos(string Trecho)
            {
                if ((uidoc != null) && (uidoc.Selection != null))
                {
                    IList<Reference> pickedObjs = uidoc.Selection.PickObjects(ObjectType.Element, "Select elements");
                    List<ElementId> ids = (from Reference r in pickedObjs select r.ElementId).ToList();
                    using (Transaction tx = new Transaction(doc))
                    {
                        StringBuilder sb = new StringBuilder();
                        _ = tx.Start("transaction");
                        if (pickedObjs != null && pickedObjs.Count > 0)
                        {
                            foreach (ElementId eid in ids)
                            {
                                Element e = doc.GetElement(eid);
                                _ = sb.Append("\n" + e.Name);
                                Parameter P_C = e.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                                _ = P_C.Set(P_C.AsString() == Global.TrechoDT ? "" + Trecho : P_C.AsString() + Trecho);
                            }
                            _ = tx.Commit();
                        }
                    }
                }
            }
            IdentificarTrechos(Global.BiPa);
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class BiRi : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            void IdentificarTrechos(string Trecho)
            {
                if ((uidoc != null) && (uidoc.Selection != null))
                {
                    IList<Reference> pickedObjs = uidoc.Selection.PickObjects(ObjectType.Element, "Select elements");
                    List<ElementId> ids = (from Reference r in pickedObjs select r.ElementId).ToList();
                    using (Transaction tx = new Transaction(doc))
                    {
                        StringBuilder sb = new StringBuilder();
                        _ = tx.Start("transaction");
                        if (pickedObjs != null && pickedObjs.Count > 0)
                        {
                            foreach (ElementId eid in ids)
                            {
                                Element e = doc.GetElement(eid);
                                _ = sb.Append("\n" + e.Name);
                                Parameter P_C = e.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                                _ = P_C.Set(P_C.AsString() == Global.TrechoDT ? "" + Trecho : P_C.AsString() + Trecho);
                            }
                            _ = tx.Commit();
                        }
                    }
                }
            }
            IdentificarTrechos(Global.BiRi);
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class SPK : IExternalCommand
    {
        private const string _path = "C:/ProgramData/Autodesk/RVT 2021/Libraries/English/Fire Protection/Sprinklers/";
        private const string _name = "M_Sprinkler - Pendent - Hosted";
        private const string _ext = ".rfa";
        private const string _filename = _path + _name + _ext;

        /*private void TriangulateFace(Face face)
        {           
            Mesh mesh = face.Triangulate();
            for (int i = 0; i < mesh.NumTriangles; i++)
            {
                MeshTriangle triangle = mesh.get_Triangle(i);
                XYZ vertex1 = triangle.get_Vertex(0);
                XYZ vertex2 = triangle.get_Vertex(1);
                XYZ vertex3 = triangle.get_Vertex(2);
            }
        }*/
        private XYZ PointOnFace(PlanarFace face)
        {
            XYZ p = new XYZ(0, 0, 0);
            Mesh mesh = face.Triangulate();
            for (int i = 0; i < mesh.NumTriangles; ++i)
            {
                MeshTriangle triangle = mesh.get_Triangle(i);
                p += triangle.get_Vertex(0);
                p += triangle.get_Vertex(1);
                p += triangle.get_Vertex(2);
                p *= 0.3333333333333333;
                break;
            }
            return p;
        }
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            /*try
            {
                UIApplication uiapp = commandData.Application;
                UIDocument uidoc = uiapp.ActiveUIDocument;
                Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
                Document doc = uidoc.Document;
                ElementClassFilter ECF = new ElementClassFilter(typeof(FamilyInstance));
                FilteredElementCollector FEC = new FilteredElementCollector(doc);
                FEC.WherePasses(ECF);
                var query = from element in FEC
                            where element.Name == _name
                            select element;
                List<FamilySymbol> FI = query.Cast<FamilySymbol>().ToList<FamilySymbol>();
                FamilySymbol sprinklerSymbol = null;
                foreach (FamilySymbol fs in FI)
                {
                    sprinklerSymbol = fs;
                    break;
                }
                if ((uidoc != null) && (uidoc.Selection != null))
                {
                    Reference faceRef = uidoc.Selection.PickObject(ObjectType.Face, "Please pick a planar face to set the work plane. ESC for cancel.");
                    GeometryObject geoObject = doc.GetElement(faceRef).GetGeometryObjectFromReference(faceRef);
                    PlanarFace planarFace = geoObject as PlanarFace;

                    //ElementId id = pickedObj.ElementId;
                    using (Transaction tx = new Transaction(doc))
                    {
                        if (faceRef != null)  
                        {                            
                            // create the sprinkler family instance:
                            FamilyInstance fi = doc.Create.NewFamilyInstance(planarFace, PointOnFace(planarFace), XYZ.BasisX, sprinklerSymbol);                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }*/





            return Result.Succeeded;
        }
    }

    /*[Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class End_xxx : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            try
            {
                Reference pickedObj = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);
                if (pickedObj != null)
                {
                    ElementId eleId = pickedObj.ElementId;
                    Element ele = doc.GetElement(eleId);
    CURVE_ELEM_LENGTH
                    Parameter P_C2 = ele.get_Parameter(BuiltInParameter.LEVEL_IS_STRUCTURAL);
                    Parameter P_C3 = ele.get_Parameter(BuiltInParameter.LEVEL_IS_BUILDING_STORY);
                    Parameter P_C4 = ele.get_Parameter(BuiltInParameter.LEVEL_UP_TO_LEVEL);
                    Parameter P_C5 = ele.get_Parameter(BuiltInParameter.LEVEL_RELATIVE_BASE_TYPE);
                    Parameter P_C6 = ele.get_Parameter(BuiltInParameter.LEVEL_ELEV);
                    Parameter P_C7 = ele.get_Parameter(BuiltInParameter.LEVEL_NAME);
                    Parameter P_C8 = ele.get_Parameter(BuiltInParameter.LEVEL_HEAD_TAG);
                    Parameter P_C9 = ele.get_Parameter(BuiltInParameter.FAMILY_LEVEL_PARAM);
                    Parameter P_C10 = ele.get_Parameter(BuiltInParameter.CURVE_LEVEL);
                    Parameter P_C11 = ele.get_Parameter(BuiltInParameter.VIEW_GRAPH_SCHED_LEVEL_RELATIVE_BASE_TYPE);
                    Parameter P_C12 = ele.get_Parameter(BuiltInParameter.SCHEDULE_LEVEL_PARAM);

                    Parameter P_C14 = ele.get_Parameter(BuiltInParameter.INSTANCE_SCHEDULE_ONLY_LEVEL_PARAM);
                    Parameter P_C15 = ele.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_PARAM);
                    Parameter P_C16 = ele.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_PARAM);

                    TaskDialog.Show("Error ElementParameterFilter_OPC",
                        + "P_C2" + P_C2.ToString()
                        + "P_C3" + P_C3.ToString()
                        + "P_C4" + P_C4.ToString()
                        + "P_C5" + P_C5.ToString()
                        + "P_C6" + P_C6.ToString()
                        + "P_C7" + P_C7.ToString()
                        + "P_C8" + P_C8.ToString()
                        + "P_C9" + P_C9.ToString()
                        + "P_C10" + P_C10.ToString()
                        + "P_C11" + P_C11.ToString()
                        + "P_C12" + P_C12.ToString()
                        + "P_C13" + P_C13.ToString()
                        + "P_C14" + P_C14.ToString()
                        + "P_C15" + P_C15.ToString()
                        + "P_C16" + P_C16.ToString()
                       );
                    TaskDialog.Show("Error ElementParameterFilter_OPC",
                        + "P_C2" + P_C2.AsString()
                        + "P_C3" + P_C3.AsString()
                        + "P_C4" + P_C4.AsString()
                        + "P_C5" + P_C5.AsString()
                        + "P_C6" + P_C6.AsString()
                        + "P_C7" + P_C7.AsString()
                        + "P_C8" + P_C8.AsString()
                        + "P_C9" + P_C9.AsString()
                        + "P_C10" + P_C10.AsString()
                        + "P_C11" + P_C11.AsString()
                        + "P_C12" + P_C12.AsString()
                        + "P_C13" + P_C13.AsString()
                        + "P_C14" + P_C14.AsString()
                        + "P_C15" + P_C15.AsString()
                        + "P_C16" + P_C16.AsString()
                       );
                    TaskDialog.Show("Error ElementParameterFilter_OPC",
                        + "P_C2" + P_C2.AsValueString()
                        + "P_C3" + P_C3.AsValueString()
                        + "P_C4" + P_C4.AsValueString()
                        + "P_C5" + P_C5.AsValueString()
                        + "P_C6" + P_C6.AsValueString()
                        + "P_C7" + P_C7.AsValueString()
                        + "P_C8" + P_C8.AsValueString()
                        + "P_C9" + P_C9.AsValueString()
                        + "P_C10" + P_C10.AsValueString()
                        + "P_C11" + P_C11.AsValueString()
                        + "P_C12" + P_C12.AsValueString()
                        + "P_C13" + P_C13.AsValueString()
                        + "P_C14" + P_C14.AsValueString()
                        + "P_C15" + P_C15.AsValueString()
                        + "P_C16" + P_C16.AsValueString()
                       );
                }

                return Result.Succeeded;
            }
            catch (Exception e)
            {
                message = e.Message;
                return Result.Failed;
            }
            try
            {
                Reference pickedObj = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);
                if (pickedObj != null)
                {
                    ElementId eleId = pickedObj.ElementId;
                    Element ele = doc.GetElement(eleId);
                    Parameter param = ele.get_Parameter(BuiltInParameter.LEVEL_PARAM);
                    InternalDefinition paramDef = param.Definition as InternalDefinition;

                    TaskDialog.Show("Parameters", string.Format("{0} parameter with builtinparameter {1}",
                        paramDef.Name,
                        paramDef.BuiltInParameter));
                }

                return Result.Succeeded;
            }
            catch (Exception e)
            {
                message = e.Message;
                return Result.Failed;
            }

        }
        /*static bool IsDesirableSystemPredicate(MEPSystem s)
        {
            return s is MechanicalSystem || s is PipingSystem && !s.Name.Equals("unassigned") && 1 < s.Elements.Size;
        }

        static string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            FilteredElementCollector allSystems = new FilteredElementCollector(doc).OfClass(typeof(MEPSystem));
            int nAllSystems = allSystems.Count<Element>();
            IEnumerable<MEPSystem> desirableSystems = allSystems.Cast<MEPSystem>().Where<MEPSystem>(s => IsDesirableSystemPredicate(s));
            int nDesirableSystems = desirableSystems.Count<Element>();
            string outputFolder = GetTemporaryDirectory();
            int n = 0;

            foreach (MEPSystem system in desirableSystems)
            {
                Debug.Print(system.Name);
                FamilyInstance root = system.BaseEquipment;

            }

            string main = string.Format("{0} XML files generated in {1} ({2} total" + "systems, {3} desirable):", n, outputFolder, nAllSystems, nDesirableSystems);
            List<string> system_list = desirableSystems.Select<Element, string>(e => string.Format("{0}({1})", e.Id, e.Name)).ToList<string>();
            system_list.Sort();
            string detail = string.Join(", ", system_list.ToArray<string>());
            TaskDialog dlg = new TaskDialog(n.ToString() + " Systems");
            dlg.MainInstruction = main;
            dlg.MainContent = detail;
            dlg.Show();
            return Result.Succeeded;
        }
    }*/

}
