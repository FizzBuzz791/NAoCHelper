# AoC Helper

A small, basic, utility package to help pull down the input (maybe more, like submit, in the future).

## Usage

``` csharp
var user = new User(Cookie);
var puzzle = new Puzzle(user, 2019, 1);

Console.WriteLine(puzzle.GetInputAsync().Result);
```

## Notes

This requires the cookie for your session. Use dev-tools to find this in the request headers, it should look like `cookie: session=536...`, save the value only.  
It's recommended to save this value in user-secrets if you're using source control.