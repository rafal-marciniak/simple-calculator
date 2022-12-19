# Requirements
- .NET 7, or above
- recommended: Visual Studio 2022 (17.4.3 or above)

# How to Run
1. Using Visual Studio: press F5. You can include command line arguments with the Debug Properties window.
2. Using command line:
```
cd SimpleCalculator
dotnet run
```
Or if you wish to support a file with commands:
```
cd SimpleCalculator
dotnet run C:\input.txt
```

# How to interact with the application
Use commands to manipulate registers values. Example:
```
Area add PI
Area multiply R
Area multiply R
R add 10
PI add 3.142
print Area
quit
```
Type `help` for a commands overview.
