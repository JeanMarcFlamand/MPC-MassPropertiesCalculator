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
        _weightWithXarm = 0;
        _weightWithYarm = 0;
        _weightWithZarm = 0;
        XarmsHasValues = false;
        YarmsHasValues = false;
        ZarmsHasValues = false;
    }
    
    public bool XarmsHasValues { get; set; }
    public bool YarmsHasValues { get; set; }
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

    private double? _xArmForTotalMomentWithXarm;
    public double? XArmTotalMomentWithXarm
    {
        get { return _xArmForTotalMomentWithXarm; }
    }

    private double? _yArmForTotalMomentWithYarm;
    public double? YArmTotalMomentWithYarm
    {
        get { return _yArmForTotalMomentWithYarm; }
    }

    private double? _zArmForTotalMomentWithZarm;
    public double? ZArmTotalMomentWithZarm
    {
        get { return _zArmForTotalMomentWithZarm; }
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


    private double? _weightWithXarm;
    public double? WeightWithXarm
    {
        get { return _weightWithXarm; }
    }


    private double? _weightWithYarm;
    public double? WeighttWithYarm
    {
        get { return _weightWithYarm; }
    }


    private double? _weightWithZarm;
    public double? WeightWithZarm
    {
        get { return _weightWithZarm; }
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

            _weightWithXarm += item.WeightWithXarm.GetValueOrDefault();

            _weightWithYarm += item.WeightWithYarm.GetValueOrDefault();

            _weightWithZarm += item.WeightWithZarm.GetValueOrDefault();

            _totalWeight += item.UnitWeight * item.Qty;
        }

        //Get the Arms and Moments according all possible scenarios.
        if (XarmsHasValues)
        {
            //scenario 1 - Total weight is not = 0 and all weight and CG are defined in X axis. Perform basic Calcs.
            if (_totalWeight != 0 && _totalWeight - _weightWithXarm == 0)
            {
                _xArm = _momentWithXarm / _totalWeight;
                _xTotalMoment = _momentWithXarm;
            }
            //scenario 2 - Total weight is not = 0 and some records do not have CG defined in X axis.
            else if (_totalWeight != 0 && _totalWeight - _weightWithXarm != 0)
            {
                _xArm = _momentWithXarm / _weightWithXarm;
                // adjust the total moment by adding moment of weight not having X arm.
                _xTotalMoment = _momentWithXarm + (_totalWeight - _weightWithXarm) * _xArm;
            }
            //scenario 3 - Total weight is = 0 and all weight and CG are defined in X axis.
            else if (_totalWeight == 0 && _totalWeight - _weightWithXarm == 0)
            {
                // Preform moment caculation only beacause calculation X arm will do overflow .
                _xArm = null;
                _xTotalMoment = _momentWithXarm;
            }
            //scenario 4 - Total weight is = 0 and some record do not have CG defined in X axis.
            else if (_totalWeight == 0 && _totalWeight - _weightWithXarm != 0)
            {
                //  Check if weightWithXarm =0 Preform moment caculation only beacause calculation X arm will do overflow .
                if (_weightWithXarm == 0)
                {
                    _xArm = null;
                    _xTotalMoment = null;

                }
                else
                {
                    _xArm = _momentWithXarm / _weightWithXarm;
                    _xTotalMoment = _momentWithXarm + (_totalWeight - _weightWithXarm) * _xArm;
                    _xArmForTotalMomentWithXarm = _xArm;
                    _xArm = null;
                }
            }

        }
        //scenario 5 -  no CofG
        else
        {
            _xArm = null;
            _xTotalMoment = null;
            _weightWithXarm = null;
            _momentWithXarm = null;
            _xArmForTotalMomentWithXarm = null;
        }

        if (YarmsHasValues)
        {
            // Scenario 1 - Total weight is not = 0 and all weight and CG are defined in Y axis. Perform basic Calcs.
            if (_totalWeight != 0 && _totalWeight - _weightWithYarm == 0)
            {
                _yArm = _momentWithYarm / _totalWeight;
                // adjust the total moment by adding moment of weight not having X arm.
                _yTotalMoment = _momentWithYarm;
            }
            // Scenario 2 - Total weight is not = 0 and some records do not have CG defined in Y axis.
            else if (_totalWeight != 0 && _totalWeight - _weightWithYarm != 0)
            {
                _yArm = _momentWithYarm / _weightWithYarm;
                // adjust the total moment by adding moment of weight not having Y arm.
                _yTotalMoment = _momentWithYarm + (_totalWeight - _weightWithYarm) * _yArm;
            }
            // Scenario 3 - Total weight is = 0 and all weight and CG are defined in Y axis.
            else if (_totalWeight == 0 && _totalWeight - _weightWithYarm == 0)
            {
                // Preform moment caculation only beacause calculation Y arm will do overflow .
                _yArm = null;
                _yTotalMoment = _momentWithYarm;
            }
            // Scenario 4 - Total weight is = 0 and some record do not have CG defined in Y axis.
            else if (_totalWeight == 0 && _totalWeight - _weightWithYarm != 0)
            {
                // Check if weightWithYarm =0 Preform moment caculation only beacause calculation Y arm will do overflow .

                if (_weightWithYarm == 0)
                {
                    _yArm = null;
                    _yTotalMoment = null;
                }
                else
                {
                    _yArm = _momentWithYarm / _weightWithYarm;
                    _yTotalMoment = _momentWithYarm + (_totalWeight - _weightWithYarm) * _yArm;
                    _yArmForTotalMomentWithYarm = _yArm;
                    _yArm = null;
                }

            }

        }
        // Scenario 5 - No CofG
        else
        {
            _yArm = null;
            _yTotalMoment = null;
            _weightWithYarm = null;
            _momentWithYarm = null;
            _yArmForTotalMomentWithYarm = null;
        }

        if (ZarmsHasValues)
        {
            // Scenario 1 - Total weight is not = 0 and all weight and CG are defined in Z axis. Perform basic Calcs.
            if (_totalWeight != 0 && _totalWeight - _weightWithZarm == 0)
            {
                _zArm = _momentWithZarm / _totalWeight;
                _zTotalMoment = _momentWithXarm;
            }
            // Scenario 2 - Total weight is not = 0 and some records do not have CG defined in Z axis.
            else if (_totalWeight != 0 && _totalWeight - _weightWithZarm != 0)
            {
                _zArm = _momentWithZarm / _weightWithZarm;
                // adjust the total moment by adding moment of weight not having Z arm.
                _zTotalMoment = _momentWithZarm + (_totalWeight - _weightWithZarm) * _zArm;
            }
            // Scenario 3 - Total weight is = 0 and all weight and CG are defined in X axis.
            else if (_totalWeight == 0 && _totalWeight - _weightWithZarm == 0)
            {
                // Preform moment caculation only beacause calculation X arm will do overflow .
                _zArm = null;
                _zTotalMoment = _momentWithZarm;
            }
            // Scenario 4 - Total weight is = 0 and some record do not have CG defined in Z axis.
            else if (_totalWeight == 0 && _totalWeight - _weightWithZarm != 0)
            {
                // Check if weightWithXarm =0 Preform moment caculation only beacause calculation Z arm will do overflow .

                if (_weightWithZarm == 0)
                {
                    _zArm = null;
                    _zTotalMoment = null;
                }
                else
                {
                    _zArm = _momentWithZarm / _weightWithZarm;
                    _zTotalMoment = _momentWithZarm + (_totalWeight - _weightWithZarm) * _zArm;
                    _zArmForTotalMomentWithZarm = _zArm;
                    _zArm = null;
                }

            }

        }
        // Scenario 5 - No CofG
        else
        {
            _zArm = null;
            _zTotalMoment = null;
            _weightWithZarm = null;
            _momentWithZarm = null;
            _zArmForTotalMomentWithZarm = null;
        }
    }

}
