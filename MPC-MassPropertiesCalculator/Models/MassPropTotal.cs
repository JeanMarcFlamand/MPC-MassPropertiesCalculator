namespace MPC_MassPropertiesCalculator.Models;
public class MassPropTotal
{
    public MassPropTotal()
    {
        //Constructor
        _totalWeight = 0;
        _momentWithXarm = 0;
        _momentWithYarm = 0;
        _momentWithZarm = 0;
        _weightWithOutXarm = 0;
        _weightWithOutYarm = 0;
        _weightWithOutZarm = 0;
    }
    private double? _totalWeight;

    public double? TotalWeight
    {
        get { return _totalWeight; }        
    }

    private double? _xArm;

    public double? Xarm
    {
        get { return _xArm; }
        set { _xArm = _momentWithXarm/(_totalWeight-_weightWithOutXarm); }
    }
    private double? _yArm;

    public double? Yarm
    {
        get { return _yArm; }
        set { _yArm = _momentWithYarm/(_totalWeight-_weightWithOutYarm); }
    }

    private double? _zarm;

    public double? Zarm
    {
        get { return _zarm; }
        set { _zarm = _momentWithZarm/(_totalWeight-_weightWithOutZarm); }
    }

    private double? _momentWithXarm;

    public double? MomentWithXarm
    {
        get { return _momentWithXarm; }
    }

    private double? _momentWithYarm;

    public double? MomentWithYarm
    {
        get { return _momentWithYarm; }
    }

    private double? _momentWithZarm;

    public double? MomentWithZarm
    {
        get { return _momentWithZarm; }
    }

    private double? _weightWithOutXarm;

    public double? WeightWithOutXarm
    {
        get { return _weightWithOutXarm; }
    }

    private double? _weightWithOutYarm;

    public double? WeighttWithOutYarm
    {
        get { return _weightWithOutYarm; }
    }

    private double? _weightWithOutZarm;

    public double? WeightWithOutZarm
    {
        get { return _weightWithOutZarm; }
    }

    public void GetMassPropTotal(List<MassPropItem> massPropItems)
    {
        foreach (MassPropItem? item in massPropItems)
        {
            _momentWithXarm += item.MomentWithXarm;
            _momentWithYarm +=  item.MomentWithYarm;
            _momentWithZarm +=  item.MomentWithZarm;
            _weightWithOutXarm += item.WeightWithoutXarm;
            _weightWithOutYarm += item.WeightWithoutYarm;
            _weightWithOutZarm += item.WeightWithoutZarm;
            _totalWeight += item.UnitWeight * item.Qty;
        }

    }

}
