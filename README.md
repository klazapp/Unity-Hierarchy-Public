# Hierarchy Color for Unity

## Introduction

The Hierarchy Color package, part of the `com.Klazapp.Editor` namespace, enhances the Unity Editor by coloring hierarchy items based on specific conditions. This tool is designed to improve scene organization and editor visibility by applying different background colors to GameObjects in the hierarchy window, helping developers quickly identify important objects or categories like TODO items or editor-only objects.

## Features

- **Visual Organization:** Automatically colors hierarchy items based on tags, names, and properties to visually distinguish between different types of GameObjects.
- **Customizable Color Coding:** Includes predefined colors for non-empty GameObjects, empty GameObjects, TODO items, and editor-only items, with easy customization options.
- **Dynamic UI Updates:** Integrates seamlessly into the Unity Editor, updating the hierarchy display in real-time as you work on your project.

## Dependencies

- **Unity Editor Scripting:** This package is specifically for use within the Unity Editor and leverages Unity's Editor scripting capabilities.

## Compatibility
| Compatibility        | URP | BRP | HDRP |
|----------------------|-----|-----|------|
| Compatible           | ✔️  | ✔️  | ✔️   |

## Installation

1. Download the Hierarchy Color package from the [GitHub repository](https://github.com/klazapp/Unity-Hierarchy-Color-Public.git) or via the Unity Package Manager.
2. Add the scripts to your Unity project, ideally within an Editor folder to ensure they are only compiled for editor use.

## Usage

The Hierarchy Color functionality is automatic once the scripts are included in your project. It will start applying colors based on the conditions defined in the scripts, with no additional setup required.

## To-Do List (Future Features)

- [ ] Provide a GUI for customizing color settings directly from the Unity Editor.
- [ ] Expand the conditions for color coding to include user-defined tags and properties.
- [ ] Enhance performance for large projects with many hierarchy items.

## License

This utility is released under the MIT License, allowing for free use, modification, and distribution within your projects.
