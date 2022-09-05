namespace MPC_MassPropertiesCalculator.Models;

public interface IMassPropTotal
{
    double? MomentWithXarm { get; }
    double? MomentWithYarm { get; }
    double? MomentWithZarm { get; }
    double? TotalWeight { get; }
    double? WeightWithYarm { get; }
    double? WeightWithXarm { get; }
    double? WeightWithZarm { get; }
    double? Xarm { get; }
    bool XarmsHasValues { get; set; }
    double? XArmTotalMomentWithXarm { get; }
    double? XTotalMoment { get; }
    double? Yarm { get; }
    bool YarmsHasValues { get; set; }
    double? YArmTotalMomentWithYarm { get; }
    double? YTotalMoment { get; }
    double? Zarm { get; }
    bool ZarmsHasValues { get; set; }
    double? ZArmTotalMomentWithZarm { get; }
    double? ZTotalMoment { get; }

    void GetMassPropTotal(List<MassPropItem> massPropItems);
}