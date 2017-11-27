using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCSB
{
    class DAL
    {        
        public static void SaveNBData(NBDataModel dm)
        {            
            string col = "DateTime";
            string row = "'"+dm.DateTime+"'";
            if (dm.TimeStamp != null)
            {
                col += ",TimeStamp";
                row += ",'" + dm.TimeStamp + "'";
            }
            if (dm.MSG_ERR_CFG_OVERRIDE != null)
            {
                col += ",MSG_ERR_CFG_OVERRIDE";
                row += ",'" + dm.MSG_ERR_CFG_OVERRIDE + "'";
            }
            if (dm.MSG_ERR_NOT_PROVISIONED != null)
            {
                col += ",MSG_ERR_NOT_PROVISIONED";
                row += ",'" + dm.MSG_ERR_NOT_PROVISIONED + "'";
            }
            if (dm.Raw != null)
            {
                col += ",Raw";
                row += ",'" + dm.Raw + "'";
            }
            if (dm.Zone != null)
            {
                col += ",Zone";
                row += ",'" + dm.Zone + "'";
            }
            if (dm.PoorSignal != null)
            {
                col += ",PoorSignal";
                row += ",'" + dm.PoorSignal + "'";
            }
            if (dm.Attention != null)
            {
                col += ",Attention";
                row += ",'" + dm.Attention + "'";
            }
            if (dm.Meditation != null)
            {
                col += ",Meditation";
                row += ",'" + dm.Meditation + "'";
            }
            if (dm.BlinkStrength != null)
            {
                col += ",BlinkStrength";
                row += ",'" + dm.BlinkStrength + "'";
            }

            if (dm.MentalEffort != null)
            {
                col += ",MentalEffort";
                row += ",'" + dm.MentalEffort + "'";
            }
            if (dm.TaskFamiliarity != null)
            {
                col += ",TaskFamiliarity";
                row += ",'" + dm.TaskFamiliarity + "'";
            }
            if (dm.EegPowerDelta != null)
            {
                col += ",EegPowerDelta";
                row += ",'" + dm.EegPowerDelta + "'";
            }
            if (dm.EegPowerTheta != null)
            {
                col += ",EegPowerTheta";
                row += ",'" + dm.EegPowerTheta + "'";
            }
            if (dm.EegPowerAlpha1 != null)
            {
                col += ",EegPowerAlpha1";
                row += ",'" + dm.EegPowerAlpha1 + "'";
            }
            if (dm.EegPowerAlpha2 != null)
            {
                col += ",EegPowerAlpha2";
                row += ",'" + dm.EegPowerAlpha2 + "'";
            }
            if (dm.EegPowerBeta1 != null)
            {
                col += ",EegPowerBeta1";
                row += ",'"+dm.EegPowerBeta1 + "'";
            }
            if (dm.EegPowerBeta2 != null)
            {
                col += ",EegPowerBeta2";
                row += ",'" + dm.EegPowerBeta2 + "'";
            }
            if (dm.EegPowerGamma1 != null)
            {
                col += ",EegPowerGamma1";
                row += ",'" + dm.EegPowerGamma1 + "'";
            }
            if (dm.EegPowerGamma2 != null)
            {
                col += ",EegPowerGamma2";
                row += ",'" + dm.EegPowerGamma2 + "'";
            }
           
            string insertSql = string.Format("INSERT INTO T_NBData ({0}) VALUES({1})",col,row);
            SqlLiteHelper.ExecuteNonQuery(insertSql);
        }

        internal static List<DCDataModel> GetDList(string fileName)
        {                           
            ISheet sheet = null;
            IWorkbook workbook = null;
            List<DCDataModel> dlist = new List<DCDataModel>();
            using (FileStream fs = File.OpenRead(fileName))
            {
                if (fileName.Contains(".xlsx"))
                {
                    workbook = new XSSFWorkbook(fs);
                }
                else if (fileName.Contains(".xls"))
                {
                    workbook = new HSSFWorkbook(fs);
                }
                else
                {
                    throw new Exception("不是有效的Excel类型");
                }
            }
            sheet = workbook.GetSheetAt(0);            
            
            for (int i = 0; i < sheet.LastRowNum+1; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row == null)
                    continue;
                ICell c0 = row.GetCell(0);
                ICell c1 = row.GetCell(1);                
                if (c0 != null && c1 != null && c0.CellType == CellType.String && c1.CellType == CellType.String)
                {
                    DCDataModel d = new DCDataModel();
                    dlist.Add(d);
                    d.CK = 0;
                    d.English = c0.StringCellValue;
                    d.Chinese = c1.StringCellValue;
                }
            }
            return dlist;
        }

        internal static void UpdateDC(DCDataModel dc)
        {
            string updateSql = string.Format("UPDATE T_DCData SET CK='{0}' WHERE Eng='{1}'",dc.CK,dc.English);
            SqlLiteHelper.ExecuteNonQuery(updateSql);
        }

        internal static void SaveDC(DCDataModel currentDC)
        {
            string insertSql = string.Format("INSERT INTO T_DCData (CK,Eng,Chn) VALUES('{0}','{1}','{2}')", currentDC.CK, currentDC.English,currentDC.Chinese);
            SqlLiteHelper.ExecuteNonQuery(insertSql);
        }

    }
}
