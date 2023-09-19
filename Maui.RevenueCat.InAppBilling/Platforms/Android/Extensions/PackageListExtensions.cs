using Com.Revenuecat.Purchases;
using Maui.RevenueCat.InAppBilling.Extensions;
using Maui.RevenueCat.InAppBilling.Models;

namespace Maui.RevenueCat.InAppBilling.Platforms.Android.Extensions;

internal static class PackageListExtensions
{
    public static List<OfferingDto> ToOfferDtoList(this List<Package> packages)
    {
        var offers = new List<OfferingDto>();

        foreach (var package in packages)
        {
            var currencyCode = package.Product.Price.CurrencyCode;
            var price = Convert.ToDecimal(package.Product.Price.AmountMicros * Math.Pow(10, -6));

            var offeringDto = new OfferingDto()
            {
                Identifier = package.Identifier,
                Product = new ProductDto()
                {
                    Pricing = new PricingDto
                    {
                        CurrencyCode = currencyCode,
                        Price = price,
                        PriceMicros = package.Product.Price.AmountMicros,
                        PriceLocalized = OfferingDtoExtensions.GetLocalizedPrice(currencyCode, price)
                    },
                    Sku = package.Product.Sku,
                    SubscriptionPeriod = package.Product.Period.ToString(),
                }
            };

            offers.Add(offeringDto);
        }

        return offers;
    }
}
