var configuration  = Argument("configuration", "Release"); 
string newVersion = string.Empty;



Task("Build-App-Air-Service")
	.Does(()=> {
		DotNetCoreClean(Paths.AppServiceName.FullPath);
		DotNetCoreRestore(Paths.AppServiceName.FullPath);
		DotNetCoreBuild(Paths.AppServiceName.FullPath, new DotNetCoreBuildSettings() {

         Configuration = "Release",
         OutputDirectory = string.Format(@"{0}\tmp", EnvironmentVariable("OctopusPackages")) 
		});
		
		OctoPack("AppPackageName", new OctopusPackSettings {
			BasePath = string.Format(@"{0}\tmp", EnvironmentVariable("OctopusPackages")) ,
			OutFolder = EnvironmentVariable("OctopusPackages"),
			Version = newVersion
		});		
});


Task("AssemblyInfo")
	.Does(() => { 
	Information("Get assemblyInfo...");
	var assemblyInfo = ParseAssemblyInfo(Paths.AssemblyInfoProClickWebPath);
	newVersion = GetNewVersion(assemblyInfo.AssemblyVersion, EnvironmentVariable("BUILD_NUMBER"));

	Information("Version: {0}", assemblyInfo.AssemblyVersion);
	Information("File version: {0}", assemblyInfo.AssemblyFileVersion);
	Information("Informational version: {0}", assemblyInfo.AssemblyInformationalVersion);
	
	CreateNewAssemblyInfo(Paths.AssemblyInfoProClickWebPath, newVersion);
	
	BuildSystem.TeamCity.SetBuildNumber(newVersion);
	//BuildSystem.TeamCity.SetBuildNumber(assemblyInfo.AssemblyFileVersion);
	});