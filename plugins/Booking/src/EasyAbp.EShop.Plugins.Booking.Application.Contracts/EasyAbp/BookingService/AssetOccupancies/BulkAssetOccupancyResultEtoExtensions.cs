using System;
using EasyAbp.BookingService.AssetOccupancies;
using Volo.Abp.Data;

namespace EasyAbp.BookingService.AssetOccupancies;

public static class BulkAssetOccupancyResultEtoExtensions
{
    public static Guid? FindBookingOrderId(this BulkAssetOccupancyResultEto eto)
    {
        return eto.GetProperty<Guid?>(BulkAssetOccupancyResultEtoProperties.BookingOrderId);
    }
}