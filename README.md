# RegExAsciiViewer
Powershell commands to test
```
Invoke-RestMethod -Method Get -Uri http://localhost:5000/asciitable?regexp=[^a-zA-Z0-9]
Invoke-RestMethod -Method Get -Uri http://localhost:5000/asciitable?regexp=[0-9]
```