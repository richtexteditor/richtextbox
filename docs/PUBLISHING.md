# Publishing The Trial Demo

## Build

```powershell
dotnet build .\RichTextBoxSolution-demo.slnx
```

## Publish The Website

```powershell
dotnet publish .\src\RichTextBox.WebSite\RichTextBox.WebSite.csproj -c Release -o .\publish\RichTextBox.WebSite
```

## Publish Notes

- `RichTextBox.lic` is already included in the website project and is copied to publish output.
- Static editor assets are served through the `RichTextBox` project as ASP.NET Core static web assets.
- Uploaded files are stored under `wwwroot\uploads` unless the package options are changed.

## Temporary IIS / Server Trial

If the client wants a short hosted evaluation:

1. Publish the website.
2. Confirm `RichTextBox.lic` exists beside the published app files.
3. Start the site and open `/Trial` and `/Demos`.
