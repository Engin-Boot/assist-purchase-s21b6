using System.Collections.Generic;
using ProductInfoApi.Models;

namespace ProductInfoApi.Repository
{
    public interface ICharacteristicWiseFilter
    {
        Dictionary<string, ProductData> GetAllProducts();
        IEnumerable<object> GetAllProductIds();

        IEnumerable<object> FilterByTouchscreen(
            List<string> productIdsListByUser, string isTouchscreen);

        IEnumerable<object> FilterByHandle(
            List<string> productIdsListByUser, string hasHandle);

        IEnumerable<object> FilterByCeCertification(
            List<string> productIdsListByUser, string hasCeCertificate);

        IEnumerable<object> FilterByBatteryAvailability(
            List<string> productIdsListByUser, string hasBattery);

        IEnumerable<object> FilterByScreenSize(
            List<string> productIdsListByUser, string sizeOfScreen);

        IEnumerable<object> FilterByWeight(
            List<string> productIdsListByUser, string weightExpected);

        IEnumerable<object> FilterByScreenType(
            List<string> productIdsListByUser, string screenTypeExpected);

        IEnumerable<object> FilterByDimensions(List<string> productIdsListByUser,
            string lengthExpected, string widthExpected, string heightExpected);

        IEnumerable<KeyValuePair<string, ProductData>> GetSelectedProductDetails(List<string> productIdsListByUser);
    }
}