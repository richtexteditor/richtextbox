# Client Trial Guide

## Goal

Use this demo to evaluate the ASP.NET Core `richtextbox` Tag Helper, dialog experience, upload flow, and migration readiness from legacy editor deployments.

## Suggested Evaluation Path

1. Start the website and open `/Trial`.
2. Open `/Demos`.
3. Test the main editor with the default toolbar.
4. Test the `office2007blue` skin sample.
5. Open the dialog playground and verify:
   - image URL dialog
   - image gallery
   - template dialog
6. In the image gallery, test:
   - folder navigation
   - upload
   - folder creation
   - search
   - insert
7. Right-click inside the editor to test the context menu sample.
8. Review `/Features` for wrapper capabilities and `/Download` for packaging notes.

## Key Pages

- `/Trial`
- `/Demos`
- `/Features`
- `/Download`

## Trial Checklist

- Editor renders with no missing assets
- `RichTextBox.lic` is detected successfully
- Image upload works
- Gallery browsing works
- Context menu appears inside the editor
- Template dialog inserts content
- Office-style skin loads correctly

## Source Layout

- `src\RichTextBox` contains the ASP.NET Core package source
- `src\RichTextBox.WebSite` contains the runnable trial website
