Task("Build-package")
	.WithCriteria(() => BuildSystem.IsRunningOnTeamCity)
	.IsDependentOn("Clean")
	.IsDependentOn("Restore-NuGet-Packages")
	.IsDependentOn("AssemblyInfo")
	.IsDependentOn("Build-App")
	
