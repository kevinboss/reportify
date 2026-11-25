# Configuration

Before you use reportify, define the mandatory settings in the `.reportify`
file in your user directory. reportify creates this [YAML](https://yaml.org/)
file on first start.

| Setting                  | Description                          | Example                                |
|--------------------------|--------------------------------------|----------------------------------------|
| `manicTime.databasePath` | Path to the ManicTime database file. | C:\Tools\ManicTime\ManicTimeReports.db |
| `jira.url`               | URL of the Jira instance.            | https://jira.atlassian.com             |
| `jira.accessToken`       | Access token for the Jira instance.  | A1B2C3D4E5F6G                          |

Example `.reportify`:

```yaml
manicTime:
  databasePath: C:\Tools\ManicTime\ManicTimeReports.db
jira:
  url: https://jira.atlassian.com
  accessToken: A1B2C3D4E5F6G
```

reportify validates the configuration on startup and reports missing or invalid
settings.

## Jira access token

Generate the access token in Jira under
`Profile > Personal Access Tokens > Create token`. Only the `BROWSE_PROJECTS`
permission is required.
