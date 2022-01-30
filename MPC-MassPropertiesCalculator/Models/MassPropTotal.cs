namespace MPC_MassPropertiesCalculator.Models;
class MassPropTotal
{
    private double? _totalWeight;

    public double? TotalWeight
    {
        get { return _totalWeight; }
        set { _totalWeight = value; }
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
        set { _momentWithXarm = value; }
    }

    private double? _momentWithYarm;

    public double? MomentWithYarm
    {
        get { return _momentWithYarm; }
        set { _momentWithYarm = value; }
    }

    private double? _momentWithZarm;

    public double? MomentWithZarm
    {
        get { return _momentWithZarm; }
        set { _momentWithZarm = value; }
    }

    private double? _weightWithOutXarm;

    public double? WeightWithOutXarm
    {
        get { return _weightWithOutXarm; }
        set { _weightWithOutXarm = value; }
    }

    private double? _weightWithOutYarm;

    public double? WeighttWithOutYarm
    {
        get { return _weightWithOutYarm; }
        set { _weightWithOutYarm = value; }
    }

    private double? _weightWithOutZarm;

    public double? WeightWithOutZarm
    {
        get { return _weightWithOutZarm; }
        set { _weightWithOutZarm = value; }
    }

    public void GetMassPropTotal(List<MassPropItem> massPropItems)
    {
        foreach (var item in massPropItems)
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
