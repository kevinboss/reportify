![logo](doc/img/logo-banner.png)

# reportify

[![CI](https://github.com/kevinboss/reportify/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/kevinboss/reportify/actions/workflows/ci.yml)
[![GitHub release](https://img.shields.io/github/v/release/kevinboss/reportify)](https://github.com/kevinboss/reportify/releases)
[![licence](https://img.shields.io/github/license/kevinboss/reportify)](https://github.com/kevinboss/reportify/blob/main/LICENSE)

reportify generates daily and weekly time reports from activities tracked in
[ManicTime](https://www.manictime.com/). It maps activities to positions using
[Jira](https://www.atlassian.com/software/jira) issue keys or six-digit
position numbers in the activity description, and outputs a summary table or
copies it as CSV.

Install with
[winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/):

```powershell
winget install francWhite.reportify
```

Or with [scoop](https://scoop.sh):

```powershell
scoop bucket add maple 'https://github.com/kevinboss/maple.git'
scoop install reportify
```

Prebuilt archives are on the
[releases page](https://github.com/kevinboss/reportify/releases).

The first run creates `.reportify` in your user directory; see
[configuration](doc/configuration.md) for the required settings. Then run:

```powershell
reportify                # report for today
reportify -d 12.06.2023  # report for a specific date
reportify -w             # report for the current week
reportify -w -c          # report for the current week and copy CSV
```

See [usage](doc/usage.md) for all options, activity tagging, and CSV export.

## How to contribute

Fork the repository, run `dotnet test ./src`, and open a pull request. See
[CONTRIBUTING.md](CONTRIBUTING.md) for prerequisites and build steps.
