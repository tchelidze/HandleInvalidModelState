# HandleInvalidModelState 
  Handy action filters to eliminate/automate ModelState validition check.

# [Nuget](https://www.nuget.org/packages/HandleInvalidModelState)

`PM> Install-Package HandleInvalidModelState`

# Overview

In a typical scenario, post action method starts with checking `ModelState`'s validity and if it's invalid returning wiew with invalid model

```c#
[HttpPost]
public IActionResult Create(CreateViewModel model)
{
    if (!ModelState.IsValid)
       return View(model);
    // ...
    return View();
}
```

This boilerplate code (checking `ModelState`'s validity and returning a view) can be eliminated with corresponding action filter.

```c#
[HttpPost]
[TypeFilter(typeof(HandleInvalidModelWithViewActionFilterAttribute))]
public IActionResult Create(CreateViewModel model)
{
   // ...
   return View();
}
```

For detailed instruction for handling invalid `ModelState` with

- [View](https://github.com/tchelidze/HandleInvalidModelState/wiki/Handle-with-View)
- [Json](https://github.com/tchelidze/HandleInvalidModelState/wiki/Handle-with-Json)
- [Redirect](https://github.com/tchelidze/HandleInvalidModelState/wiki/Handle-with-Redirect)
