<details><summary>Bugs Fixed</summary>
<p>
Error:
        C:\Users\runneradmin\AppData\Local\Microsoft\dotnet\sdk\6.0.300\Sdks\Microsoft.NET.Sdk\targets\Microsoft.PackageDependencyResolution.targets(267,5):
        error NETSDK1047: Assets file 'D:\a\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator\obj\project.assets.json'
        doesn't  have a target for 'net6.0/win-x86'. Ensure that restore has run and that you have included 'net6.0' in the TargetFrameworks for your project.
        You may also need to include 'win-x86' in your project's RuntimeIdentifiers.
        [D:\a\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator.csproj]

add 

        <RuntimeIdentifiers>win-x64</RuntimeIdentifiers>

in the csproj file


        <PropertyGroup>
          <OutputType>Exe</OutputType>
          <TargetFramework>net6.0</TargetFramework>
          <RootNamespace>MPC_MassPropertiesCalculator</RootNamespace>
          <ImplicitUsings>enable</ImplicitUsings>
          <Nullable>enable</Nullable>
          <Platforms>AnyCPU;x64</Platforms>
        <RuntimeIdentifiers>win-x64</RuntimeIdentifiers>
        </PropertyGroup>
        
Solution Ref: [YouTube](https://youtu.be/VIlDni8-iWM)
not sure about the tecnical reasons but
</p>
</details>

<details><summary>Bugs Not Fixed</summary>
<p>
1. Certificate could not be opened
        
        C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Microsoft\VisualStudio\v17.0\AppxPackage\Microsoft.AppXPackage.Targets(841,5):
        error : Certificate could not be opened: JeanMarcFlamand.pfx.
        [D:\a\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator.Installer\MPC-MassPropertiesCalculator.Installer.wapproj]
2. The specified network password is not correct
        
        C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Microsoft\VisualStudio\v17.0\AppxPackage\Microsoft.AppXPackage.Targets(841,5):
        error : The specified network password is not correct.
        [D:\a\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator.Installer\MPC-MassPropertiesCalculator.Installer.wapproj]
        
3. (default targets) -- FAILED.
        
        C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Microsoft\VisualStudio\v17.0\AppxPackage\Microsoft.AppXPackage.Targets(841,5):
        error :  [D:\a\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator.Installer\MPC-MassPropertiesCalculator.Installer.wapproj]
        Done Building Project "D:\a\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator.Installer\MPC-MassPropertiesCalculator.Installer.wapproj" (default targets) -- FAILED.
        Done Building Project "D:\a\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculatorApp.sln" (default targets) -- FAILED.
        
</p>
</details>
