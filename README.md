# AoC Helper

A small, basic, utility package to help pull down the input (maybe more, like submit, in the future).

## Usage

1. Create an `appsettings.json` in your project root that looks like the following;
```json
{
    "Secrets": {
        "Cookie": "Configured in User Secrets"
    }
}
```

2. Run `dotnet user-secrets init` to add secret management to your project. Take note of the User Secrets ID.
3. Run `dotnet user-secrets set Secrets:Cookie session=...` to set your cookie (see [Notes section](#notes) for how to find it).
4. Use code like the following to get your puzzle input;
``` csharp
var user = new User(Helpers.GetCookie("YourUserSecretsID"));
var puzzle = new Puzzle(user, 2019, 1);

Console.WriteLine(puzzle.GetInputAsync().Result);
```

## Notes

This requires the cookie for your session. Use dev-tools to find this in the request headers, it should look like `cookie: session=536...`, save the value only (`session=536...`).