using System.Reflection;
using Submerge;
using MelonLoader;

[assembly: AssemblyTitle(Submerge.Main.Description)]
[assembly: AssemblyDescription(Submerge.Main.Description)]
[assembly: AssemblyCompany(Submerge.Main.Company)]
[assembly: AssemblyProduct(Submerge.Main.Name)]
[assembly: AssemblyCopyright("Developed by " + Submerge.Main.Author)]
[assembly: AssemblyTrademark(Submerge.Main.Company)]
[assembly: AssemblyVersion(Submerge.Main.Version)]
[assembly: AssemblyFileVersion(Submerge.Main.Version)]
[assembly: MelonInfo(typeof(Submerge.Main), Submerge.Main.Name, Submerge.Main.Version, Submerge.Main.Author, Submerge.Main.DownloadLink)]
[assembly: MelonColor(System.ConsoleColor.White)]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONELAB")]