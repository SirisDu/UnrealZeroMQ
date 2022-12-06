// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System;
using System.IO;
using System.Diagnostics;

public class ZeroMQ : ModuleRules
{
    private string ThirdPartyPath
    {
        get { return Path.GetFullPath(Path.Combine(ModuleDirectory, "..", "ThirdParty")); }
    }

    private string ZeroMQRootPath
    {
        get { return Path.GetFullPath(Path.Combine(ThirdPartyPath, "ZeroMQLibrary")); }
    }

    public void AddZeroMQ(ReadOnlyTargetRules Target)
    {
        // add headers
        PublicIncludePaths.Add(Path.Combine(ZeroMQRootPath, "include"));

        // tell library that it is statically linked
        PublicDefinitions.Add("ZMQ_STATIC");

        string staticLibrary = "";
        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            staticLibrary = Path.Combine(ZeroMQRootPath, "Windows", "x64", "libzmq-mt-4_3_4.lib");

            // Delay-load the DLL, so we can load it from the right place first
            PublicDelayLoadDLLs.Add("ExampleLibrary.dll");

            // Ensure that the DLL is staged along with the executable
            RuntimeDependencies.Add("$(PluginDir)/Binaries/ThirdParty/ZeroMQLibrary/Win64/libzmq-mt-4_3_4.dll");
        }
        else
        {
            Console.WriteLine("unsupported target platform: %s", Target.Platform);
            Debug.Assert(false);
        }

        bEnableExceptions = true;

        Console.WriteLine("Using ZeroMQ static library: {0}", staticLibrary);
        PublicAdditionalLibraries.Add(staticLibrary);
    }


    public ZeroMQ(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
        PublicDependencyModuleNames.AddRange(new string[] { "Core" });
        AddZeroMQ(Target);
    }
}
