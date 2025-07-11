# Timewise Fuse

####  Timewise Fuse fetches scheduling data from Timewise and creates export files to Agda and Hoogia.
### Agda
- If Export to Agda the data is sorted on date. Don't export to Agda without valid employment numbers.
- Before export the user has to add Shift Codes used in Agda to Timewise Fuse. These shift codes is stored in a database. 
- A fuse table displays the data from Timewise with corresponding shift code and warn the user if a shift from Timewise lacks a corresponding shift code.
- Relevant data from the Fuse Table is exported in a csv -file.

### Hoogia
- If Export to Hoogia the data is sorted on employment number. Don't export to Hoogia without valid employment numbers.
- Export to Hoogia is done by a button click. The data is exported in a txt-file.

## Users
- Login is required to access data
- The programme has a admin panel to handle roles and users
- The role Admin has access to all features
- he role CustomerAgda only displays Agda features
- The role CustomerHoogia only displays Hoogia features


## Installation

Use the package manager to Add the Database

```bash
Add-Database MigrationName
```

```bash
Update-database
```

## Usage
1. Add xml-url:s to the appsettings.json XmlUrl and XmlUrlx values:
```bash
  "XmlUrl": "https://timewise.theater.se:111/data.ashx?export=EXPORTCODE&filter=startdate:2023-02-03", (test only)
  "XmlUrlx": "https://timewise.theater.se:111/data.ashx?export=EXPORTCODE" (used in production))
```

2. If Agda -Add working shifts to the shift table

3. Add users to log in to the software

4. Download the data.

## Technologies
- .NET Core 5.0 Razor Pages
- entity framework core
- SQL Server
- Bootstrap
- JQuery
- Javascript
- HTML
- CSS

## Roadmap
- Handle setup and distribution of the software
- Handle other software imports and exports

## Contributing
- For contributions please consult the Timewise Development Team!

## License

[Timewise](https://timewise.se)