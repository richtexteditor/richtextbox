# License Setup

## Recommended ASP.NET Core Location

Place `RichTextBox.lic` in the app content root.

For this demo, that means:

- `src\RichTextBox.WebSite\RichTextBox.lic`

This is the recommended location because:

- it is outside `wwwroot`
- it is available through the ASP.NET Core content root
- the website project copies it to build and publish output automatically

## Default Demo License

The included trial/demo file contains:

- `LicenseNumber=30076785`
- `LicenseMessage=RichTextBox is licensed.`

## Optional Path Override

The package supports a content-root-relative license path through `LicenseContentRootRelativePath`.

Example:

```csharp
builder.Services.AddRichTextBox(options =>
{
    options.LicenseContentRootRelativePath = "licenses/RichTextBox.lic";
});
```

## Runtime Behavior

The package looks in the content root first and then checks the app output directory as a compatibility fallback.
