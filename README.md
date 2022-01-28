Installing for Development:
- Windows 10, or greater
- Visual Studio 2022, 17.0 or greater
https://visualstudio.microsoft.com/vs/community/
- Install .NET Development component in the Visual Studio Installer
https://docs.microsoft.com/en-us/visualstudio/install/modify-visual-studio?view=vs-2022
- .Net Framework 4.8
Check version here: https://github.com/jmalarcon/DotNetVersions/releases
Download here: https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48
- Install MetroFramework
http://denricdenise.info/2014/09/how-to-use-winforms-modern-ui/
-Setup the Visual Studio Installer Extension through the extension menu or by download
https://marketplace.visualstudio.com/items?itemName=VisualStudioClient.MicrosoftVisualStudio2017InstallerProjects
- You may have to open the NuGet Manager and update the SQLite package

Create a file C:\Developer.txt to:
- Test the updater
-???

- More info on ESI here: https://esi.evetech.net/ui
- and setting up EVEIPHClientID: https://developers.eveonline.com/
- The project will need to be built once before any of the forms can be opened. This builds the User Controls sub-forms. 

Design notes
- Generally I've used the labels to convey information about success or failure and msgboxes to ask the user to make a choice before continuing. I have avoided using msgboxes to convey failures.

Testing
- Install the compiled .exe on a Windows 10 or greater VM such as VirtualBox
- test each msgbox
- test each status label (flowchart to show each path?)
- add a character
- test the dummy character
- for each character, inlcuding dummy, try each calcuation mode (all, auto, ...)
- close the software and re-run the all test cases right after, identifies things that only update -once every few minutes
- also run all test cases again while keeping the program open, identifies things that break when run twice in succession
- low dpi through high dpi (resolution scaling settings)
- test on a character with no blueprints

notes on deployment, latest files, sde builder...