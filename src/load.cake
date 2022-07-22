#tool nuget:?package=xunit.runner.console
#tool nuget:?package=OctopusTools

var target = Argument("target", "Build");

#load "./paths.cake"
#load "./prepare.cake"
#load "./build.cake"
#load "./createOctopusRelease.cake"
#load "./targets.cake"
	

RunTarget(target);


