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
        XarmsHasValues = false;
        YarmsHasValues = false;
        ZarmsHasValues = false;
    }

    public bool XarmsHasValues { get; set; }
    public bool YarmsHasValues { get;set; }
    public bool ZarmsHasValues { get; set; }

    private double? _totalWeight;

    public double? TotalWeight
    {
        get { return _totalWeight; }        
    }

    private double? _xArm;

    public double? Xarm
    {
        get { return _xArm; }
    }
    
    private double? _yArm;
    public double? Yarm
    {
        get { return _yArm; }
    }

    private double? _zArm;
    public double? Zarm
    {
        get { return _zArm; }
    }


    private double? _xTotalMoment;
    public double? XTotalMoment
    {
        get { return _xTotalMoment; }
    }


    private double? _yTotalMoment;
    public double? YTotalMoment
    {
        get { return _yTotalMoment; }
    }


    private double? _zTotalMoment;
    public double? ZTotalMoment
    {
        get { return _zTotalMoment; }
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
            //verify if at least amrs (lever arms) fields contain value
            if (item.Xarm.HasValue)
            {
                XarmsHasValues = true;
            }
            if (item.Yarm.HasValue)
            {
                YarmsHasValues = true;
            }
            if (item.Zarm.HasValue)
            {
                ZarmsHasValues = true;
            }

            _momentWithXarm += item.MomentWithXarm.GetValueOrDefault();

            _momentWithYarm += item.MomentWithYarm.GetValueOrDefault();

            _momentWithZarm += item.MomentWithZarm.GetValueOrDefault();

            _weightWithOutXarm += item.WeightWithoutXarm.GetValueOrDefault();

            _weightWithOutYarm += item.WeightWithoutYarm.GetValueOrDefault();

            _weightWithOutZarm += item.WeightWithoutZarm.GetValueOrDefault();

            _totalWeight += item.UnitWeight * item.Qty;
        }
        //Get the Arms and Moments according all possible scenarios.
        if (XarmsHasValues)
        {
            if (_totalWeight - _weightWithOutXarm == 0)
            {
                _xTotalMoment = _totalWeight * _xArm;
            }
            else
            {
                _xArm = _momentWithXarm / (_totalWeight - _weightWithOutXarm);
                _xTotalMoment = _totalWeight * _xArm;
            }
            
        }
        else
        {
            _xArm = null;
            _xTotalMoment = null;   
        }

        if (YarmsHasValues)
        {
            if (_totalWeight - _weightWithOutYarm == 0)
            {
                _yTotalMoment = _totalWeight * _yArm;
            }
            else
            {
                _yArm = _momentWithYarm / (_totalWeight - _weightWithOutYarm);
                _yTotalMoment = _totalWeight * _yArm;
            }

        }
        else
        {
            _yArm = null;
            _yTotalMoment = null;
        }

        if (ZarmsHasValues)
        {
            if (_totalWeight - _weightWithOutZarm == 0)
            {
                _zTotalMoment = _totalWeight * _zArm;
            }
            else
            {
                _zArm = _momentWithZarm / (_totalWeight - _weightWithOutZarm);
                _zTotalMoment = _totalWeight * _zArm;
            }

        }
        else
        {
            _zArm = null;
            _zTotalMoment = null;
        }
    }

}
