namespace MPC_MassPropertiesCalculator.Models;
public class MassPropItem
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

    private double? _momentWithXarm;

    public double? MomentWithXarm
    {
        get { return _momentWithXarm; }
        set {
            if (Xarm != null)
            {
                _momentWithXarm = UnitWeight*Qty*Xarm;
            }
            
        }
    }

    private double? _momentWithYarm;

    public double? MomentWithYarm
    {
        get { return _momentWithYarm; }
        set {
            if (Yarm != null)
            {
                _momentWithYarm = UnitWeight * Qty * Yarm;
            }
        }
    }

    private double? _momentWithZarm;

    public double? MomentWithZarm
    {
        get { return _momentWithZarm; }
        set {
            if (Zarm != null)
            {
                _momentWithZarm = UnitWeight * Qty * Zarm;
            }
        }
    }

    private double? _weightWithoutXarm;

    public double? WeightWithoutXarm
    {
        get { return _weightWithoutXarm; }
        set {
            if (Xarm is null)
            {
                _weightWithoutXarm = UnitWeight * Qty;
            }
        }
    }

    private double? _weightWithoutYarm;

    public double? WeightWithoutYarm
    {
        get { return _weightWithoutYarm; }
        set {
            if (Yarm is null)
            {
                _weightWithoutYarm = UnitWeight * Qty;
            }
        }
    }

    private double? _weightWithoutZarm;

    public double? WeightWithoutZarm
    {
        get { return _weightWithoutZarm; }
        set {
            if (Yarm is null)
            {
                _weightWithoutZarm = UnitWeight * Qty;
            }
        }
    }

}
