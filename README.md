# Global360 QA Assessment

UI automation assessment for the Snipe-IT demo application using C#, .NET 10 and Microsoft Playwright.

## Technologies

- C#
- .NET 10
- Microsoft Playwright
- xUnit
- Google Chrome

## Application

Snipe-IT Demo:

https://demo.snipeitapp.com/login

Demo credentials:

- Username: `admin`
- Password: `password`

## Automated Scenario

The automation covers the following assessment flow:

1. Login to Snipe-IT.
2. Create a new Macbook Pro 13" asset.
3. Set the status to Ready to Deploy.
4. Check out the asset to a random existing user.
5. Search for the created asset in the Assets list.
6. Verify that the asset was created successfully.
7. Open the asset Details page from the Assets list.
8. Verify the Serial Number and Model.
9. Open the History tab.
10. Verify the `create new` and `checkout` history records.

## Project Structure

```text
Pages/
    LoginPage.cs
    AssetsListPage.cs
    CreateAssetPage.cs
    CheckoutPage.cs
    AssetDetailsPage.cs

Tests/
    CreateAssetTests.cs
    CheckoutTests.cs
    AssetVerificationTests.cs
```

The project uses the Page Object Model to separate page interactions from test scenarios.

## Prerequisites

Install the following before running the tests:

- .NET 10 SDK
- Google Chrome
- Visual Studio with .NET support

Check the installed .NET version:

```powershell
dotnet --version
```

## Setup

Restore the NuGet packages:

```powershell
dotnet restore
```

Build the project:

```powershell
dotnet build
```

## Running the Tests

The tests are designed to be run individually from Visual Studio Test Explorer.

Open:

**Test → Test Explorer**

Run the tests in the following order.

### 1. Create the Asset

Run:

```text
CreateMacbookAsset_ShouldSucceed
```

This test:

- Logs into Snipe-IT.
- Opens the Assets page.
- Creates a Macbook Pro 13" asset.
- Sets the status to Ready to Deploy.
- Saves the asset.

Wait until the test shows **Passed** before continuing.

### 2. Checkout the Asset

Run:

```text
CheckoutExistingAsset_ShouldSucceed
```

This test:

- Logs into Snipe-IT.
- Searches for the created asset.
- Opens the Checkout page.
- Selects a random existing user.
- Selects Sign/Accept in place.
- Checks out the asset.

Wait until the test shows **Passed** before continuing.

### 3. Verify the Asset

Run:

```text
VerifyCreatedAsset_ShouldSucceed
```

This test:

- Logs into Snipe-IT.
- Searches for the created asset.
- Verifies the asset exists in the Assets list.
- Opens the asset Details page from the list.
- Verifies the Serial Number.
- Verifies the Model is Macbook Pro 13".
- Opens the History tab.
- Verifies the `create new` history record.
- Verifies the `checkout` history record.

## Test Run Order

```text
CreateMacbookAsset_ShouldSucceed
        ↓
CheckoutExistingAsset_ShouldSucceed
        ↓
VerifyCreatedAsset_ShouldSucceed
```

Run the tests individually in the order above rather than using **Run All**.

## Notes

The tests use the locally installed Google Chrome browser.