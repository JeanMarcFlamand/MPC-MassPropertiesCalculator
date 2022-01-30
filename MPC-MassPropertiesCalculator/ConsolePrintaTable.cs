using Microsoft.Toolkit;
using MPC_MassPropertiesCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPC_MassPropertiesCalculator;
public class ConsolePrintaTable
{
    
    private const int _tableWidth = 100;
    static public void PrintRowSeperator()
  {
      Console.WriteLine(new string ('_',_tableWidth) );
  }
    static public void DisplayCSV(List<MassPropItem> massPropItems)
    {
        foreach (MassPropItem? massPropItem in massPropItems)
        {
            //Properties names of Class MassPropSample.cs
            //item,PartNumber,Rev,NIC,Instance,Description,Type,
            //Qty,UnitWeight,Xarm,Yarm,Zarm,PackageCode,ANDetail,DesingOwnerCode,MomentWithXarm,MomentWithYarm,MomentWithZarm,WeightWithoutXarm,WeightWithoutYarm,WeightWithoutZarm
            // Trim Description to lenght of 10
            string? descriptionTrimmed = massPropItem.Description.Truncate(11);

            Console.WriteLine(string.Format($"| {massPropItem.Item,-10} |" +
                $" {massPropItem.PartNumber,-10} |" +
                $" {descriptionTrimmed,-11} |" +
                $" {massPropItem.Qty,5:0} |" +
                $" {massPropItem.UnitWeight,10:0} |" +
                $" {massPropItem.Xarm,10:0.0} |" +
                $" {massPropItem.Yarm,10:0.0} |" +
                $" {massPropItem.Zarm,10:0.0} |"));

            ConsolePrintaTable.PrintRowSeperator();
        }

    }
    static public void DisplayHeanderWanted(string[] header)
    {
        Console.WriteLine(string.Format($"| {header[0],-10} |" +
                $" {header[1],-10} |" +
                $" {header[5],-11} |" +
                $" {header[7],-5} |" +
                $" {header[8],-5} |" +
                $" {header[9],-10} |" +
                $" {header[10],-10} |" +
                $" {header[11],-10} |"));

    }
}
