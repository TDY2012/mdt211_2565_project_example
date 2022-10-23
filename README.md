# Project Example

## International Clock

### Description

This program demonstrates how the standard datetime struct and timezone info library work.

## Profile Image Generator

### Description

This program demonstrates how the standard drawing library work.

### Installation Guide 

Add required package to your project using `dotnet add package <package_name> --version <version>`. Please make sure you are in a project directory before calling the command. In this case, I added `System.Drawing.Common` version `6.0.0`. This depends on packages you used.

### Additional Requirement for MacOS

You probably need to add `runtime.osx.10.10-x64.CoreCompat.System.Drawing` version `6.0.5.128` to your project as well.

### Additional Requirement for Linux

Install libgdiplus using `apt-get install libgdiplus`.

Create `runtimeconfig.template.json` in the project directory and add these following lines:

```
{
   "configProperties": {
      "System.Drawing.EnableUnixSupport": true
   }
}
```