#addin "Cake.FileHelpers"

var Project = Directory("./Cake.VsixSignTool/");
var TestProject = Directory("./Cake.VsixSignToolTests/");
var CakeVsixSignToolProj = Project + File("Cake.VsixSignTool.csproj");
var CakeTestVsixSignToolProj = TestProject + File("Cake.VsixSignTool.Test.csproj");
var CakeTestVsixSignToolAssembly = TestProject + Directory("bin/Release") + File("Cake.VsixSignTool.Tests.dll");
var AssemblyInfo = Project + File("Properties/AssemblyInfo.cs");
var CakeVsixSignToolSln = File("./Cake.VsixSignTool.sln");
var CakeVsixSignToolNuspec = File("./Cake.VsixSignTool.nuspec");
var Nupkg = Directory("./nupkg");

var target = Argument("target", "Default");
var version = "";

Task("Default")
	.Does (() =>
	{
		NuGetRestore (CakeVsixSignToolSln);
		DotNetBuild (CakeVsixSignToolSln, c => {
			c.Configuration = "Release";
			c.Verbosity = Verbosity.Minimal;
		});
});

Task("UnitTest")
	.IsDependentOn("Default")
	.Does(() =>
	{
		NUnit3(CakeTestVsixSignToolAssembly);
	});

Task("NuGetPack")
	.IsDependentOn("GetVersion")
	.IsDependentOn("Default")
	.IsDependentOn("UnitTest")
	.Does (() =>
{
	CreateDirectory(Nupkg);
	NuGetPack (CakeVsixSignToolNuspec, new NuGetPackSettings { 
		Version = version,
		Verbosity = NuGetVerbosity.Detailed,
		OutputDirectory = Nupkg,
		BasePath = "./",
	});	
});

Task("GetVersion")
	.Does(() => {
		var assemblyInfo = ParseAssemblyInfo(AssemblyInfo);
		var semVersion = string.Join(".", assemblyInfo.AssemblyVersion.Split('.').Take(3));
		Information("Version {0}", semVersion);
		version = semVersion;
	});

RunTarget (target);
