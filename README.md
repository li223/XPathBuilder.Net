# XPathBuilder.Net

Simple builder for creating XPaths because the strings are annoying.

Simple usage:
```cs
var builder = new PathBuilder();
builder.HasComponent(PathComponentType.Window, window =>
{
  window.WithName("TestWindow");
  window.WithClassName("TestClass");
});
```

Congrats.
