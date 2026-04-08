using RichTextBox;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddRichTextBox(options =>
{
    options.UploadEndpoint = "/richtextbox/upload";
    options.GalleryEndpoint = "/richtextbox/gallery";
    options.UploadWebPath = "/uploads";
});
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

var app = builder.Build();

app.UseForwardedHeaders();

SeedRichTextBoxDemoGallery(app.Environment, app.Services.GetRequiredService<IOptions<RichTextBoxOptions>>().Value);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.MapRichTextBoxUploads();

app.Run();

static void SeedRichTextBoxDemoGallery(IWebHostEnvironment environment, RichTextBoxOptions options)
{
    var webRoot = string.IsNullOrWhiteSpace(environment.WebRootPath)
        ? Path.Combine(environment.ContentRootPath, "wwwroot")
        : environment.WebRootPath;
    var uploadsRoot = string.IsNullOrWhiteSpace(options.UploadPhysicalPath)
        ? Path.Combine(webRoot, options.UploadWebPath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar))
        : options.UploadPhysicalPath;
    var imagesRoot = Path.Combine(webRoot, "images");

    Directory.CreateDirectory(uploadsRoot);
    Directory.CreateDirectory(Path.Combine(uploadsRoot, "Guest"));
    Directory.CreateDirectory(Path.Combine(uploadsRoot, "Member"));
    Directory.CreateDirectory(Path.Combine(uploadsRoot, "Users"));

    var seedFiles = new (string Source, string Destination)[]
    {
        (Path.Combine(imagesRoot, "microsoft.svg"), Path.Combine(uploadsRoot, "microsoft.svg")),
        (Path.Combine(imagesRoot, "Intel.svg"), Path.Combine(uploadsRoot, "Guest", "Intel.svg")),
        (Path.Combine(imagesRoot, "Nokia.svg"), Path.Combine(uploadsRoot, "Member", "Nokia.svg")),
        (Path.Combine(imagesRoot, "Sony_logo.svg"), Path.Combine(uploadsRoot, "Users", "Sony_logo.svg"))
    };

    foreach (var seedFile in seedFiles)
    {
        if (!File.Exists(seedFile.Source) || File.Exists(seedFile.Destination))
        {
            continue;
        }

        File.Copy(seedFile.Source, seedFile.Destination);
    }
}
