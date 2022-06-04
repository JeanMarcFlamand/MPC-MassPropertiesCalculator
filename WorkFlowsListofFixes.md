Error: C:\Users\runneradmin\AppData\Local\Microsoft\dotnet\sdk\6.0.300\Sdks\Microsoft.NET.Sdk\targets\Microsoft.PackageDependencyResolution.targets(267,5): error NETSDK1047: Assets file 'D:\a\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator\obj\project.assets.json' doesn't have a target for 'net6.0/win-x86'. Ensure that restore has run and that you have included 'net6.0' in the TargetFrameworks for your project. You may also need to include 'win-x86' in your project's RuntimeIdentifiers. [D:\a\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator\MPC-MassPropertiesCalculator.csproj]

add 

        <RuntimeIdentifiers>win-x86</RuntimeIdentifiers>

in the csproj file


        <PropertyGroup>
          <OutputType>Exe</OutputType>
          <TargetFramework>net6.0</TargetFramework>
          <RootNamespace>MPC_MassPropertiesCalculator</RootNamespace>
          <ImplicitUsings>enable</ImplicitUsings>
          <Nullable>enable</Nullable>
          <Platforms>AnyCPU;x64</Platforms>
        <RuntimeIdentifiers>win-x86</RuntimeIdentifiers>
        </PropertyGroup>
        
Solution Ref: [YouTube](https://youtu.be/VIlDni8-iWM)
not sure about the tecnical reasons but
