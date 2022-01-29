namespace MPC_MassPropertiesCalculator.Models;
class MassPropItem
{           
    public int? Item { get; set; }
    public string? PartNumber { get; set; }
    public string? Rev { get; set; }
    public string? NIC { get; set; }
    public int? Instance { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public int? Qty { get; set; }
    public double? UnitWeight { get; set; }
    public double? Xarm { get; set; }
    public double? Yarm { get; set; }
    public double? Zarm { get; set; }
    public string? PackageCode { get; set; }
    public string? ANDetail { get; set; }
    public string? DesingOwnerCode { get; set; }
    public double? MomentWithXarm { get; set; }
    public double? MomentWithYarm { get; set; }
    public double? MomentWithZarm { get; set; }
    public double? WeightWithoutXarm { get; set; }
    public double? WeightWithoutYarm { get; set; }
    public double? WeightWithoutZarm { get; set; }


    private double? _myVar;

    public double? XmomentTest
    {
        get { return Moment(UnitWeight,Qty,Xarm); }
        set { _myVar = value; }
    }


    static public double? Moment(double? weight, double? qty,double? arm)
    {
        return weight*qty*arm;
    }


}
