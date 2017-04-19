# Cake.VsixSignTool

A Cake AddIn that extends Cake with [VsixSignTool](https://msdn.microsoft.com/en-us/library/dd997171.aspx).

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)
[![NuGet](https://img.shields.io/nuget/v/Cake.VsixSignTool.svg)](https://www.nuget.org/packages/Cake.VsixSignTool)

## Including addin
Including addin in cake script is easy.
```
#addin "Cake.VsixSignTool"
```

## Usage

To use the addin just add it to Cake call the aliases and configure any settings you want.

```csharp
#addin "Cake.VsixSignTool"
Task("Sign")
    .Does(() => 
    {
        VsixSignToolSign(new VsixSignToolSignSettings { 
            File = "test.pfx", 
            Hash="...some hash",
            Password = "PASSWORD"
            }, 
         "MyVsixPackage.vsix");
    });
...
```

Either string or FilePath can be used to pass target files.

# General Notes
**This is an initial version and not tested thoroughly**.
Contributions welcome.

Works only on Windows unless VsixSignTool isn't ported to other OSes.

[![Follow @mihamarkic](https://img.shields.io/badge/Twitter-Follow%20%40mihamarkic-blue.svg)](https://twitter.com/intent/follow?screen_name=mihamarkic)
