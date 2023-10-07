# Maui.RevenueCat.InAppBilling
## Credits
This plugin is based on:
- [Android](https://github.com/thisisthekap/Xamarin.RevenueCat.Android) and [iOS](https://github.com/thisisthekap/Xamarin.RevenueCat.iOS) bindings from [thisisthekap](https://github.com/thisisthekap) and
- usage example [RevenueCatXamarin](https://github.com/BillFulton/RevenueCatXamarin) from [BillFulton](https://github.com/BillFulton)

## Usage

Firstly add these packages into your main `.csproj` because otherwise Android won't be able to build:
```
<ItemGroup Condition="$(TargetFramework.Contains('-android'))">
	<PackageReference Include="Xamarin.Google.Crypto.Tink.Android" VersionOverride="1.8.0.1" />
	<PackageReference Include="Xamarin.AndroidX.Activity.Ktx" Version ="1.7.2" />
	<PackageReference Include="Xamarin.GooglePlayServices.Base" Version ="118.2.0.2" />
</ItemGroup>
```

Register package installer in your `MauiProgram.cs`
```csharp
 builder.Services.AddRevenueCatBilling();
```

then in `App.xaml.cs` inject `IRevenueCatBilling`:
```csharp
public partial class App : Application {
    private readonly IRevenueCatBilling _revenueCat;

    public App(IRevenueCatBilling revenueCat) {
        InitializeComponent();
        _revenueCat = revenueCat;
    }
}
```
and also override there method `OnStart()` to call `_revenueCat.Initialize` with your revenueCat apiKey (this key is platform dependant).

```csharp
protected override void OnStart() {
    var revenueCatApiKey = string.Empty;

#if __ANDROID__
    revenueCatApiKey = "<AndroidRevenueCatKeyHere>";
#elif __IOS__
    revenueCatApiKey = "<iOSRevenueCatKeyHere>";
#endif

    _revenueCat.Initialize(revenueCatApiKey);

    base.OnStart();
}
```

## Dummy classes

So that you dont have to specify platform for this package and it's calls, also Windows and MacCatalyst are added with dummy implementations. When you call one of their methods you will always get:
- `true` for bool returns
- `new List<>` for collections
- `string.Empty` for string values

Example of such dummy class: [RevenueCatBillingWindows.cs](Maui.RevenueCat.InAppBilling/Platforms/Windows/RevenueCatBillingWindows.cs)

## Exception behavior
- Library will throw exceptions only in case developer did some mistake
- in other cases, when there is some corrupted state it will either return ErrorCode in output variable e.g. `PurchaseResult` or it will return default value of that type.

## Contributions
Feel free to create an issue or pull request. In case you would like to do massive changes in the package please firstly discuss them in the issue because otherwise there is high chance that such big PR would be rejected.

## TODO
- [ ] Implement check if GooglePlay/Apple store is activated (installed & user signed in)
- [ ] Verify overall functionality
- [ ] Pipeline package build and publish artifacts
- [ ] Pipeline PR test build
- [ ] Unify somehow SubscriptionPeriod inside OfferingDto

## License
This repository is licensed with the [MIT](LICENSE.txt) license.
