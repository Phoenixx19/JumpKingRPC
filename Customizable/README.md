# Customizable folder for JKRPC
In this folder, you can find all the pictures and fonts that you can find inside of the applciation, these can be changed by following the instructions.
In order to apply changes you will need to download:
- The source code or the master of JumpKingRPC (download [here](https://github.com/Phoenixx19/JumpKingRPC/archive/master.zip))
- .NET Framework 4.5
<br>

## Instructions for custom images
Inside of the folder 'Customizable' you can find some examples of pictures you can use.
1. To change a picture, move the pictures inside the folder 'Images'
2. Open the *JumpKingRPC.csproj* file and with Visual Studio
3. Using the Visual Studio Designer, find the picture you want to change by clicking it and change it by going under:
> Properties > Appearance > Image
4. Save and compile it.
5. Profit!

## Instructions for custom fonts
Inside of the folder 'Customizable' you can find an example of font you can use.
1. To change a font, move the font inside the folder 'Images'
2. Open the *JumpKingRPC.csproj* file and with Visual Studio
3. Navigate to `MainApp.cs` and inside the `Form1_Load` method, (on line 56) you will change the font name to your new font name.
4. Save and compile it.
5. Profit!