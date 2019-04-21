#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var buildFolder= Argument("buildFolder", "./build");
var solutionPath= Argument("solutionPath", "./WebApiApplication.sln");


//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.  
var buildDir = Directory(buildFolder);
var packageDir = MakeAbsolute(Directory("./package"));

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
    CleanDirectory(packageDir);
});

Task("Remove-Packages")
    .Does(() =>
{
    CleanDirectory(packageDir);
});


Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    //NuGetRestore(solutionPath, new NuGetRestoreSettings { MSBuildVersion=NuGetMSBuildVersion.MSBuild14 });
    NuGetRestore(solutionPath);
});
// .OnError(exception =>
// {
//     // Handle the error here.
// });

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
    {
       // DirectoryPath buildDir = MakeAbsolute(Directory("./bin/build"));
        DirectoryPath buildDirPath = MakeAbsolute(buildDir);
        // Use MSBuild
        var settings = new MSBuildSettings()
                            .WithProperty("OutputPath", buildDirPath.FullPath)
                            .SetConfiguration(configuration)
                            .SetVerbosity(Verbosity.Verbose)
                            .UseToolVersion(MSBuildToolVersion.VS2017)
                            .SetMSBuildPlatform(MSBuildPlatform.x86)
                            .SetVerbosity(Verbosity.Minimal)
                            .SetPlatformTarget(PlatformTarget.MSIL);

        MSBuild(solutionPath, settings);
    });
// .OnError(exception =>
// {
//     // Handle the error here.
// });

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    // NUnit3("./src/**/bin/" + configuration + "/*.Tests.dll", new NUnit3Settings {
    //     NoResults = true
    //     });
        var testAssemblies = GetFiles(buildDir.ToString() + "/*.Tests.dll");
        MSTest(testAssemblies);
});

Task("Zip-Files")
    .IsDependentOn("Build")
    .Does(() =>
{
    //var files = GetFiles( parameters.Paths.Directories.ArtifactsBin + "/**/*" );
    //Zip(parameters.Paths.Directories.ArtifactsBin, parameters.Paths.Files.ZipBinaries, files);
      EnsureDirectoryExists(packageDir);

      Zip(buildDir.ToString() + "/_PublishedWebsites/" , "./package/deploy.zip");

	
});

// Task("Package")
// .Does(() =>
// {

//     MSBuild("PROJECT_NAME.csproj", settings =>
//         settings.SetConfiguration(configuration)
//         .UseToolVersion(MSBuildToolVersion.VS2015)
//         .WithTarget("Package")
//         .WithProperty("VisualStudioVersion", new string[]{"14.0"})
//         .WithProperty("PackageLocation", new string[]{ packageDir.ToString()  })
//         .WithProperty("PackageTempRootDir", new string[]{"root"})
//         );


// });


Task("Package-Nuget")
//.IsDependentOn("Run-Unit-Tests")
.IsDependentOn("Build")
.Does(() =>
{
    EnsureDirectoryExists(packageDir);

    // MSBuild("PROJECT_NAME.csproj", settings =>
    //     settings.SetConfiguration(configuration)
    //     .UseToolVersion(MSBuildToolVersion.VS2015)
    //     .WithTarget("Package")
    //     .WithProperty("VisualStudioVersion", new string[]{"14.0"})
    //     .WithProperty("PackageLocation", new string[]{ packageDir.ToString()  })
    //     .WithProperty("PackageTempRootDir", new string[]{"root"})
    //     );


});


//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Zip-Files");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);

