public static class Paths 
{
	public static FilePath ProClickWeb = @"..\..\AppServiceName\AppServiceName.csproj";

	public static FilePath AssemblyInfoPath = @"..\..\Exprimo.ProClick\Properties\AssemblyInfo.cs";
	
	public static FilePath CodeCoverageResultFile = "coverage.xml";
	public static DirectoryPath CodeCoverageReportDirectory = "Coverage";
}

public static FilePath Combine(DirectoryPath directory, FilePath file)
{
	return directory.CombineWithFilePath(file);
}

public static string GetNewVersion(string assemblyVersion, string version) {
var versionArray = assemblyVersion.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
	return $"{versionArray[0]}.{versionArray[1]}.{versionArray[2]}.{version}";
}

public void CreateNewAssemblyInfo(FilePath path, string newVersion) {
	var assemblyInfo = ParseAssemblyInfo(path);
	CreateAssemblyInfo(path, new AssemblyInfoSettings {
        InformationalVersion = newVersion,
		FileVersion = newVersion,
		Version = newVersion,
		Title = assemblyInfo.Title,
		Company = assemblyInfo.Company,
		Product = assemblyInfo.Product,
		Copyright = assemblyInfo.Copyright,
		Guid = assemblyInfo.Guid,
    });
} 
