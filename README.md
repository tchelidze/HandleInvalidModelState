# HandleInvalidModelState - Handy action filters to eliminate/automate ModelState validition check.


# Overview

In a typical scenario, post action method starts with checking `ModelState`'s validity and if it's invalid returning wiew with invalid model

```
[HttpPost]
public IActionResult Create(CreateViewModel model)
{
    if (!ModelState.IsValid)
       return View(model);
    // ...
    return View();
}
```

This boilerplate code (checking `ModelState`'s validity and returning a view) can be iliminated with corresponding action filter.

```
[HttpPost]
[TypeFilter(typeof(HandleInvalidModelWithViewActionFilterAttribute))]
public IActionResult Create(CreateViewModel model)
{
   // ...
   return View();
}
```
