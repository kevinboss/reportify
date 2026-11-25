# Usage

reportify generates reports for a specific date or an entire week. With no
options, it generates a report for the current day.

## Commands

```text
USAGE:
    reportify [OPTIONS]

OPTIONS:
                                  DEFAULT
    -h, --help                               Prints help information
    -v, --version                            Prints version information
    -d, --date <DATE>                        Create report for a specified date, defaults to the current day
    -w, --week                               Create report for the current week
    -o, --week-offset <OFFSET>    0          Offset in weeks to determine the week used for the report
    -c, --copy                               Copy report in CSV format to clipboard
```

`--date` and `--week` cannot be combined. `--week-offset` requires `--week`.
Date values are parsed using your system's current culture.

Example:

```text
# reportify -d 12.06.2023

── Report for 12.06.2023. Total: 9.00h (08:57) ────────────────────────────────────────────────────
┌──────────┬──────────────┬────────────────────────────────────────────────────────────────┐
│ Position │ Duration (h) │ Activities                                                     │
├──────────┼──────────────┼────────────────────────────────────────────────────────────────┤
│ 123 456  │ 5,50 (05:23) │ - #REP-297 Validate configuration                     05:07    │
│          │              │ - #REP-263 Create new configuratio on start           00:16    │
│          │              │                                                                │
│ 234 567  │ 1,50 (01:31) │ - Administration $234567                              01:00    │
│          │              │ - Break $234567                                       00:31    │
│          │              │                                                                │
│ 345 678  │ 1,25 (01:16) │ #REP-291 Beautify report output                       01:16    │
│          │              │                                                                │
│ 456 789  │ 0,75 (00:46) │ #REP-228 Log Exceptions                               00:46    │
└──────────┴──────────────┴────────────────────────────────────────────────────────────────┘
```

Durations are rounded to quarter hours. When `--copy` is set, reportify copies
semicolon-delimited rows formatted as `dd.MM.yyyy;position;hours;comment` to
the clipboard and omits entries without a position.

## ManicTime

reportify reads tracked activities from your local ManicTime SQLite database in
read-only mode.

If a Jira issue key (such as `#REP-228`) appears in the activity description,
reportify retrieves the corresponding issue position from Jira. The issue key
is extracted with this regular expression:

```regexp
#([a-zA-Z]+-\d+)
```

If no Jira issue exists, include a six-digit position number in the activity
description (such as `$123456`). A direct position number takes precedence over
a Jira issue key and is extracted with this regular expression:

```regexp
\$(\d{6})
```

Add a comment to a tracked activity after `%`, for example
`#REP-228 %This is my comment`. The comment is extracted with this regular
expression:

```regexp
%(?<notes>.*)
```

Everything after `%` is treated as a comment, so
`%This is my comment #REP-228` uses `This is my comment #REP-228` as the
comment while still extracting the Jira issue key.
