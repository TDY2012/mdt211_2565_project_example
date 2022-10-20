# mdt211_2565_project_example

Install libgdiplus using `apt-get install libgdiplus`.

Create `runtimeconfig.template.json` in the project directory and add these following lines:

```
{
   "configProperties": {
      "System.Drawing.EnableUnixSupport": true
   }
}
```

Add required package using `dotnet add package <package_name> --version <version>`. In this case, we added `System.Drawing.Common` version `6.0.0`.