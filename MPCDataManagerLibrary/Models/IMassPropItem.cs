namespace MPC_MassPropertiesCalculator.Models;

public interface IMassPropItem
{
    string? ANDetail { get; set; }
    string? Description { get; set; }
    string? DesingOwnerCode { get; set; }
    int? Instance { get; set; }
    int? Item { get; set; }
    double? MomentWithXarm { get; set; }
    double? MomentWithYarm { get; set; }
    double? MomentWithZarm { get; set; }
    string? NIC { get; set; }
    string? PackageCode { get; set; }
    string? PartNumber { get; set; }
    int? Qty { get; set; }
    string? Rev { get; set; }
    string? Type { get; set; }
    double? UnitWeight { get; set; }
    double? WeightWithXarm { get; set; }
    double? WeightWithYarm { get; set; }
    double? WeightWithZarm { get; set; }
    double? Xarm { get; set; }
    double? Yarm { get; set; }
    double? Zarm { get; set; }
}