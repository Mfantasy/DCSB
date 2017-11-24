using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DCSB
{
    class Utils
    {
        public static Object lockObj = new object();

        public static void WriteLog(string logInfo)
        {
            lock (lockObj)
            {
                File.AppendAllText("log.txt", DateTime.Now.ToString() + "\r\n logInfo:" + logInfo + "\r\n");
            }
        }
  
        public static void ExcelTest()
        {
            HSSFWorkbook workBook = new HSSFWorkbook();
            ISheet st = workBook.CreateSheet("yyyy.M.d");
            IRow r0 = st.CreateRow(0);
            r0.Height = 200;
            IRow r1 = st.CreateRow(1);
            st.SetColumnBreak(1);
            st.SetColumnBreak(0);
            ICell c1 = r1.CreateCell(0);
            ICell c2 = r1.CreateCell(1);
            ICell c3 = r1.CreateCell(2);
            c1.SetCellValue("XXXSB泰斯特斯特斯特斯特");
            IRow r2 = st.CreateRow(2);
            ICell c21 = r2.CreateCell(0);
            ICell c22 = r2.CreateCell(1);
            ICell c23 = r2.CreateCell(2);
            c21.SetCellValue("c21");
            c22.SetCellValue("c22");
            c23.SetCellValue("c23");

            CellRangeAddress cra = new CellRangeAddress(1, 1, 0, 1);
            st.AddMergedRegion(cra);

            using (FileStream fs = File.OpenWrite("xxx.xls"))
            {
                workBook.Write(fs);
            }
        }
 
        /// <summary>
        /// 表中内容均为string
        /// </summary>                
        public static void ExportToXls(string fileName, DataTable dataTable)
        {
            HSSFWorkbook workBook = new HSSFWorkbook();
            ISheet sheet = workBook.CreateSheet();
            int i = 1;
            int jL = dataTable.Columns.Count;

            IRow r0 = sheet.CreateRow(0);//列头            
            int jj = 0;
            foreach (DataColumn item in dataTable.Columns)
            {
                ICell cell = r0.CreateCell(jj);
                cell.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                cell.SetCellValue(item.ColumnName);
                jj++;
            }

            foreach (DataRow item in dataTable.Rows)
            {
                IRow row = sheet.CreateRow(i);
                for (int j = 0; j < jL; j++)
                {
                    ICell cell = row.CreateCell(j);
                    cell.SetCellValue(item[j].ToString());
                }
                i++;
            }

            using (FileStream fs = File.OpenWrite(fileName))
            {
                workBook.Write(fs);
            }
        }

        public static void ToFile<T>(string path, T obj)
        {
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path)))
            {
                File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path)).Close();
            }

            XmlSerializerFactory factory = new XmlSerializerFactory();
            XmlSerializer serializer = factory.CreateSerializer(typeof(T));

            try
            {
                using (FileStream fs = File.Open(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path), FileMode.Create))
                {
                    serializer.Serialize(fs, obj);
                    fs.Flush();
                }
            }
            catch (Exception e)
            {
                StringBuilder error = new StringBuilder();
                error.AppendLine(e.Message);
                error.AppendLine();
                error.AppendFormat("{0}", path);
                error.AppendLine();
                error.AppendFormat("{0}", AppDomain.CurrentDomain.BaseDirectory);
                MessageBox.Show(error.ToString());
            }
        }

        public static T FromXMLFile<T>(string path)
        {
            var x = new XmlDocument();
            x.Load(path);
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path)))
            {
                throw new Exception(string.Format("没有找到配置文件:{0}", Path.GetFullPath(path)));
            }
            else
            {
                try
                {
                    XmlSerializerFactory factory = new XmlSerializerFactory();
                    XmlSerializer serializer = factory.CreateSerializer(typeof(T));

                    if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path)))
                    {
                        using (FileStream fs = File.OpenRead(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path)))
                        {
                            if (fs != null && fs.Length > 0)
                            {
                                object cacheData = serializer.Deserialize(fs);
                                return cacheData == null ? default(T) : (T)cacheData;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                return default(T);
            }
        }

    }
}
