

Task("Clean")
	.Does(() => {
	Information("Start cleaning...");
	CleanDirectory(Argument<DirectoryPath>("PackageOutputPath", EnvironmentVariable("OctopusPackages")));
	Information("Successfully cleaned");
	});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
	{
	Information("Start restoring nuget packages...");
		NuGetRestore(Paths.SolutionFile);
		Information("Successfully restored");
	});

	
	
